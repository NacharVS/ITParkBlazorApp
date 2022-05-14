using MongoDB.Bson;
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
            SurName = surname;
            PhoneNumber = phoneNumber;
        }
        public ObjectId _id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
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

        public static List<User> GetListFromDb()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Blazor");
            var collection = database.GetCollection<User>("Users");
            
            return collection.Find(x => true).ToList();
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
    }
}
