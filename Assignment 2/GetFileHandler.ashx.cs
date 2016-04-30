using System;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Assignment_2
{
    /// <summary>
    /// Summary description for GetFileHandler
    /// </summary>
    public class GetFileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int fileId = Convert.ToInt32(context.Request["id"]);

            var db = new Assignment2Entities();
            var file = db.Files.FirstOrDefault(f => f.FileId == fileId);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("filestorage");
            container.CreateIfNotExists();
            if (file != null)
            {
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.BlobFileName);

                try
                {
                    Stream fileStream = new MemoryStream();
                    blockBlob.DownloadToStream(fileStream);

                    fileStream.Seek(0, SeekOrigin.Begin);

                    byte[] buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, (int)fileStream.Length);

                    fileStream.Close();

                    context.Response.Clear();
                    context.Response.ContentType = file.ContentType;
                    context.Response.BinaryWrite(buffer);
                }
                catch
                {
                    context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    context.Response.Cache.SetNoStore();
                    context.Response.Cache.SetExpires(DateTime.MinValue);
                    context.Response.StatusCode = 404;
                    context.Response.End();
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}