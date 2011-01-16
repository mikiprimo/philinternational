using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Management
{
    public partial class Lotto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.BindData();
            }
        }

        private void BindData() {
            gvLottiPubblicati.DataSource = LottiGateway.SelectLotti();
            gvLottiPubblicati.DataBind();
        }

        protected void ibtnPubblicaLottiSelezionati_Click(object sender, ImageClickEventArgs e) {
            //Muove la riga dalla tabella lotti_tmp alla tabella lotti e mette lo stato (su quest'ultima) in disattivo
        }

        protected void ibtnAttivaSelezionati_Click(object sender, ImageClickEventArgs e) {
            //Update su db dei lotti selezionati da attivare
        }

        protected void ibtnDisattivaSelezionati_Click(object sender, ImageClickEventArgs e) {
            //Update su db dei lotti selezionati da sospendere
        }

        protected void ibtnCercaLotto_Click(object sender, ImageClickEventArgs e) {
            //Filtro sulla dataview e rebind della gridview
        }

        protected void gvLottiTemporanei_PageIndexChanged(object sender, EventArgs e) {
            this.BindData();
        }

        protected void gvLottiTemporanei_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvLottiTemporanei.PageIndex = e.NewPageIndex;
            this.BindData();
        }

        protected void gvLottiPubblicati_PageIndexChanged(object sender, EventArgs e) {
            this.BindData();
        }

        protected void gvLottiPubblicati_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvLottiPubblicati.PageIndex = e.NewPageIndex;
            this.BindData();
        }

        protected void gvLottiPubblicati_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                
                DropDownList ddlStati = ((DropDownList)e.Row.Cells[7].FindControl("ddlStati"));
                String StatoID = ((HiddenField)e.Row.Cells[7].FindControl("hiddenIdStato")).Value;
                String IDLotto = ((HiddenField)e.Row.Cells[7].FindControl("HiddenIdLotto")).Value;

                ddlStati.Attributes.Add("CurrentIDLotto", IDLotto);
                ddlStati.DataTextField = "descrizione";
                ddlStati.DataValueField = "id";
                ddlStati.DataSource = ((legendaStato)Session["legendaStato"]).GetListaStati();
                ddlStati.SelectedValue = StatoID;
                ddlStati.DataBind();
            }
        }

        protected void ddlStati_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlStati = ((DropDownList)sender);
            Int32 idlotto = Convert.ToInt32(ddlStati.Attributes["CurrentIDLotto"]);

            LottiGateway.UpdateStatoByIDLotto(idlotto,Convert.ToInt32(ddlStati.SelectedValue));
        }
    }
}