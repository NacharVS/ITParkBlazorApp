using BlazorApp4.Data;
using Microsoft.AspNetCore.Components;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Services
{
    public class TaskService
    {
        public TaskService()
        {
            taskItems = GetItem("Tuesday");
        }

        public List<TaskItem> taskItems { get; set; }
        public static List<TaskItem> GetItem(string searchDay)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("TaskList");
            if (database.ListCollectionNames().ToList().Exists(x => x == searchDay))
            {
                if (string.IsNullOrEmpty(searchDay))
                {
                    return null;
                }
                else
                {
                    var collection = database.GetCollection<TaskListDB>(searchDay);
                    List<TaskListDB> document = collection.Find(x => true).ToList();

                    //TaskListDB document = collection.Find(x => true).FirstOrDefault();
                    var list = new List<TaskItem>();
                    foreach (var item in document)
                    {
                        list.AddRange(item.taskList);
                    }
                    return list;
                }
            }
            else
            {
                return null;
            }

        }

        public void AddItemToDB(string day)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("TaskList");
            var collection = database.GetCollection<TaskListDB>(day);
            if (database.ListCollectionNames().ToList().Exists(x => x == day))
            {
                collection.ReplaceOne(x => true, new TaskListDB(taskItems));
            }
            else
            {
                collection.InsertOne(new TaskListDB(taskItems));
            }

        }

        public void AddNewTask(string newTask)
        {
            taskItems.Add(new TaskItem(newTask));
        }
    }
}
