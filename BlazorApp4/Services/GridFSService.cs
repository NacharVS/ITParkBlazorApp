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
        FileInfo file;
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

        public async Task UploadImageToDBAsync(Stream stream)
        {
            MongoClient client = new MongoClient(conectionString);
            IMongoDatabase database = client.GetDatabase("Images");
            IGridFSBucket gridFs = new GridFSBucket(database);
            await gridFs.UploadFromStreamAsync("sss.jpg", stream);

        }

        public void DownloadImageToWWWRoot(string filename)
        {
            MongoClient client = new MongoClient(conectionString);
            IMongoDatabase database = client.GetDatabase("Images");
            IGridFSBucket gridFs = new GridFSBucket(database);

            using (Stream fs = new FileStream($"E:/repos/ITParkBlazorApp/BlazorApp4/wwwroot/{filename}.jpg", FileMode.CreateNew))
            {
                gridFs.DownloadToStreamByName("qqq.jpg", fs);
                file = new FileInfo("boot.jpg");
                Console.WriteLine(file.DirectoryName);

            }
        }
    }
}
