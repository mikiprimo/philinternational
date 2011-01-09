using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Management {
    public partial class AstaDetail : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnConferma_Click(object sender, EventArgs e) {
            astaEntity MyAsta = new astaEntity();
            Boolean esito = false;

            MyAsta.id = Layers.ConnectionGateway.CreateNewIndex("idasta", "asta_elenco");
            MyAsta.data_fine = DateTime.Parse(txtDataFine.Text);
            MyAsta.state = new Stato(Commons.GetCheckedState(chkStatus.Checked), "");

            esito = AsteGateway.InsertArgomento(MyAsta);
        }

        protected void calDataFine_SelectionChanged(object sender, EventArgs e) {
            Calendar cal = ((Calendar)sender);
            txtDataFine.Text = String.Format("{0:dd/MM/yyyy}", cal.SelectedDate);
        }

        protected void pulisci(object sender, EventArgs e) {
            txtDataFine.Text = "";
            chkStatus.Checked = false;
        }

        protected void comeBack(object sender, EventArgs e) {
            Response.Redirect("Aste.aspx");
        }
    }
}