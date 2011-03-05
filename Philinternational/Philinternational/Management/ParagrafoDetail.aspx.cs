using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Management {
    public partial class ParagrafoDetail : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ibtnConferma_Click(object sender, ImageClickEventArgs e) {
            paragrafoEntity newParagrafo = new paragrafoEntity();

            newParagrafo.id = Layers.ConnectionGateway.CreateNewIndex("idparagrafo", "paragrafo");
            newParagrafo.descrizione = txtDescrizione.Text;
            if (chkStatus.Checked) newParagrafo.state = new Stato(1, "attivo");
            else newParagrafo.state = new Stato(99, "da attivare");

            ParagrafoGateway.InsertParagrafo(newParagrafo);
            Response.Redirect("~/Management/Paragrafo.aspx");
        }

        protected void ibtnReset_Click(object sender, ImageClickEventArgs e) {
            txtDescrizione.Text = "";
            chkStatus.Checked = false;
        }

        protected void ibntTornaIndietro_Click(object sender, ImageClickEventArgs e) {
            Response.Redirect("Paragrafo.aspx");
        }
    }
}