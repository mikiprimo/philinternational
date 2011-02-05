using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using System.Data;

namespace Philinternational.Management {
    public partial class Lotto : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.BindData(gvLottiPubblicati);
            }
        }

        public string gvFilter {
            get {
                return ((String)ViewState["gvFilter"]);
            }
            set {
                ViewState["gvFilter"] = value;
            }
        }

        private void BindData(GridView gv) {
            if (String.IsNullOrEmpty(this.gvFilter)) {
                gv.DataSource = LottiGateway.SelectLotti();
            } else {
                DataView dv = LottiGateway.SelectLotti();
                dv.RowFilter = "descrizione LIKE '%" + this.gvFilter + "%'";
                gv.DataSource = dv;
            }
            gv.DataBind();
        }

        //Tab TMP
        protected void ibtnPubblicaLottiSelezionati_Click(object sender, ImageClickEventArgs e) {
            //Muove la riga dalla tabella lotti_tmp alla tabella lotti e mette lo stato (su quest'ultima) in disattivo
        }

        protected void ibtnCercaLotto_Click(object sender, ImageClickEventArgs e) {
            if (txtStringaRicerca.Text.Trim() == String.Empty) this.gvFilter = "";
            else this.gvFilter = txtStringaRicerca.Text;
            BindData(gvLottiPubblicati);
        }

        protected void gvLottiPubblicati_PageIndexChanged(object sender, EventArgs e) {
            this.BindData(gvLottiPubblicati);
        }

        protected void gvLottiPubblicati_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvLottiPubblicati.PageIndex = e.NewPageIndex;
            this.BindData(gvLottiPubblicati);
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

            LottiGateway.UpdateStatoByIDLotto(idlotto, Convert.ToInt32(ddlStati.SelectedValue));
        }

        protected void gvLottiTemporanei_PageIndexChanged(object sender, EventArgs e) {
            this.BindData(gvLottiTemporanei);
        }

        protected void gvLottiTemporanei_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvLottiTemporanei.PageIndex = e.NewPageIndex;
            this.BindData(gvLottiTemporanei);
        }
    }
}