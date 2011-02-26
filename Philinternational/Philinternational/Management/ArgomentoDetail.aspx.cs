using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Management {
    public partial class ArgomentoDetail : System.Web.UI.Page {

        public Int32 selectedParagrafoID {
            get { return ((Int32)ViewState["selectedParagrafoID"]); }
            set { ViewState.Add("selectedParagrafoID", value); }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!((logInfos)HttpContext.Current.Session["log"]).IsAdmin) Response.Redirect("~/Default.aspx");
            if (!IsPostBack) {
                this.selectedParagrafoID = Convert.ToInt32(Request["Query"]);
            }
        }

        protected void conferma(object sender, EventArgs e) {
            paragArgomentoEntity MyArgument = new paragArgomentoEntity();
            Boolean esito = false;

            MyArgument.id = Layers.ConnectionGateway.CreateNewIndex("idargomento", "paragrafo_argomento");
            MyArgument.idparagrafo = this.selectedParagrafoID;
            MyArgument.descrizione = txtDescrizione.Text;
            MyArgument.state = new Stato(Commons.GetCheckedState(chkStato.Checked), "");


            esito = ParagrafoGateway.InsertArgomento(MyArgument);
        }

        protected void pulisci(object sender, EventArgs e) {
            txtDescrizione.Text = "";
            chkStato.Checked = false;
        }

        protected void comeBack(object sender, EventArgs e) {
            Response.Redirect("ArgoAndSubArgomento.aspx?Query=" + this.selectedParagrafoID.ToString());
        }
    }
}