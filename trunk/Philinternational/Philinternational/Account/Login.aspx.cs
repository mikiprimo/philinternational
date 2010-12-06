using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Gateway;

namespace Philinternational.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (AccountFacilities.Authenticate(LoginUser.UserName, LoginUser.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, true);
            }
        }
    }
}