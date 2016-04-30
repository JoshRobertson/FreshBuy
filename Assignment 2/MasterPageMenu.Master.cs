using System;
using System.Linq;
using System.Web;

using Assignment_2.AuthenticateService;

namespace Assignment_2
{
    public partial class MasterPageMenu : MasterPage
    {
        private readonly Assignment2Entities _db = new Assignment2Entities();
        private AlgonquinCollegeUser _currentUser = (AlgonquinCollegeUser)HttpContext.Current.Session["CurrentUser"];

        protected new void Page_Load(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                adminItem.Visible = (bool)HttpContext.Current.Session["IsAdmin"];
                nameHolder.InnerHtml = "<a href=\"#\">Hello, " + _currentUser.FirstName + " " + _currentUser.LastName + "</a>";
            }

            nameHolder.Visible = _currentUser != null;
            loginButton.Visible = _currentUser == null;
            logoutButton.Visible = _currentUser != null;
            cartItem.Visible = _currentUser != null;
            /*loginItem.InnerHtml = "<button class='btn btn-primary' ID='logoutButton' type='button' runat='server' onclick='LogOut' style='padding: 15px;'>Log Out</button>";*/

            if (!IsPostBack)
            {
                foreach (var cat in _db.Categories.ToList())
                {
                    categoryDropdown.InnerHtml += "<li><a href='CategoryDetails.aspx?CategoryId=" + cat.CategoryId + "'>" + cat.Name + "</a></li>";
                }
            }
        }

        protected void LogOut(object sender, EventArgs e)
        {
            _currentUser = null;
            //HttpContext.Current.Session.Remove("CurrentUser");
            HttpContext.Current.Session.RemoveAll();
            Response.Redirect(Request.RawUrl);
        }

        protected void LogIn(object sender, EventArgs e)
        {
            HttpContext.Current.Session["ReturnURL"] = Server.UrlEncode(Request.Url.PathAndQuery);
            Response.Redirect("Login.aspx");
        }
    }
}