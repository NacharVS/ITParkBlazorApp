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

        public ObjectId _id { get; set; }
        [BsonElement("ListOfTasks")]
        public List<TaskItem> taskList { get; set; }

        public static void AddItem(TaskListDB item, string day)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("TaskList");
            var collection = database.GetCollection<TaskListDB>(day);
            collection.InsertOne(item);
        }
        //public static List<string> GetTaskList(TaskItem items, string day)
        //public static List<string> GetTaskList()
        //{
        //    var client = new MongoClient("mongodb://localhost");
        //    var database = client.GetDatabase("TaskList");
        //    var collection = database.GetCollection<TaskItem>("Monday");
        //    var TaskListFromDB = collection.Find(x => true).ToList();
        //    List<string> listToReturn = new List<string>();
        //    foreach (var item in TaskListFromDB)
        //    {
        //        listToReturn.Add(item.Name);
        //    }
        //    return listToReturn;
        //}
        public static List<TaskItem> GetTaskList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("TaskList");
            var collection = database.GetCollection<TaskListDB>("Monday");
            var TaskListFromDB = collection.Find(x => true).ToList();
            List<TaskItem> listToReturn = new List<TaskItem>();
            listToReturn.AddRange(collection.Find(x => true).FirstOrDefault().taskList);
            return listToReturn;
        }
    }
}
