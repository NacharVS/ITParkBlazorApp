using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BlazorApp4
{
    public class User
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;

        public User(string login, string surname, string name, string phoneNumber)
        {
            Login = login;
            Surname = surname;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public User(string login, string phoneNumber)
        {
            Login = login;
            PhoneNumber = phoneNumber;
        }

        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }


        public static List<User> GetList()
        {
            var listToReturn = new List<User>();
            listToReturn.Add(new User("Bob", "Bobson", "Bobby", "222332"));
            listToReturn.Add(new User("Tom", "Tomson", "Tommie", "5566"));
            listToReturn.Add(new User("Danny", "78954"));
            listToReturn.Add(new User("Sam", "01382"));
            return listToReturn;
        }
        public static User GetUser(string login)
        {
            //var client = new MongoClient();
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlasorApp");
            var collection = database.GetCollection<User>("Users");
            return collection.Find(x => x.Login == login).FirstOrDefault();
        }
        public static List<User> GetDemoList()
        {
            //var client = new MongoClient();
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlasorApp");
            var collection = database.GetCollection<User>("Users");
            var list = collection.Find(x => true).ToList();
            return list;
        }
        public static void AddUserToDB(User user)
        {
            //var client = new MongoClient();
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlasorApp");
            var collection = database.GetCollection<User>("Users");
            var list = collection.Find(x => true).ToList();
            collection.InsertOne(user);
        }

    }
}
