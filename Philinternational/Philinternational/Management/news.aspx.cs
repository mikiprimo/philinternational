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
                BindData();
            }
        }

        private void BindData() {
            NewsConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            NewsConnector.SelectCommand = ConfigurationManager.AppSettings["SelectNews"].ToString();
            repeaterNews.DataBind();
        }

        //GESTIONE STATO
        protected void chkStatus_OnDataBinding(object sender, EventArgs e) {
            CheckBox chk = ((CheckBox)sender);
            chk.Checked = Commons.GetStatoBoolean((int)Eval("stato"));
            chk.Text = Commons.GetStatoDescription((int)Eval("stato"));
        }

        protected void chkStatus_OnCheckedChanged(object sender, EventArgs e) {
            CheckBox chk = ((CheckBox)sender);
            String idNews = chk.Attributes["MyIDNews"].ToString();
            NewsGateway.UpdateNewsStateById(idNews, chk.Checked ? 1 : 0);
            chk.Text = Commons.GetStatoDescription(chk.Checked ? 1 : 0);
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
            BindData();
        }
    }
}