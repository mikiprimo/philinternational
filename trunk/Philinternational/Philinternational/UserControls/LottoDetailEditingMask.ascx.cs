using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using System.Data;

namespace Philinternational.UserControls {
    public partial class LottoDetailEditingMask : System.Web.UI.UserControl {

        public String currentIdLotto { get { return ((String)ViewState["currentIdLotto"]); } set { ViewState["currentIdLotto"] = value; } }

        public String currentType { get { return ((String)ViewState["currentType"]); } set { ViewState["currentType"] = value; } }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                //currentIdLotto non viene usato in caso di nuovo inserimento
                this.currentIdLotto = GeneralUtilities.GetQueryString(Request.QueryString, "id");
                this.currentType = GeneralUtilities.GetQueryString(Request.QueryString, "type");
                LoadFormData();
            }
        }

        /// <summary>
        /// A seconda della funzionalità scelta nella querystring type definisco e svolgo determinate operazioni sulla form
        /// </summary>
        private void LoadFormData() {
            DataView lotto = new DataView();
            switch (this.currentType) {
                //Voglio agire su un oggetto di lotti pubblicati
                case "pub": lotto = LottiGateway.SelectLottiById(Convert.ToInt32(this.currentIdLotto));
                    ActivateTransferPanel(false);
                    break;
                //Voglio agire su un oggetto di lotti temporanei
                case "tmp": lotto = LottiGateway.SelectLottiTemporaneiById(Convert.ToInt32(this.currentIdLotto));
                    ActivateTransferPanel(false);
                    break;
                //Voglio effettuare un trasferimento del lotto da tmp a lotti pubblicati, verificandone anche i dati (non richiesta ma presente)
                case "trf": lotto = LottiGateway.SelectLottiTemporaneiById(Convert.ToInt32(this.currentIdLotto));
                    ActivateTransferPanel(true);
                    break;
                //Voglio inserire un lotto nuovo
                case "ins": ActivateInsertPanel();
                    break;
            }

            if (this.currentType != "ins") {
                txtConferente.Text = lotto[0]["conferente"].ToString();
                txtAnno.Text = lotto[0]["anno"].ToString();
                txtTipoLotto.Text = lotto[0]["tipo_lotto"].ToString();
                txtNumeroPezzi.Text = lotto[0]["numero_pezzi"].ToString();
                txtDescrizione.Text = lotto[0]["descrizione"].ToString();
                txtPrezzoBase.Text = lotto[0]["prezzo_base"].ToString();
                txtEuro.Text = lotto[0]["euro"].ToString();
                txtRiferimentoSassone.Text = lotto[0]["riferimento_sassone"].ToString();
            }
        }

        private void ActivateInsertPanel() {
            divParagrafiPanel.Visible = true;
            divTransferPanel.Visible = false;
            divUpdatePanel.Visible = false;
            divInsertPanel.Visible = true;

            PopulateParagrafi();
        }

        private void ActivateTransferPanel(Boolean active) {
            if (this.currentType == "pub") divParagrafiPanel.Visible = true;
            else divParagrafiPanel.Visible = active;
            divTransferPanel.Visible = active;
            divUpdatePanel.Visible = !active;
            divInsertPanel.Visible = false;

            if (active) PopulateParagrafi();
            if (this.currentType == "pub") PopulateParagrafi();
        }

        private void PopulateParagrafi() {
            divNoSubArguments.Visible = false;
            ddlParagrafo.DataSource = ParagrafoGateway.SelectParagrafi();
            ddlParagrafo.DataBind();
            PopulateArgomenti(Convert.ToInt32(ddlParagrafo.SelectedValue));
        }

        protected void ddlParagrafo_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlParagrafo = ((DropDownList)sender);
            PopulateArgomenti(Convert.ToInt32(ddlParagrafo.SelectedValue));
        }

        private void PopulateArgomenti(Int32 idparagrafo) {
            ddlArgomenti.DataSource = ParagrafoGateway.SelectArgomenti(idparagrafo);
            ddlArgomenti.DataBind();
            PopulateSubArgomenti(Convert.ToInt32(ddlArgomenti.SelectedValue));
        }

        protected void ddlArgomenti_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlArgs = ((DropDownList)sender);
            PopulateSubArgomenti(Convert.ToInt32(ddlArgs.SelectedValue));
        }

        private void PopulateSubArgomenti(Int32 idSubArgomento) {
            ddlSubArgomenti.DataSource = ParagrafoGateway.SelectSubArgs(idSubArgomento);
            ddlSubArgomenti.DataBind();
            if (ddlSubArgomenti.Items.Count == 0) {
                ddlSubArgomenti.Visible = false;
                divNoSubArguments.Visible = true;
            }
        }



        //TASTI FUNZIONE

        /// <summary>
        /// Update specified lotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnUpdateLotto_Click(object sender, ImageClickEventArgs e) {
            lottoEntity updateLotto = new lottoEntity();

            updateLotto.conferente = txtConferente.Text;
            updateLotto.anno = txtAnno.Text;
            updateLotto.tipo_lotto = txtTipoLotto.Text;
            updateLotto.numero_pezzi = Convert.ToInt32(txtNumeroPezzi.Text);
            updateLotto.descrizione = txtDescrizione.Text;
            updateLotto.prezzo_base = Convert.ToInt32(txtPrezzoBase.Text);
            updateLotto.euro = txtEuro.Text;
            updateLotto.riferimento_sassone = txtRiferimentoSassone.Text;
            updateLotto.id = Convert.ToInt32(currentIdLotto);

            switch (this.currentType) {
                case "pub": LottiGateway.UpdateLotti(updateLotto); break;
                case "tmp": LottiGateway.UpdateLottiTemporanei(updateLotto); break;
            }

            Response.Redirect("~/Management/Lotto.aspx");
        }


        //TODO: Obsoleta non più utilizzata (Transfer Lotti)
        protected void ibtnTransferLotto_Click(object sender, ImageClickEventArgs e) {
            lottoEntity updateLotto = new lottoEntity();
            String SubargomentoValue = "0";
            updateLotto.id_argomento = Convert.ToInt32(ddlArgomenti.SelectedValue);
            if (ddlSubArgomenti.SelectedValue != "") SubargomentoValue = ddlSubArgomenti.SelectedValue;
            updateLotto.id_subargomento = Convert.ToInt32(SubargomentoValue);

            updateLotto.conferente = txtConferente.Text;
            updateLotto.anno = txtAnno.Text;
            updateLotto.tipo_lotto = txtTipoLotto.Text;
            updateLotto.numero_pezzi = Convert.ToInt32(txtNumeroPezzi.Text);
            updateLotto.descrizione = txtDescrizione.Text;
            updateLotto.prezzo_base = Convert.ToInt32(txtPrezzoBase.Text);
            updateLotto.euro = txtEuro.Text;
            updateLotto.riferimento_sassone = txtRiferimentoSassone.Text;
            updateLotto.id = Convert.ToInt32(currentIdLotto);

            Boolean result = LottiGateway.InsertLotto(updateLotto);
            if (result) Response.Redirect("~/Management/Lotto.aspx");
        }

        /// <summary>
        /// Inserimento nuovo lotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnInsertNewLotto_Click(object sender, ImageClickEventArgs e) {
            lottoEntity insertLotto = new lottoEntity();

            insertLotto.id_argomento = Convert.ToInt32(ddlArgomenti.SelectedValue);
            try {
                insertLotto.id_subargomento = Convert.ToInt32(ddlSubArgomenti.SelectedValue);
            } catch (Exception) {
            }

            insertLotto.conferente = txtConferente.Text;
            insertLotto.anno = txtAnno.Text;
            insertLotto.tipo_lotto = txtTipoLotto.Text;
            insertLotto.numero_pezzi = Convert.ToInt32(txtNumeroPezzi.Text);
            insertLotto.descrizione = txtDescrizione.Text;
            insertLotto.prezzo_base = Convert.ToInt32(txtPrezzoBase.Text);
            insertLotto.euro = txtEuro.Text;
            insertLotto.riferimento_sassone = txtRiferimentoSassone.Text;
            insertLotto.id = ConnectionGateway.CreateNewIndex("idlotto", "lotto");
            insertLotto.state = new Stato(99, "da attivare");

            switch (this.currentType) {
                case "ins": LottiGateway.InsertNewLotto(insertLotto); break;
            }
            Response.Redirect("~/Management/Lotto.aspx");
        }


    }
}