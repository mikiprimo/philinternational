﻿using System;
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
                this.currentIdLotto = GeneralUtilities.GetQueryString(Request.QueryString, "id");
                this.currentType = GeneralUtilities.GetQueryString(Request.QueryString, "type");
                LoadFormData();
            }
        }

        private void LoadFormData() {
            DataView lotto = new DataView();
            switch (this.currentType) {
                case "pub": lotto = LottiGateway.SelectLottiById(Convert.ToInt32(this.currentIdLotto));
                    ActivateTransferPanel(false);
                    break;
                case "tmp": lotto = LottiGateway.SelectLottiTemporaneiById(Convert.ToInt32(this.currentIdLotto));
                    ActivateTransferPanel(false);
                    break;
                case "trf": lotto = LottiGateway.SelectLottiTemporaneiById(Convert.ToInt32(this.currentIdLotto));
                    ActivateTransferPanel(true);
                    break;
            }

            txtConferente.Text = lotto[0]["conferente"].ToString();
            txtAnno.Text = lotto[0]["anno"].ToString();
            txtTipoLotto.Text = lotto[0]["tipo_lotto"].ToString();
            txtNumeroPezzi.Text = lotto[0]["numero_pezzi"].ToString();
            txtDescrizione.Text = lotto[0]["descrizione"].ToString();
            txtPrezzoBase.Text = lotto[0]["prezzo_base"].ToString();
            txtEuro.Text = lotto[0]["euro"].ToString();
            txtRiferimentoSassone.Text = lotto[0]["riferimento_sassone"].ToString();
        }

        private void ActivateTransferPanel(Boolean active) {
            divArgumentsPanel.Visible = active;
            divTransferPanel.Visible = active;
            divUpdatePanel.Visible = !active;

            if (active) PopulateArgsAndSubArgsDDLs();
        }

        private void PopulateArgsAndSubArgsDDLs() {
            ddlArgomenti.DataValueField = "idargomento";
            ddlArgomenti.DataTextField = "descrizione";
            ddlArgomenti.DataSource = ParagrafoGateway.SelectAllArgomenti();
            ddlArgomenti.DataBind();
        }

        //Popolare la ddlSubArgs in base all'argomento scelto
        protected void ddlArgomenti_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlArgs = ((DropDownList)sender);
            String MyArgId = ddlArgs.SelectedValue;

            ddlSubArgomenti.DataValueField = "idsub_argomento";
            ddlSubArgomenti.DataTextField = "descrizione";
            ddlSubArgomenti.DataSource = ParagrafoGateway.SelectSubArgs(Convert.ToInt32(MyArgId));
            ddlSubArgomenti.DataBind();

        }

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
    }
}