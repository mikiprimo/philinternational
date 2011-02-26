using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using System.Data;

namespace Philinternational.Management {

    public enum tabellaLotto {
        LottiPubblicati,
        LottiTemporanei,
        LottiScartati
    }

    public partial class Lotto : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!((logInfos)HttpContext.Current.Session["log"]).IsAdmin) Response.Redirect("~/Default.aspx");
            if (!IsPostBack) {
                this.BindData(gvLottiPubblicati, tabellaLotto.LottiPubblicati);
            }
            if (txtStringaRicerca.Text.Trim() == "") this.gvFilter = String.Empty;
        }

        public String gvFilter {
            get {
                return ((String)ViewState["gvFilter"]);
            }
            set {
                ViewState["gvFilter"] = value;
            }
        }

        private void BindData(GridView gv, tabellaLotto tab) {
            if (String.IsNullOrEmpty(this.gvFilter)) {
                gv.DataSource = GetGatewaySourceFromTabellaLotti(tab);
            } else {
                DataView dv = GetGatewaySourceFromTabellaLotti(tab);
                dv.RowFilter = " descrizione LIKE '%" + this.gvFilter + "%'";
                gv.DataSource = dv;
            }
            gv.DataBind();
        }

        protected void ddlSelectedView_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlViews = ((DropDownList)sender);
            switch (ddlViews.SelectedValue) {
                case "0": mvLotti.SetActiveView(viewLottiPubblicati);
                    BindData(gvLottiPubblicati, tabellaLotto.LottiPubblicati);
                    lblLottiSection.Text = "Pubblicati";
                    break;
                case "1": mvLotti.SetActiveView(viewLottiTemporanei);
                    BindData(gvLottiTemporanei, tabellaLotto.LottiTemporanei);
                    lblLottiSection.Text = "Temporanei";
                    break;
                case "2": mvLotti.SetActiveView(viewLottiScartati);
                    BindData(gvLottiScartati, tabellaLotto.LottiScartati);
                    lblLottiSection.Text = "Scartati";
                    break;
                default: mvLotti.SetActiveView(viewLottiPubblicati); break;
            }
        }

        private tabellaLotto GetTableFromActiveView() {
            String activeView = ((View)mvLotti.GetActiveView()).ID;

            switch (activeView) {
                case "viewLottiPubblicati":
                    return tabellaLotto.LottiPubblicati;
                case "viewLottiTemporanei":
                    return tabellaLotto.LottiTemporanei;
                case "viewLottiScartati":
                    return tabellaLotto.LottiScartati;
                default: return tabellaLotto.LottiPubblicati;
            }
        }

        private GridView GetGridFromActiveView() {
            String activeView = ((View)mvLotti.GetActiveView()).ID;

            switch (activeView) {
                case "viewLottiPubblicati":
                    return ((GridView)((View)mvLotti.GetActiveView()).FindControl("gvLottiPubblicati"));
                case "viewLottiTemporanei":
                    return ((GridView)((View)mvLotti.GetActiveView()).FindControl("gvLottiTemporanei"));
                case "viewLottiScartati":
                    return ((GridView)((View)mvLotti.GetActiveView()).FindControl("gvLottiScartati"));
            }
            return null;
        }

        private DataView GetGatewaySourceFromTabellaLotti(tabellaLotto tab) {
            switch (tab) {
                case tabellaLotto.LottiPubblicati: return LottiGateway.SelectLotti();
                case tabellaLotto.LottiTemporanei: return LottiGateway.SelectLottiTemporanei();
                case tabellaLotto.LottiScartati: return LottiGateway.SelectLottiScartati();
                default: return LottiGateway.SelectLotti();
            }
        }

        //Tab TMP
        protected void ibtnPubblicaLottiSelezionati_Click(object sender, ImageClickEventArgs e) {
            //Muove la riga dalla tabella lotti_tmp alla tabella lotti e mette lo stato (su quest'ultima) in disattivo
        }

        protected void ibtnCercaLotto_Click(object sender, ImageClickEventArgs e) {
            if (txtStringaRicerca.Text.Trim() == String.Empty) this.gvFilter = "";
            else this.gvFilter = txtStringaRicerca.Text;
            BindData(GetGridFromActiveView(), GetTableFromActiveView());
        }

        #region LOTTI PUBBLICATI

        protected void ibtnCancellaLottiSelezionati_Click(object sender, ImageClickEventArgs e) {
            List<Int32> list = new List<Int32>();

            foreach (GridViewRow row in gvLottiPubblicati.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) list.Add(Convert.ToInt32(gvLottiPubblicati.DataKeys[row.RowIndex]["idlotto"]));
                }
            }
            if (list.Count > 0) LottiGateway.DeleteLotti(list);
            this.BindData(gvLottiPubblicati, tabellaLotto.LottiPubblicati);
        }

        protected void gvLottiPubblicati_PageIndexChanged(object sender, EventArgs e) {
            this.BindData(gvLottiPubblicati, tabellaLotto.LottiPubblicati);
        }

        protected void gvLottiPubblicati_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvLottiPubblicati.PageIndex = e.NewPageIndex;
            this.BindData(gvLottiPubblicati, tabellaLotto.LottiPubblicati);
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

        #endregion

        #region LOTTI TEMPORANEI

        protected void ibtnCancellaLottiTemporaneiSelezionati_Click(object sender, ImageClickEventArgs e) {
            List<Int32> list = new List<Int32>();

            foreach (GridViewRow row in gvLottiTemporanei.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) list.Add(Convert.ToInt32(gvLottiTemporanei.DataKeys[row.RowIndex]["idcatalogo"]));
                }
            }
            if (list.Count > 0) LottiGateway.DeleteLottiTemporanei(list);
            this.BindData(gvLottiTemporanei, tabellaLotto.LottiTemporanei);
        }

        protected void gvLottiTemporanei_PageIndexChanged(object sender, EventArgs e) {
            this.BindData(gvLottiTemporanei, tabellaLotto.LottiTemporanei);
        }

        protected void gvLottiTemporanei_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvLottiTemporanei.PageIndex = e.NewPageIndex;
            this.BindData(gvLottiTemporanei, tabellaLotto.LottiTemporanei);
        }



        #endregion

        #region LOTTI SCARTATI

        protected void gvLottiScartati_PageIndexChanged(object sender, EventArgs e) {
            this.BindData(gvLottiScartati, tabellaLotto.LottiScartati);
        }

        protected void gvLottiScartati_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvLottiScartati.PageIndex = e.NewPageIndex;
            this.BindData(gvLottiScartati, tabellaLotto.LottiScartati);
        }

        #endregion

        protected void ibtnTransferLotto_Click(object sender, ImageClickEventArgs e) {
            String idcatalogo = "";

            foreach (GridViewRow row in gvLottiTemporanei.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) {
                        idcatalogo = gvLottiTemporanei.DataKeys[row.RowIndex]["idcatalogo"].ToString();
                        break;
                    }
                }
            }
            if (idcatalogo != "") Response.Redirect("~/Management/LottiDetail.aspx?type=trf&id=" + idcatalogo);
        }
    }
}