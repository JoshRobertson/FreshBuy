using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.AuthenticateService;

namespace Assignment_2
{
    public partial class Cart : Page
    {
        private AlgonquinCollegeUser _currentUser;
        List<Product> _sessionProducts;
        protected void Page_Load(object sender, EventArgs e)
        {
            _sessionProducts = (List<Product>)Session["Products"] ?? new List<Product>();
            _currentUser = (AlgonquinCollegeUser)HttpContext.Current.Session["CurrentUser"];

            if (_currentUser == null)
                Response.Redirect("Default.aspx");

            if (_sessionProducts.Count == 0)
            {
                 cartGridView.EmptyDataText = "Currently, there are no products in your cart";
                buyNowButton.Enabled = false;
            }

            

            if (!IsPostBack)
            {
                cartGridView.DataSource = _sessionProducts;
                cartGridView.DataBind();
                totalLabel.Text += _sessionProducts.Where(p => p.IsOnSale).Sum(p => p.Price) + _sessionProducts.Where(p => p.IsOnSale == false).Sum(p => p.SalePrice);
            }
        }

        protected void RemoveProduct(object sender, GridViewDeleteEventArgs e)
        {
            if (!_sessionProducts.Any()) return;
            Product prod = _sessionProducts.ToList()[e.RowIndex];
            _sessionProducts.Remove(prod);
            HttpContext.Current.Session["Products"] = _sessionProducts;
            Response.Redirect(Request.RawUrl);
        }
    }
}