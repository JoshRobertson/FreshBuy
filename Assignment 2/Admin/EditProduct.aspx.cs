using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.AuthenticateService;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Assignment_2.Admin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private readonly Assignment2Entities _db = new Assignment2Entities();
        private AlgonquinCollegeUser _currentUser;
        private Product _product;
        protected void Page_Load(object sender, EventArgs e)
        {
            _currentUser = (AlgonquinCollegeUser)HttpContext.Current.Session["CurrentUser"];

            if (_currentUser == null || (bool)HttpContext.Current.Session["IsAdmin"] == false)
                Response.Redirect("/assignment2/Default.aspx");

            var productId = Request.QueryString["ProductId"];

            _product = _db.Products.Single(c => c.ProductId.ToString() == productId);

            if (!IsPostBack)
            {
                nameBox.Text = _product.Name;
                categoryDropDown.DataSource = _db.Categories.Select(c => c.Name).ToList();
                categoryDropDown.DataBind();
                var categoryName = _db.Categories.Where(c => c.CategoryId == _product.CategoryId).Select(u => u.Name).First();
                categoryDropDown.SelectedValue = categoryDropDown.Items.FindByText(categoryName).Value;
                descriptionBox.Text = _product.ShortDescription;
                longDescriptionTextBox.Text = _product.LongDescription;
                priceBox.Text = _product.Price.ToString(CultureInfo.CurrentCulture);
                salePriceBox.Text = _product.SalePrice.ToString(CultureInfo.CurrentCulture);
                isOnSaleBox.Checked = _product.IsOnSale;
            }
        }

        protected void EditProd(object sender, EventArgs e)
        {
            if (fileUpload.HasFile == false)
                return;

            try
            {
                CloudStorageAccount storageAccount =
                    CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("filestorage");
                container.CreateIfNotExists();
                CloudBlockBlob blockBlob =
                    container.GetBlockBlobReference(Path.GetFileName(fileUpload.PostedFile.FileName));

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

                _product.Name = nameBox.Text;
                _product.CategoryId = _db.Categories.Single(c => c.Name == categoryDropDown.Text).CategoryId;
                _product.ShortDescription = descriptionBox.Text;
                _product.LongDescription = longDescriptionTextBox.Text;
                _product.Price = decimal.Parse(priceBox.Text);
                _product.SalePrice = decimal.Parse(salePriceBox.Text);
                _product.IsOnSale = isOnSaleBox.Checked;
                _product.FileId = newFile.FileId;
                _db.Entry(_product).State = EntityState.Modified;
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