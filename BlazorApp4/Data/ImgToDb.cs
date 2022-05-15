using MongoDB.Bson;
using MongoDB.Driver;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BlazorApp4.Data
{
    public class ImgToDb
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public byte[] img;

        public ImgToDb(string name, byte[] img)
        {
            Name = name;
            this.img = img;
        }

        public static void AddToDB(ImgToDb img)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Images");
            var collection = database.GetCollection<ImgToDb>("Image");
            collection.InsertOne(img);
        }

        //public Bitmap GetImage()
        //{
        //    //MemoryStream stream = new MemoryStream(img);
        //    //return (Bitmap)Image.FromStream(stream);
        //}

    }
}
