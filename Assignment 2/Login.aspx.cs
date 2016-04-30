using System;
using System.Web;
using System.Web.UI.WebControls;
using Assignment_2.AuthenticateService;

namespace Assignment_2
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly AuthenticateServiceSoapClient auth = new AuthenticateServiceSoapClient();
        private AlgonquinCollegeUser currentUser = new AlgonquinCollegeUser();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ValidateUser(object sender, AuthenticateEventArgs e)
        {
            
            currentUser = auth.AuthenticateUser(UserLogin.UserName, UserLogin.Password);

            if (currentUser != null)
            {
                HttpContext.Current.Session["CurrentUser"] = currentUser;
                if (currentUser.UserName.Equals("robe0591") || currentUser.UserName.Equals("antoszj"))
                    HttpContext.Current.Session["IsAdmin"] = true;
                else
                {
                    HttpContext.Current.Session["IsAdmin"] = false;
                }
                var r = Server.UrlDecode(HttpContext.Current.Session["ReturnURL"].ToString());
                Response.Redirect(r);
            }

        }
    }
}