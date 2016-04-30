using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Assignment_2.AuthenticateService;

namespace Assignment_2.Admin
{
    public partial class AddCategory : Page
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
                categoriesListBox.DataSource = _db.Categories.Select(cat => cat.Name).ToList();
                categoriesListBox.DataBind();
                categoriesListBox.Rows = categoriesListBox.Items.Count;
            }
        }

        protected void AddCat(object sender, EventArgs e)
        {
            var newCategory = new Category
            {
                Name = addCategoryBox.Text,
            };
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            categoriesListBox.DataBind();
            Response.Redirect(Request.RawUrl);
        }
    }
}