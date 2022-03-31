using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorApp4.Data
{
    public class User
    {
        public User(string login, string surName, string name, string phoneNumber)
        {
            Login = login;
            SurName = surName;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public User(string login, string phoneNumber)
        {
            Login = login;
            PhoneNumber = phoneNumber;
        }

        public string Login { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }


        public static List<User> GetList()
        {
            List<User> listToReturn = new List<User>();
            listToReturn.Add(new User("Topor7", "Zlobin", "Inokenty", "777"));

            return listToReturn;
        }
        public static List<User> GetDemoList()
        {
            List<User> listToReturn = new List<User>();
            listToReturn.Add(new User("Topor7", "777"));

            return listToReturn;
        }

        public static void AddUser(string login, string surname, string name, string phone) //Добавление в БД
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Blazor");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(new User(login, surname, name, phone));
        }
    }
}
