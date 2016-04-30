using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using Assignment_2.AuthenticateService;

namespace Assignment_2
{
    public partial class ProductDetails : Page
    {
        private readonly Assignment2Entities _db = new Assignment2Entities();
        private AlgonquinCollegeUser _currentUser;
        private Product _product = new Product();
        List<Product> _sessionProducts;
        protected void Page_Load(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(Request.QueryString["ProductId"]);
            _sessionProducts = (List<Product>)Session["Products"] ?? new List<Product>();
            _currentUser = (AlgonquinCollegeUser) HttpContext.Current.Session["CurrentUser"];
            _product = _db.Products.Single(p => p.ProductId == productId);
            
            if (productId == 0)
                Response.Redirect("Default.aspx");

            leaveACommentSection.Visible = _currentUser != null;
            addToCartButton.Visible = _currentUser != null;
            nameBox.Text = _product.Name;
            priceBox.Text += _product.Price.ToString(CultureInfo.CurrentCulture);
            if (_product.IsOnSale)
            {
                priceBox.Style.Value = "text-decoration:line-through; color: grey";
                salePriceBox.Visible = true;
                salePriceBox.Text += _product.SalePrice.ToString(CultureInfo.CurrentCulture);   
            }

            shortDescriptionBox.Text = _product.ShortDescription;
            longDescriptionBox.Text = _product.LongDescription;

            if (_sessionProducts.Contains(_product))
            {
                addToCartButton.Enabled = false;
                addToCartButton.BackColor = Color.DarkRed;
                addToCartButton.Text = "Already in cart!";
                addToCartButton.ForeColor = Color.White;
            }

            commentGridView.DataSource = _db.Comments.Where(c => c.ProductId == productId).ToList();
            commentGridView.DataBind();
        }

        protected void AddToCart(object sender, EventArgs e)
        {            
            _sessionProducts.Add(_product);
            HttpContext.Current.Session["Products"] = _sessionProducts;
            Response.Redirect(Request.RawUrl);
        }

        protected void AddNewComment(object sender, EventArgs e)
        {
            var badWords = _db.BadWords.Select(bw => bw.Word.ToLower()).ToList();
            var cleanedText = string.Join(" ", commentTextBox.Text.Split(' ').Select(w => badWords.Contains(w.ToLower()) ? String.Format("{0}", "****") : w));
            var comment = new Comment
            {
                CommentAuthor = _currentUser.UserName,
                CommentText = cleanedText,
                CreatedDate = DateTime.Now,
                ProductId = _product.ProductId
            };
            _db.Comments.Add(comment);
            _db.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }
    }
}