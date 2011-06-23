using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Registrazione.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (Philinternational.Layers.AccountLayer.Authenticate(LoginUser.UserName, LoginUser.Password))
            {
                OfferteGateway a = new OfferteGateway();
                String idAnagrafica = ((logInfos)Session["log"]).idAnagrafica.ToString();
                Boolean esito = a.UpdateCarrello(Session.SessionID,idAnagrafica);
                FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, true);
            }
        }
    }
}