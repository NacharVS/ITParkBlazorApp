using MongoDB.Driver;

namespace BlazorApp4.Data
{
    public class MongoDB
    {
        public static void AddToDataBase(User user)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlazorRegistration");
            var collection = database.GetCollection<User>("BlazorRegistration");
            collection.InsertOne(user);
        }

    }
}
