using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Philinternational.Styles {
    public partial class Paragrafo : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            BindData();
        }

        private void BindData() {
            ParagrafoConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            ParagrafoConnector.SelectCommand = ConfigurationManager.AppSettings["SelectParagrafi"].ToString();
            gvParagrafi.DataBind();
        }

        protected void gvParagrafi_RowUpdating(object sender, GridViewUpdateEventArgs e) {

        }
    }
}