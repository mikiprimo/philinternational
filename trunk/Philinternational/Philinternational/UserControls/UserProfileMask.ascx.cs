using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using System.Data;

namespace Philinternational.Management.UserControls {
    public partial class UserProfileMask : System.Web.UI.UserControl {

        public String oldPassword { get { return (String)ViewState["oldPassword"]; } set { ViewState["oldPassword"] = value; } }
        public String oldEmail { get { return (String)ViewState["oldEmail"]; } set { ViewState["oldEmail"] = value; } }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (String.IsNullOrEmpty(this.oldEmail)) this.oldEmail = GeneralUtilities.GetQueryString(Request.QueryString, "email");
            }
        }

        public void LoadFormData() {
            DataRowView dv = AnagraficaGateway.SelectAnagraficaByMail(this.oldEmail);

            hiddenIDAnagrafica.Value = dv["idanagrafica"].ToString();
            txtEmail.Text = dv["email"].ToString();
            txtPassword.Text = dv["password"].ToString();
            this.oldPassword = dv["password"].ToString();

            txtNome.Text = dv["nome"].ToString();
            txtCognome.Text = dv["cognome"].ToString();
            txtCodiceFiscale.Text = dv["codice_fiscale"].ToString();
            txtPiva.Text = dv["partita_iva"].ToString();
            txtVia.Text = dv["res_via"].ToString();
            txtIndirizzo.Text = dv["res_indirizzo"].ToString();
            txtNumCivico.Text = dv["res_num_civico"].ToString();
            txtCap.Text = dv["res_cap"].ToString();
            txtCitta.Text = dv["res_comune"].ToString();
            txtProvincia.Text = dv["res_provincia"].ToString();
            txtNazione.Text = dv["res_nazione"].ToString();
            txtViaDom.Text = dv["dom_via"].ToString();
            txtIndirizzoDom.Text = dv["dom_indirizzo"].ToString();
            txtNumCivicoDom.Text = dv["dom_num_civico"].ToString();
            txtCapDom.Text = dv["dom_cap"].ToString();
            txtCittaDom.Text = dv["dom_comune"].ToString();
            txtProvinciaDom.Text = dv["dom_provincia"].ToString();
            txtNazioneDom.Text = dv["dom_nazione"].ToString();

            chkNewsLetters.Checked = AnagraficaGateway.IsSubscribedToNewsletters(Convert.ToInt32(hiddenIDAnagrafica.Value));
        }

        protected void ibtnUpdateAnagrafica_Click(object sender, ImageClickEventArgs e) {
            anagraficaEntity newAnagrafica = new anagraficaEntity();

            newAnagrafica.email = this.txtEmail.Text;
            newAnagrafica.password = this.txtPassword.Text;
            newAnagrafica.nome = this.txtNome.Text;
            newAnagrafica.cognome = this.txtCognome.Text;
            newAnagrafica.codice_fiscale = this.txtCodiceFiscale.Text;
            newAnagrafica.partita_iva = this.txtPiva.Text;
            newAnagrafica.res_via = this.txtVia.Text;
            newAnagrafica.res_indirizzo = this.txtIndirizzo.Text;
            newAnagrafica.res_num_civico = this.txtNumCivico.Text;
            newAnagrafica.res_cap = this.txtCap.Text;
            newAnagrafica.res_provincia = this.txtProvincia.Text;
            newAnagrafica.res_comune = this.txtCitta.Text;
            newAnagrafica.res_nazione = this.txtNazione.Text;
            newAnagrafica.dom_via = this.txtViaDom.Text;
            newAnagrafica.dom_indirizzo = this.txtIndirizzoDom.Text;
            newAnagrafica.dom_num_civico = this.txtNumCivicoDom.Text;
            newAnagrafica.dom_cap = this.txtCapDom.Text;
            newAnagrafica.dom_provincia = this.txtProvinciaDom.Text;
            newAnagrafica.dom_comune = this.txtCittaDom.Text;
            newAnagrafica.dom_nazione = this.txtNazioneDom.Text;

            AnagraficaGateway.UpdateAnagrafica(this.oldEmail, newAnagrafica);
            AnagraficaGateway.ManageNewsletterStateByIDAnagrafica(Convert.ToInt32(hiddenIDAnagrafica.Value), chkNewsLetters.Checked);
            if (txtPassword.Text != this.oldPassword) MailList.CambioPassword(txtNome.Text + txtCognome.Text, txtEmail.Text, txtPassword.Text);
        }

    }
}