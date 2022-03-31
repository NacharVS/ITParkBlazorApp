using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BlazorApp4.Data
{
    public class User
    {
        //private static string _surname;
        //private static string _userName;
        //private static string _phoneNamber;
        //private static string _login;

        public User(string phoneNamber, string login)
        {
            PhoneNamber = phoneNamber;
            Login = login;
        }

        public User(string surname, string userName, string phoneNamber, string login)
        {
            Surname = surname;
            UserName = userName;
            PhoneNamber = phoneNamber;
            Login = login;
        }
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId  Id { get; set; }
        public string Surname { get/* => _surname*/; set /*=> _surname = value*/; }
        public string UserName { get /*=> _userName*/; set /*=> _userName = value*/; } 
        public string PhoneNamber { get /*=> _phoneNamber*/; set /*=> _phoneNamber = value*/; }
        public string Login { get /*=> _login*/; set/* => _login = value*/; }

        public static List<User> GetList()
        {
            List<User> listToReturn = new List<User>();

            listToReturn.Add(new User("Zakharova", "Darya", "216546", "Darya"));
            listToReturn.Add(new User("Zakharov", "Denis", "216546", "Denis"));
            listToReturn.Add(new User("Zakharov", "Boris", "216546", "Boris"));
            return listToReturn;    
        }
        public static List<User> GetDemoList()
        {
            List<User> listToReturn = new List<User>();

            listToReturn.Add(new User("216546", "Darya"));
            listToReturn.Add(new User("216546", "Denis"));
            listToReturn.Add(new User("216546", "Boris"));
            return listToReturn;
        }
        public static void AddMongoDB(User user)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlazorRegistration");
            var collection = database.GetCollection<User>("BlazorRegistration");
            collection.InsertOne(user);
        }
        
    }
}
