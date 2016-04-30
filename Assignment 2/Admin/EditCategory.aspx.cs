using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using Assignment_2.AuthenticateService;

namespace Assignment_2.Admin
{
    public partial class EditCategory : Page
    {
        private readonly Assignment2Entities _db = new Assignment2Entities();
        private AlgonquinCollegeUser _currentUser;
        private Category _category;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _currentUser = (AlgonquinCollegeUser)HttpContext.Current.Session["CurrentUser"];

            if (_currentUser == null || (bool)HttpContext.Current.Session["IsAdmin"] == false)
                Response.Redirect("/assignment2/Default.aspx");

            var categoryId = Request.QueryString["CategoryId"];

            _category = _db.Categories.Single(c => c.CategoryId.ToString() == categoryId);

            if (!IsPostBack)
            {
                categoryTextBox.Text = _category.Name;
            }
        }

        protected void EditCat(object sender, EventArgs e)
        {
            _category.Name = categoryTextBox.Text;
            _db.Entry(_category).State = EntityState.Modified;
            _db.SaveChanges();
            Response.Redirect("Default.aspx");
        }
    }
}