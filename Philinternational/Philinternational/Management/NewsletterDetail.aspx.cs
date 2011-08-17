using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Management {
	public partial class NewsletterDetail : System.Web.UI.Page {

		public string newsletterIdToBeModified {
			get {
				return (String)ViewState["nltobeModified"];
			}
			set {
				ViewState["nltobeModified"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				if (GeneralUtilities.GetQueryString(Request.QueryString, "idnl") != null) {
					this.newsletterIdToBeModified = GeneralUtilities.GetQueryString(Request.QueryString, "idnl");
					NewsletterEntity readNewsLetter = NewsletterGateway.SelectNewsletter(Convert.ToInt32(this.newsletterIdToBeModified));
					populateNewsletterFields(readNewsLetter);
				} else this.newsletterIdToBeModified = null;
			}

			CKEditNewsletter.config.toolbar = new object[]
			{
				new object[] { "Bold", "Italic", "-", "NumberedList", "BulletedList", "-", "Link", "Unlink", "-", "About" },
				new object[] { "Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "Print", "SpellChecker", "Scayt" },
			};
		}

		private void populateNewsletterFields(NewsletterEntity readNewsLetter) {
			txtDataCreazione.Text = String.Format("{0:dd/MM/yyyy}", readNewsLetter.data_creazione);
			txtTitolo.Text = readNewsLetter.titolo;
			CKEditNewsletter.Text = readNewsLetter.testo;
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
			NewsletterEntity MyNewsletter = new NewsletterEntity();
			Boolean esito = false;

			MyNewsletter.data_creazione = DateTime.Parse(txtDataCreazione.Text);
			MyNewsletter.titolo = txtTitolo.Text;
			MyNewsletter.testo = CKEditNewsletter.Text;

			if (this.newsletterIdToBeModified != null) {
				MyNewsletter.id = Convert.ToInt32(this.newsletterIdToBeModified);
				esito = NewsletterGateway.UpdateNewsletter(MyNewsletter);
			} else {
				MyNewsletter.id = Layers.ConnectionGateway.CreateNewIndex("idnewsletter", "newsletter");
				esito = NewsletterGateway.InsertNewsletter(MyNewsletter);
			}
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