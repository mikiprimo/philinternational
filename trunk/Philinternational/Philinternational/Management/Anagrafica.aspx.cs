using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using System.Data;

namespace Philinternational.Styles {
    public partial class Anagrafica : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.BindData(gvAnagrafica);
            }
        }

        public string gvFilterCognome {
            get {
                return ((String)ViewState["gvFilterCognome"]);
            }
            set {
                ViewState["gvFilterCognome"] = value;
            }
        }

        public string gvFilterMail {
            get {
                return ((String)ViewState["gvFilterMail"]);
            }
            set {
                ViewState["gvFilterMail"] = value;
            }
        }

        private void BindData(GridView gv) {
            DataView dv = AnagraficaGateway.SelectAnagrafica();
            String filterQuery = "";
            if (!String.IsNullOrEmpty(this.gvFilterCognome)) {
                filterQuery += "cognome LIKE '%" + this.gvFilterCognome + "%' Or ";
            }
            if (!String.IsNullOrEmpty(this.gvFilterMail)) {
                filterQuery += "email LIKE '%" + this.gvFilterMail + "%' Or ";
            }
            if (!String.IsNullOrEmpty(filterQuery)) filterQuery = filterQuery.Substring(0, filterQuery.Length - 3);
            dv.RowFilter = filterQuery;
            gv.DataSource = dv;
            gv.DataBind();
        }

        protected void gvAnagrafica_PageIndexChanged(object sender, EventArgs e) {
            this.BindData(gvAnagrafica);
        }

        protected void gvAnagrafica_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvAnagrafica.PageIndex = e.NewPageIndex;
            this.BindData(gvAnagrafica);
        }

        protected void ddlStati_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlStati = ((DropDownList)sender);
            String mailAnagrafica = ddlStati.Attributes["CurrentMailAnagrafica"];

            AnagraficaGateway.UpdateStatoByMailAnagrafica(mailAnagrafica, Convert.ToInt32(ddlStati.SelectedValue));
        }

        protected void gvAnagrafica_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {

                DropDownList ddlStati = ((DropDownList)e.Row.Cells[6].FindControl("ddlStati"));
                String StatoID = ((HiddenField)e.Row.Cells[6].FindControl("hiddenIdStato")).Value;
                String mailAnagrafica = ((HiddenField)e.Row.Cells[6].FindControl("HiddenEmail")).Value;

                ddlStati.Attributes.Add("CurrentMailAnagrafica", mailAnagrafica);
                ddlStati.DataTextField = "descrizione";
                ddlStati.DataValueField = "id";
                ddlStati.DataSource = ((legendaStato)Session["legendaStato"]).GetListaStati();
                ddlStati.SelectedValue = StatoID;
                ddlStati.DataBind();

                Image img = ((Image)e.Row.Cells[1].FindControl("imgNewsletterStatus"));
                String idAnagrafica = ((HiddenField)e.Row.Cells[1].FindControl("HiddenIdAnagrafica")).Value;
                Boolean isSubcribedToNewsletters = AnagraficaGateway.IsSubscribedToNewsletters(Convert.ToInt32(idAnagrafica));
                if (isSubcribedToNewsletters) img.ImageUrl = "~/images/newsletters/email.png";
            }
        }

        protected void ibtnCancellaAnagraficheSelezionate_Click(object sender, ImageClickEventArgs e) {
            List<String> list = new List<String>();

            foreach (GridViewRow row in gvAnagrafica.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) list.Add(gvAnagrafica.DataKeys[row.RowIndex]["email"].ToString());
                }
            }
            if (list.Count > 0) AnagraficaGateway.DeleteAnagrafiche(list);
            this.BindData(gvAnagrafica);
        }


        protected void ibtnCercaAnagrafica_Click(object sender, ImageClickEventArgs e) {
            this.gvFilterCognome = txtStringaRicercaCognome.Text;
            this.gvFilterMail = txtStringaRicercaMail.Text;
            this.BindData(gvAnagrafica);
        }
    }
}