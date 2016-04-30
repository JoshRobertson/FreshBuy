using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Assignment_2.AuthenticateService;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Assignment_2.Admin
{
    public partial class AddProduct :Page
    {
        private readonly Assignment2Entities _db = new Assignment2Entities();
        private AlgonquinCollegeUser _currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            _currentUser = (AlgonquinCollegeUser)HttpContext.Current.Session["CurrentUser"];

            if (_currentUser == null || (bool)HttpContext.Current.Session["IsAdmin"] == false)
                Response.Redirect("/assignment2/Default.aspx");

            if (!IsPostBack)
            {
                categoryDropDown.DataSource = _db.Categories.Select(c => c.Name).ToList();
                categoryDropDown.DataBind();
            }
        }

        protected void CreateProduct(object sender, EventArgs e)
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


                _db.Files.Add(newFile);
                _db.SaveChanges();

            
            
            var newProduct = new Product
            {
                Name = nameBox.Text,
                CategoryId = _db.Categories.Single(c => c.Name == categoryDropDown.Text).CategoryId,
                ShortDescription = descriptionBox.Text,
                LongDescription = longDescriptionTextBox.Text,
                Price = decimal.Parse(priceBox.Text),
                SalePrice = decimal.Parse(salePriceBox.Text),
                IsOnSale = isOnSaleBox.Checked,
                FileId = newFile.FileId,

            };
            _db.Products.Add(newProduct);
            _db.SaveChanges();
            Response.Redirect("Default.aspx");


            }
            catch
            {
                // an error occured
            }
        }
    }
}