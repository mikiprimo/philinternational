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

        public operationType currentType { get { return ((operationType)ViewState["currentType"]); } set { ViewState["currentType"] = value; } }

        public enum operationType { lottiPubblicati, lottiTemporanei, Trasferimento, Inserimento, None }

        private operationType RetrieveEnumType(String p) { switch (p) { case "pub": return operationType.lottiPubblicati; case "tmp": return operationType.lottiTemporanei; case "trf": return operationType.Trasferimento; case "ins": return operationType.Inserimento; default: return operationType.None; } }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                //currentIdLotto non viene usato in caso di nuovo inserimento
                this.currentIdLotto = GeneralUtilities.GetQueryString(Request.QueryString, "id");
                this.currentType = RetrieveEnumType(GeneralUtilities.GetQueryString(Request.QueryString, "type"));
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
                case operationType.lottiPubblicati: lotto = LottiGateway.SelectLottiById(Convert.ToInt32(this.currentIdLotto));
                    ManagePanels();
                    break;
                //Voglio agire su un oggetto di lotti temporanei
                case operationType.lottiTemporanei: lotto = LottiGateway.SelectLottiTemporaneiById(Convert.ToInt32(this.currentIdLotto));
                    ManagePanels();
                    break;
                //Voglio effettuare un trasferimento del lotto da tmp a lotti pubblicati, verificandone anche i dati (non richiesta ma presente)
                case operationType.Trasferimento: lotto = LottiGateway.SelectLottiTemporaneiById(Convert.ToInt32(this.currentIdLotto));
                    ManagePanels();
                    break;
                //Voglio inserire un lotto nuovo
                case operationType.Inserimento:
                    ManagePanels();
                    break;
            }

            if (this.currentType != operationType.Inserimento) {
                if (this.currentType == operationType.lottiPubblicati) lblIdLotto.Text = lotto[0]["idlotto"].ToString();
                if (this.currentType == operationType.lottiTemporanei) lblIdLotto.Text = lotto[0]["idcatalogo"].ToString();
                txtConferente.Text = lotto[0]["conferente"].ToString();
                txtAnno.Text = lotto[0]["anno"].ToString();
                txtTipoLotto.Text = lotto[0]["tipo_lotto"].ToString();
                txtNumeroPezzi.Text = lotto[0]["numero_pezzi"].ToString();
                txtDescrizione.Text = lotto[0]["descrizione"].ToString();
                txtPrezzoBase.Text = lotto[0]["prezzo_base"].ToString();
                txtEuro.Text = lotto[0]["euro"].ToString();
                txtRiferimentoSassone.Text = lotto[0]["riferimento_sassone"].ToString();
                if (this.currentType == operationType.lottiPubblicati) {
                    Int32 actualIdArg = Convert.ToInt32(lotto[0]["id_argomento"].ToString());
                    Int32 actualIdSubArg = Convert.ToInt32(lotto[0]["id_subargomento"].ToString());
                    Int32 actualIdParag = ParagrafoGateway.SelectIdParagrafo(actualIdArg);

                    PopulateParagrafi(actualIdParag);
                    PopulateArgomenti(actualIdArg, actualIdParag);
                    PopulateSubArgomenti(actualIdSubArg, actualIdArg);
                }
            } else {
                PopulateParagrafi();
                PopulateArgomenti(Convert.ToInt32(ddlParagrafo.SelectedValue));
                PopulateSubArgomenti(Convert.ToInt32(ddlArgomenti.SelectedValue));
            }
        }

        private void ManagePanels() {
            if (this.currentType == operationType.lottiPubblicati || this.currentType == operationType.Inserimento) divDDLPanel.Visible = true;
            if (this.currentType == operationType.lottiPubblicati || this.currentType == operationType.lottiTemporanei) divUpdatePanel.Visible = true;
            if (this.currentType == operationType.Inserimento) {
                lblIdLottoDesc.Visible = false;
                divInsertPanel.Visible = true;
            }
        }

        //private void ActivateInsertPanel() {
        //    divDDLPanel.Visible = true;
        //    divTransferPanel.Visible = false;
        //    divUpdatePanel.Visible = false;
        //    divInsertPanel.Visible = true;

        //    PopulateParagrafi();
        //}

        //private void ActivateTransferPanel(Boolean active) {
        //    if (this.currentType == operationType.lottiPubblicati) divDDLPanel.Visible = true;
        //    else divDDLPanel.Visible = active;
        //    divTransferPanel.Visible = active;
        //    divUpdatePanel.Visible = !active;
        //    divInsertPanel.Visible = false;

        //    if (active) PopulateParagrafi();
        //    if (this.currentType == operationType.lottiPubblicati) PopulateParagrafi();
        //}


        //DDL Paragrafo
        private void PopulateParagrafi(Int32 actualIdParag) {
            PopulateParagrafi();
            ddlParagrafo.SelectedValue = actualIdParag.ToString();
        }

        private void PopulateParagrafi() {
            divNoSubArguments.Visible = false;
            ddlParagrafo.DataSource = ParagrafoGateway.SelectParagrafi();
            ddlParagrafo.DataBind();
        }

        protected void ddlParagrafo_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlParagrafo = ((DropDownList)sender);
            PopulateArgomenti(Convert.ToInt32(ddlParagrafo.SelectedValue));
        }

        //DDL Argomenti
        private void PopulateArgomenti(Int32 actualIdArg, Int32 actualIdParag) {
            PopulateArgomenti(actualIdParag);
            ddlArgomenti.SelectedValue = actualIdArg.ToString();
        }

        private void PopulateArgomenti(Int32 idparagrafo) {
            ddlArgomenti.DataSource = ParagrafoGateway.SelectArgomenti(idparagrafo);
            ddlArgomenti.DataBind();
        }

        protected void ddlArgomenti_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlArgs = ((DropDownList)sender);
            PopulateSubArgomenti(Convert.ToInt32(ddlArgs.SelectedValue));
        }

        //DDL SubArgomenti
        private void PopulateSubArgomenti(Int32 actualIdSubArg, Int32 actualIdArg) {
            PopulateSubArgomenti(actualIdArg);
            ddlSubArgomenti.SelectedValue = actualIdSubArg.ToString();
        }

        private void PopulateSubArgomenti(Int32 idArgomento) {
            ddlSubArgomenti.DataSource = ParagrafoGateway.SelectSubArgomentiByIdArgomento(idArgomento);
            ddlSubArgomenti.DataBind();
            if (ddlSubArgomenti.Items.Count == 0) {
                ddlSubArgomenti.Visible = false;
                divNoSubArguments.Visible = true;
            }
        }

        //TASTI FUNZIONE

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
                case operationType.lottiPubblicati:
                    updateLotto.id_argomento = Convert.ToInt32(ddlArgomenti.SelectedValue);
                    if (ddlSubArgomenti.Visible) updateLotto.id_subargomento = Convert.ToInt32(ddlSubArgomenti.SelectedValue);
                    else updateLotto.id_subargomento = 0;
                    LottiGateway.UpdateLotti(updateLotto); break;
                case operationType.lottiTemporanei: LottiGateway.UpdateLottiTemporanei(updateLotto); break;
            }
            Response.Redirect("~/Management/Lotto.aspx");
        }

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

            LottiGateway.InsertNewLotto(insertLotto);
            Response.Redirect("~/Management/Lotto.aspx");
        }
    }
}