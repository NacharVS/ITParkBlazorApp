using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BlazorApp4.Data
{
    public class User
    {
        public User(string surname, string userName, string phoneNamber,string login, string password)
        {
            Surname = surname;
            UserName = userName;
            PhoneNamber = phoneNamber;
            Login = login;
            Password = password;
        }
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId  Id { get; set; }
        public string Surname { get/* => _surname*/; set /*=> _surname = value*/; }
        [BsonElement("UserName")]
        public  string UserName { get /*=> _userName*/; set /*=> _userName = value*/; } 
        public string PhoneNamber { get /*=> _phoneNamber*/; set /*=> _phoneNamber = value*/; }
        public   string Login { get /*=> _login*/; set/* => _login = value*/; }
        public  string Password { get /*=> _login*/; set/* => _login = value*/; }
        public static List<User> GetList()
        {
            List<User> listToReturn = new List<User>();

            listToReturn.Add(new User("Zakharova", "Darya", "216546", "Darya", "5246876"));
            listToReturn.Add(new User("Zakharov", "Denis", "216546", "Denis", "5246876"));
            listToReturn.Add(new User("Zakharov", "Boris", "216546", "Boris", "5246876" ));
            return listToReturn;    
        }
       
        public static void AddMongoDB(User user)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlazorRegistration");
            var collection = database.GetCollection<User>("BlazorRegistration");
            collection.InsertOne(user);
        }
       
        public static List<User> GetListDB()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlazorRegistration");
            var collection = database.GetCollection<User>("BlazorRegistration");
            return collection.Find(x => true).ToList();
        }

        public static User GetLoginUser(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlazorRegistration");
            var collection = database.GetCollection<User>("BlazorRegistration");
            var FoundUser = collection.Find(x => x.Login == login).FirstOrDefault();
          
            return FoundUser;
        }

        public static User GetPasswordUser(string password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlazorRegistration");
            var collection = database.GetCollection<User>("BlazorRegistration");
            var FoundUser = collection.Find(x => x.Password == password).FirstOrDefault();
            if (FoundUser == null)
            {
                return null;
            }
            else
                return FoundUser;
        }
        //private static string _surname;
        //private static string _userName;
        //private static string _phoneNamber;
        //private static string _login;
        //private static string _password;
        //public User(string phoneNamber, string login)
        //{
        //    PhoneNamber = phoneNamber;
        //    Login = login;
        //}
        //public static List<User> GetDemoList()
        //{
        //    List<User> listToReturn = new List<User>();

        //    listToReturn.Add(new User("216546", "Darya"));
        //    listToReturn.Add(new User("216546", "Denis"));
        //    listToReturn.Add(new User("216546", "Boris"));
        //    return listToReturn;
        //}

    }
}
