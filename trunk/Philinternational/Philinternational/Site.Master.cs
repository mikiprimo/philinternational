using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Philinternational.Account;
using System.Web.Security;

namespace Philinternational
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica della visualizzazione Menu left
            if (AccountFacilities.IsLogged())
            {
                this.menuLeftAdministration.Visible = AccountFacilities.IsAdministrator();
                this.menuLeftAuthenticated.Visible = AccountFacilities.IsLogged();
            }
        }

        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}
