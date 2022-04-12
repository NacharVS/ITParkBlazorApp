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
            if (database.ListCollectionNames().ToList().Exists(x => x == day))
            {
                collection.ReplaceOne(x=>true, item);
            }
            else
            collection.InsertOne(item);
        }


        public static List<TaskItem> GetTaskList(string day)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("TaskList");
            var collection = database.GetCollection<TaskListDB>(day);
            var TaskListFromDB = collection.Find(x => true).ToList();
            List<TaskItem> listToReturn = new List<TaskItem>();
            listToReturn.AddRange(collection.Find(x => true).FirstOrDefault().taskList);
            return listToReturn;
        }

    }
}
