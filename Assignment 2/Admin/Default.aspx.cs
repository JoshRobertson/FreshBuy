using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.AuthenticateService;

namespace Assignment_2.Admin
{
    public partial class Default : Page
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
                cateogryGridView.DataSource = _db.Categories.ToList();
                cateogryGridView.DataBind();
                productGridView.DataSource = _db.Products.ToList();
                productGridView.DataBind();
            }
        }

        protected void DeleteCategory(object sender, GridViewDeleteEventArgs e)
        {
            if (_db.Categories.Any())
            {
                var cat = _db.Categories.ToList()[e.RowIndex];
                var prods = _db.Products.Where(p => p.CategoryId == cat.CategoryId).ToList();
                var comments = new List<Comment>();
                foreach (var product in prods)
                {
                    var com = _db.Comments.Where(c => c.ProductId == product.ProductId);
                    comments.AddRange(com);
                }
                //var comments = _db.Comments.Where(c => prods.Contains(c.Product)).ToList();
                _db.Comments.RemoveRange(comments);
                _db.Products.RemoveRange(prods);
                _db.Categories.Remove(cat);
                _db.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void DeleteProduct(object sender, GridViewDeleteEventArgs e)
        {
            if (_db.Products.Any())
            {
                var prod = _db.Products.ToList()[e.RowIndex];
                var comments = _db.Comments.Where(c => c.ProductId == prod.ProductId).ToList();
                _db.Comments.RemoveRange(comments);
                _db.Products.Remove(prod);
                _db.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}