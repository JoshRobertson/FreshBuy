using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.AuthenticateService;

namespace Assignment_2
{
    public partial class ThankYou : Page
    {
        private AlgonquinCollegeUser _currentUser;
        List<Product> _sessionProducts;
        protected void Page_Load(object sender, EventArgs e)
        {
            _sessionProducts = (List<Product>)Session["Products"] ?? new List<Product>();
            _currentUser = (AlgonquinCollegeUser)HttpContext.Current.Session["CurrentUser"];

            if (_currentUser == null)
                Response.Redirect("/assignment2/Default.aspx");

            if (_sessionProducts.Count > 0)
                HttpContext.Current.Session.Remove("Products");

        }
    }
}