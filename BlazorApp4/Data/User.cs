using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorApp4.Data
{
    public partial class User
    {
        [BsonIgnoreIfDefault]
        ObjectId _id;
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public User(string name, string surName, string profession, string email, string phoneNumber, string password)
        {
            Name = name;
            SurName = surName;
            Profession = profession;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        //public string Name;
        //public string SurName;
        //public string Profession;
        //public string Email;
        //public string PhoneNumber;
        //public string Password;
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Profession { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public List<User> user { get; set; }

        //public static User Admin()
        //{
        //    User admin = new User("Admin", "admin");
        //    return admin;
        //}

        //public static List<User> GetUserList()
        //{
        //    List<User> listToReturn = new List<User>();
        //    listToReturn.Add(new User("Oleg", "Oleg"));
        //    listToReturn.Add(new User("Andrey", "Andrey"));
        //    listToReturn.Add(new User("Ilnaz", "Ilnaz"));

        //    return listToReturn;
        //}
    }
}

