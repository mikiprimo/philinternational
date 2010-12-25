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

        //GESTIONE STATO
        protected void chkStatus_OnDataBinding(object sender, EventArgs e) {
            ((CheckBox)sender).Text = ConvertiStato((int)Eval("stato"));
            ((CheckBox)sender).Checked = ConvertiStatoBoolean((int)Eval("stato"));
        }

        protected void chkStatus_OnCheckedChanged(object sender, EventArgs e) {
            CheckBox chk = ((CheckBox)sender);
            String idNews = ((CheckBox)sender).Attributes["MyIDNews"].ToString();
            NewsGateway.UpdateNewsStateById(idNews, chk.Checked ? 1 : 0);
        }

        //CANCELLAZIONE NEWS
        protected void btnEraseSelectedNews_OnClick(object sender, EventArgs e) {
            List<String> NewsIdToBeErased = new List<String>();
            foreach (RepeaterItem item in repeaterNews.Items) { 
                CheckBox chk = ((CheckBox)item.FindControl("chkErase"));
                if(chk.Checked) 
                {
                    String MyIDNewsToErase = chk.Attributes["MyIDNewsToErase"].ToString();
                    NewsIdToBeErased.Add(MyIDNewsToErase);
                }
            }
            if (NewsIdToBeErased.Count > 0) { 
                //Prevedere un dato di ritorno per il controllo delle avvenute cancellazioni
                NewsGateway.DeleteNewsByIdList(NewsIdToBeErased); 
            }
        }
    }
}