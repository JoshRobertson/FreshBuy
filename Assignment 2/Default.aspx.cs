using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2
{
    public partial class Default : Page
    {
        private readonly Assignment2Entities _db = new Assignment2Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!_db.Products.Any())
                    productGridView.EmptyDataText = "Currently, there are no products for sale";
                productGridView.DataSource = _db.Products.ToList();
                productGridView.DataBind();                
            }
        }

        protected void PgvRefreshPage(object sender, GridViewPageEventArgs e)
        {
            productGridView.PageIndex = e.NewPageIndex;
            productGridView.DataSource = _db.Products.ToList();
            productGridView.DataBind();
        }
    }
}