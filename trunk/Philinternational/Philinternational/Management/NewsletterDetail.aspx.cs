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
            CKEditNewsletter.config.toolbar = new object[]
            {
                new object[] { "Bold", "Italic", "-", "NumberedList", "BulletedList", "-", "Link", "Unlink", "-", "About" },
                new object[] { "Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "Print", "SpellChecker", "Scayt" },
            };
            if (!((logInfos)HttpContext.Current.Session["log"]).IsAdmin) Response.Redirect("~/Default.aspx");
        }

        protected void calDataCreazione_SelectionChanged(object sender, EventArgs e) {
            Calendar cal = ((Calendar)sender);
            txtDataCreazione.Text = String.Format("{0:dd/MM/yyyy}", cal.SelectedDate);
        }

        private void pulisci() {
            txtDataCreazione.Text = "";
            txtTitolo.Text = "";
            CKEditNewsletter.Text = "";
        }

        protected void ibtnConferma_Click(object sender, ImageClickEventArgs e) {
            newsletterEntity MyNewsletter = new newsletterEntity();
            Boolean esito = false;

            MyNewsletter.id = Layers.ConnectionGateway.CreateNewIndex("idnewsletter", "newsletter");
            MyNewsletter.data_creazione = DateTime.Parse(txtDataCreazione.Text);
            MyNewsletter.titolo = txtTitolo.Text;
            MyNewsletter.testo = CKEditNewsletter.Text = "";

            esito = NewsletterGateway.InsertNewsletter(MyNewsletter);
            Response.Redirect("Newsletter.aspx");
        }

        protected void ibtnPulisci_Click(object sender, ImageClickEventArgs e) {
            pulisci();
        }

        protected void ibntTornaIndietro_Click(object sender, ImageClickEventArgs e) {
            Response.Redirect("Newsletter.aspx");
        }
    }
}