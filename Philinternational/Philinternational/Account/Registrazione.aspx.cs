using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Account {
    public partial class Registrazione : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                String R = "";
                try {
                    R = Request.QueryString["R"].ToString();
                } catch (Exception) {
                }
                if (R == "success") {
                    divRegPanel.Visible = false;
                    divTitolo.Visible = false;
                    divSuccess.Visible = true;
                } else {
                    divRegPanel.Visible = true;
                    divTitolo.Visible = true;
                    divSuccess.Visible = false;
                }
                divDomicilio.Visible = false;
            }
        }

        protected void rb_CheckedChanged(object sender, EventArgs e) {
            if (rbSi.Checked) divDomicilio.Visible = true;
            else divDomicilio.Visible = false;
        }

        protected void CreateUserButton_Click(object sender, EventArgs e) {
            if (AnagraficaGateway.ExistMail(txtEmail.Text)) {
                lblExistMail.Text = "Mail già utilizzata";
                return;
            } else lblExistMail.Text = "";

            anagraficaEntity newUser = new anagraficaEntity();
            newUser.idanagrafica = ConnectionGateway.CreateNewIndex("idanagrafica", "anagrafica");
            newUser.email = txtEmail.Text;
            newUser.password = GeneralUtilities.Encrypt(txtPassword.Text);
            newUser.nome = txtNome.Text;
            newUser.cognome = txtCognome.Text;
            newUser.codice_fiscale = txtCodiceFiscale.Text;
            newUser.partita_iva = txtPiva.Text;
            //Dati residenza
            newUser.res_via = txtVia.Text;
            newUser.res_indirizzo = txtIndirizzo.Text;
            newUser.res_num_civico = txtNumCivico.Text;
            newUser.res_cap = txtCap.Text;
            newUser.res_provincia = txtProvincia.Text;
            newUser.res_comune = txtCitta.Text;
            newUser.res_nazione = txtNazione.Text;
            //Dati domicilio
            if (rbSi.Checked)
            {
                newUser.dom_via = txtViaDom.Text;
                newUser.dom_indirizzo = txtIndirizzoDom.Text;
                newUser.dom_num_civico = txtNumCivicoDom.Text;
                newUser.dom_cap = txtCapDom.Text;
                newUser.dom_provincia = txtProvinciaDom.Text;
                newUser.dom_comune = txtCittaDom.Text;
                newUser.dom_nazione = txtNazioneDom.Text;
            }
            else {
                newUser.dom_via = txtVia.Text;
                newUser.dom_indirizzo = txtIndirizzo.Text;
                newUser.dom_num_civico = txtNumCivico.Text;
                newUser.dom_cap = txtCap.Text;
                newUser.dom_provincia = txtProvincia.Text;
                newUser.dom_comune = txtCitta.Text;
                newUser.dom_nazione = txtNazione.Text;
            }
            Boolean result = false;

            result = AnagraficaGateway.InsertAnagrafica(newUser);
            result = AnagraficaGateway.ManageNewsletterStateByIDAnagrafica(newUser.idanagrafica, chkNewsLetters.Checked);

            if (result) {
                String esitoUtente = MailList.RegistrazioneUtente(newUser.nome + " " + newUser.cognome, newUser.email, newUser.password);
                String esitoAdmin = MailList.AvvisoAdminNuovaRegistrazione(newUser.email);
                Response.Redirect("~/Account/Registrazione.aspx?R=success");
            }
        }

        protected void chkAccettaCondizioni_CheckedChanged(object sender, EventArgs e) {
            CheckBox chk = ((CheckBox)sender);
            if (chk.Checked) CreateUserButton.Visible = true;
        }
    }
}