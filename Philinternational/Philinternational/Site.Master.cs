using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           

            //Verifica della visualizzazione Menu left
            if (AccountLayer.IsLogged())
            {
                this.menuLeftAdministration.Visible = AccountLayer.IsAdministrator();
                this.menuLeftAuthenticated.Visible = AccountLayer.IsLogged();
                try
                {
                    ((Label)this.HeadLoginView.FindControl("LoginName")).Text = ((logInfos)Session["log"]).nome;
                }
                catch (Exception)
                {
                    RefreshUnloggedUser();
                }
            }
        }

        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            RefreshUnloggedUser();
        }

        private void RefreshUnloggedUser()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}
