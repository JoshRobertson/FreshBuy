using System;
using System.Linq;
using System.Web;

namespace Assignment_2
{
    public partial class CategoryDetails : System.Web.UI.Page
    {
        private readonly Assignment2Entities _db = new Assignment2Entities();
        private object _currentUser = null;
        private bool _loggedIn = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
            _currentUser = HttpContext.Current.Session["CurrentUser"];

            if (_currentUser != null)
                _loggedIn = HttpContext.Current.User.Identity.IsAuthenticated;

            if (categoryId == 0)
                Response.Redirect("Default.aspx");

            productGridView.DataSource = _db.Products.Where(c => c.CategoryId == categoryId).ToList();
            productGridView.DataBind();
        }
    }
}