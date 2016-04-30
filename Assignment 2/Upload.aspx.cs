using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure;
using System.IO;
using Microsoft.Azure;

namespace Assignment_2
{
    public partial class Upload : System.Web.UI.Page
    {
        private readonly Assignment2Entities db = new Assignment2Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile == false)
                return;

            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("filestorage");
                container.CreateIfNotExists();
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(Path.GetFileName(fileUpload.PostedFile.FileName));

                if (blockBlob.Exists())
                    blockBlob.Delete();

                using (MemoryStream memoryStream = new MemoryStream(fileUpload.FileBytes))
                {
                    blockBlob.UploadFromStream(memoryStream);
                }
                var newFile = new File
                {
                    BlobFileName = Path.GetFileName(fileUpload.PostedFile.FileName),
                    ContentType = fileUpload.PostedFile.ContentType
                };


                db.Files.Add(newFile);
                db.SaveChanges();

                Response.Redirect("Default.aspx");
            }
            catch
            {
                // an error occured
            }
        }
    }
}