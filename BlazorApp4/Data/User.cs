using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp4.Data
{
    public class User
    {
        private static string _surname;
        private static string _userName;
        private static string _secondName;
        private static string _login;

        public User(string surnameName, string userName, string secondName, string login)
        {
            SurnameName = surnameName;
            UserName = userName;
            SecondName = secondName;
            Login = login;
        }

        [BsonIgnoreIfDefault]
        public ObjectId  Id { get; set; }
        public string SurnameName { get => _surname; set => _surname = value; }
        public string UserName { get => _userName; set => _userName = value; } 
        public string SecondName { get => _secondName; set => _secondName = value; }
        public string Login { get => _login; set => _login = value; }

    }
}
