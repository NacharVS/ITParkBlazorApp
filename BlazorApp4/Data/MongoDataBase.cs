using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class MongoDataBase
    {
        public MongoDataBase(List<User> user)
        {
            this.user = user;
        }
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        [BsonElement("ListOfTasks")]
        public List<User> user { get; set; }
        //public static List<User> GetUnitList()
        //{
        //    var client = new MongoClient("mongodb://localhost");
        //    var database = client.GetDatabase("Blazor");
        //    var collection = database.GetCollection<User>("Users");
        //    var listUnitsFromDB = collection.Find(x => true).ToList();
        //    List<User> listToReturn = new List<User>();
        //    foreach (var item in listUnitsFromDB)
        //    {
        //        listToReturn.Add(item.Name);
        //    }
        //    return listToReturn;
        //}
        public static List<User> GetUserList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Blazor");
            var collection = database.GetCollection<User>("Users");
            var TaskListFromDB = collection.Find(x => true).ToList();
            List<User> listToReturn = new List<User>();
            listToReturn.AddRange(collection.Find(x => true).FirstOrDefault().user);
            var list = new List<User>();
            foreach (var item in listToReturn)
            {
                list.AddRange(item.user);
            }
            return list;
            //return listToReturn;
        }

        public static void AddUser(string login, string surname, string profession, string email, string phone, string password) //Добавление в БД
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Blazor");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(new User(login, surname, profession, email, phone, password));
        }
        public static User Authorization(string name, string password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Blazor");
            var collection = database.GetCollection<User>("Users");

            var item = collection.Find(x => x.Name == name && x.PhoneNumber == password).FirstOrDefault();
            // Передаем в метод троки их тега input и если найдено соответсвие по 2м параметрам, метод вернет объект, в противном случае вернет null.
            return item;
        }
        public static string FindUserName(string userName)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Blazor");
            var collection = database.GetCollection<User>("Users");
            var foundedUser = collection.Find(x => x.Name == userName).FirstOrDefault();
            if (foundedUser == null)
            {
                return null;
            }
            else
            {
                string foundedName = foundedUser.Name;
                return foundedName;
            }
        }

        public static string FindUserPassword(string password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Blazor");
            var collection = database.GetCollection<User>("Users");
            var item = collection.Find(x => x.Password == password).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            else
            {
                string foundedPassword = item.Password;
                return foundedPassword;
            }
        }
        public static List<User> GetUser()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Blazor");
            if (database.ListCollectionNames().ToList().Exists(x => true))
            {
                var collection = database.GetCollection<User>("Users");
                List<User> document = collection.Find(x => true).ToList();

                //MongoDataBase document = collection.Find(x => true).FirstOrDefault();
                var list = new List<User>();
                foreach (var item in document)
                {
                    list.AddRange(item.user);
                }
                return list;

                //List<User> list = new List<User>();
                //    list.AddRange(collection.Find(x => true).FirstOrDefault().user);
                //    return list;

            }
            else
            {
                return null;
            }
        }
    }
}
