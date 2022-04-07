using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class TaskListDB
    {
        public TaskListDB(List<TaskItem> taskList)
        {
            this.taskList = taskList;
        }
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        [BsonElement("ListOfTasks")]
        public List<TaskItem> taskList { get; set; }

        public static void AddItem(TaskListDB item, string day)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("TaskList");
            var collection = database.GetCollection<TaskListDB>(day);
            if(database.ListCollectionNames().ToList().Exists(x => x == day))
            {
                collection.ReplaceOne(x => true, item);
            }
            else
            {
                collection.InsertOne(item);
            }
            
        }
        public static List<TaskItem> GetItem()
        {
            var client = new MongoClient("mongodb://localhost");        
            var database = client.GetDatabase("TaskList");
            //var a = database.ListCollectionNames().ToList(); для получения имен коллекций в бд
            var collection = database.GetCollection<TaskListDB>("Monday");
            List<TaskItem> list = new List<TaskItem>();
            list.AddRange(collection.Find(x => true).FirstOrDefault().taskList);
            //TaskListDB document = collection.Find(x => true).FirstOrDefault();
            //foreach (var item in document.taskList)
            //{
            //    list.Add(item);
            //}
            return list;
        }
    }
}
