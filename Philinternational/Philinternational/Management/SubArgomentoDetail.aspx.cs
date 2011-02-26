using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Management {
    public partial class SubArgomentoDetail : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!((logInfos)HttpContext.Current.Session["log"]).IsAdmin) Response.Redirect("~/Default.aspx");
            if (!IsPostBack) {
                this.selectedParagrafoID = Convert.ToInt32(Request["QueryPar"]);
                this.selectedArgomentoID = Convert.ToInt32(Request["QueryArg"]);
            }
        }

        public Int32 selectedArgomentoID {
            get { return ((Int32)ViewState["selectedArgomentoID"]); }
            set { ViewState.Add("selectedArgomentoID", value); }
        }

        public Int32 selectedParagrafoID {
            get { return ((Int32)ViewState["selectedParagrafoID"]); }
            set { ViewState.Add("selectedParagrafoID", value); }
        }

        protected void conferma(object sender, EventArgs e) {
            paragSubArgomentoEntity MySubArgument = new paragSubArgomentoEntity();
            Boolean esito = false;

            MySubArgument.id = Layers.ConnectionGateway.CreateNewIndex("idsub_argomento", "paragrafo_subargomento");
            MySubArgument.idargomento = this.selectedArgomentoID;
            MySubArgument.descrizione = txtDescrizione.Text;
            MySubArgument.state = new Stato(Commons.GetCheckedState(chkStato.Checked), "");

            esito = ParagrafoGateway.InsertSubArgomento(MySubArgument);
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