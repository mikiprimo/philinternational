using System;
using System.Configuration;
using Philinternational.Layers;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace Philinternational.Management {
    public partial class News : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                NewsConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
                NewsConnector.SelectCommand = ConfigurationManager.AppSettings["SelectNews"].ToString();
            }
        }

        protected static string ConvertiStato(int value) {
            return Commons.GetStato(value);
        }

        protected static Boolean ConvertiStatoBoolean(int value) {
            return Commons.GetStatoBoolean(value);
        }

        //[WebMethod]
        //public static void ChangeStatus(int obj) {

        //}

        protected void chkStatus_OnDataBinding(object sender, EventArgs e) {
            ((CheckBox)sender).Text = ConvertiStato((int)Eval("stato"));
            ((CheckBox)sender).Checked = ConvertiStatoBoolean((int)Eval("stato"));
        }

        protected void chkStatus_OnCheckedChanged(object sender, EventArgs e) {
            CheckBox chk = ((CheckBox)sender);
            String idNews = ((CheckBox)sender).Attributes["MyIDNews"].ToString();
            NewsGateway.UpdateNewsStateById(idNews, chk.Checked ? 1 : 0);
        }
    }
}