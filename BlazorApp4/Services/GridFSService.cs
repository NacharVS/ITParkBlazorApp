using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Services
{
    public class GridFSService
    {
        const string conectionString = "mongodb://localhost";
        public void UploadImageToDB()
        {
            MongoClient client = new MongoClient(conectionString);
            IMongoDatabase database = client.GetDatabase("Images");
            IGridFSBucket gridFs = new GridFSBucket(database);

            using(FileStream fs = new FileStream("E:/repos/ITParkBlazorApp/BlazorApp4/wwwroot/boot.jpg", FileMode.Open))
            {
                gridFs.UploadFromStream("qqq.jpg", fs);
            }
        }

        public void DownloadImageToWWWRoot()
        {
            MongoClient client = new MongoClient(conectionString);
            IMongoDatabase database = client.GetDatabase("Images");
            IGridFSBucket gridFs = new GridFSBucket(database);

            using (FileStream fs = new FileStream("C:/Users/KTITS/AppData/temp", FileMode.CreateNew))
            {
                gridFs.DownloadToStreamByName("newBoot.jpg", fs);
            }
        }
    }
}
