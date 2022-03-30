using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class User
    {
        public User(string login, string phoneNumber)
        {
            Login = login;
            PhoneNumber = phoneNumber;
        }

        public User(string login, string name, string surname, string phoneNumber)
        {
            Login = login;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }


        public static List<User> GetList()
        {
            List<User> listToReturn = new List<User>();
            listToReturn.Add(new User("Bob", "Bob", "Smith", "987654321"));
            listToReturn.Add(new User("Bob", "John", "Marlou", "789465413"));
            listToReturn.Add(new User("Bob", "Ivan", "Ivanov", "987654321"));
            listToReturn.Add(new User("Bob", "Petr", "Petrov", "987654321"));
            listToReturn.Add(new User("Bob", "Andrey", "Andreev", "987654321"));
            listToReturn.Add(new User("Bob", "Georgiy", "Fedorov", "987654321"));
            return listToReturn;
        }

        public static List<User> GetDemoList()
        {
            List<User> listToReturn = new List<User>();
            listToReturn.Add(new User("Bob", "987654321"));
            listToReturn.Add(new User("Ivan", "987654321"));
            listToReturn.Add(new User("Semen", "987654321"));
            return listToReturn;
        }

        public static void AddUser(User name) //Добавление в БД
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Regist");
            var collection = database.GetCollection<User>("Login");
            collection.InsertOne(name);
        }
    }
}
