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
            if (!((logInfos)HttpContext.Current.Session["log"]).IsAdmin) Response.Redirect("~/Default.aspx");
        }

        protected void calDataFine_SelectionChanged(object sender, EventArgs e) {
            Calendar cal = ((Calendar)sender);
            txtDataFine.Text = String.Format("{0:dd/MM/yyyy}", cal.SelectedDate);
        }

        protected void ibtnConferma_Click(object sender, ImageClickEventArgs e) {
            astaEntity newAsta = new astaEntity();

            newAsta.id = Layers.ConnectionGateway.CreateNewIndex("idasta", "asta_elenco");
            newAsta.data_fine = DateTime.Parse(txtDataFine.Text);
            if(chkStatus.Checked) newAsta.state = new Stato(1, "attivo");
            else newAsta.state = new Stato(99, "da attivare");

            AsteGateway.InsertAsta(newAsta);
            Response.Redirect("~/Management/Aste.aspx");
        }

        protected void ibtnReset_Click(object sender, ImageClickEventArgs e) {
            txtDataFine.Text = "";
            chkStatus.Checked = false;
        }

        protected void ibntTornaIndietro_Click(object sender, ImageClickEventArgs e) {
            Response.Redirect("Aste.aspx");
        }
    }
}