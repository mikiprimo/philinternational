using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.Services;
using Philinternational.Layers;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Philinternational
{
    public partial class contatti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) { 
            String email = txtEMail.Text;
            String riferimento = txtNomeCognome.Text;
            String bodyMail = txtTesto.Text;
            String subject = ListaOggetto.SelectedItem.Text;
            String oraSpedizione = DateTime.Now.ToString();
            Boolean sendMeToCopy = chksendCopia.Checked;
            fldMessaggio.Visible = true;//visualizzao il fieldset
            Boolean esitoAdmin = MailList.ContattiToAdministrator(riferimento, subject, email, bodyMail, oraSpedizione);
            if (esitoAdmin == false)
            {
                if (sendMeToCopy)
                {
                    Boolean esitoGuest = MailList.ContattiToGuest(riferimento, subject, email, bodyMail);
                    if (esitoGuest == false)
                    {
                        esitoMessaggio.CssClass = "ok";
                        esitoMessaggio.Text = "La mail è stata inviata con successo. A breve riceverai una copia.";
                        clearInternalField();
                    }
                    else {
                            esitoMessaggio.CssClass = "ok";
                            esitoMessaggio.Text = "La mail è stata inviata con succcesso, ma per problemi interni non ti è stata inviata una copia. Ci scusiamo per il disagio.";
                            clearInternalField();
                    }
                }
                else {
                    esitoMessaggio.CssClass = "ok";
                    esitoMessaggio.Text = "La mail è stata inviata con successo";
                    clearInternalField();
                }
            }
            else {
                esitoMessaggio.CssClass = "ko";
                esitoMessaggio.Text = "La mail non è stata inviata per problemi interni. Ci scusiamo per il disagio. Riprova più tardi";
            }
            }
        }

        protected void clearInternalField() {
            txtEMail.Text = "";
            txtNomeCognome.Text = "";
            txtTesto.Text = "";
            chksendCopia.Checked = false;
            ListaOggetto.ClearSelection();
        }
    }
}