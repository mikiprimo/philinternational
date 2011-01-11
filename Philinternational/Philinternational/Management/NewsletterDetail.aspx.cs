using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Management {
    public partial class NewsletterDetail : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnConferma_Click(object sender, EventArgs e) {
            newsletterEntity MyNewsletter = new newsletterEntity();
            Boolean esito = false;

            MyNewsletter.id = Layers.ConnectionGateway.CreateNewIndex("idnewsletter", "newsletter");
            MyNewsletter.data_creazione = DateTime.Parse(txtDataCreazione.Text);
            MyNewsletter.titolo = txtTitolo.Text;
            MyNewsletter.testo = txtTesto.Text;

            esito = NewsletterGateway.InsertNewsletter(MyNewsletter);
        }

        protected void calDataCreazione_SelectionChanged(object sender, EventArgs e) {
            Calendar cal = ((Calendar)sender);
            txtDataCreazione.Text = String.Format("{0:dd/MM/yyyy}", cal.SelectedDate);
        }

        protected void pulisci(object sender, EventArgs e) {
            txtDataCreazione.Text = "";
            txtTitolo.Text = "";
            txtTesto.Text = "";
        }

        protected void comeBack(object sender, EventArgs e) {
            Response.Redirect("Newsletter.aspx");
        }
    }
}