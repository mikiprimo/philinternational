using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Styles {
    public partial class Paragrafo : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!((logInfos)HttpContext.Current.Session["log"]).IsAdmin) Response.Redirect("~/Default.aspx");
            if(!IsPostBack) BindData();
        }

        private void BindData() {
            gvParagrafi.DataSource = ParagrafoGateway.SelectParagrafi();
            gvParagrafi.DataBind();
        }

        protected void gvParagrafi_RowEditing(object sender, GridViewEditEventArgs e) {
            gvParagrafi.EditIndex = e.NewEditIndex;
            this.BindData();
        }

        protected void gvParagrafi_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            GridViewRow row = gvParagrafi.Rows[e.RowIndex];
            var newValues = Commons.GetValuesGridViewRow(row);

            paragrafoEntity MyParagrafo = new paragrafoEntity();
            MyParagrafo.descrizione = (String)newValues["descrizione"];
            MyParagrafo.id = Convert.ToInt32(gvParagrafi.DataKeys[e.RowIndex]["idparagrafo"]);
            MyParagrafo.state = new Stato(((CheckBox)gvParagrafi.Rows[e.RowIndex].FindControl("chkUpdateStatus")).Checked == true ? 1:0, "");

            ParagrafoGateway.UpdateParagrafi(MyParagrafo);

            gvParagrafi.EditIndex = -1;
            this.BindData();
        }

        protected void gvParagrafi_PageIndexChanged(object sender, EventArgs e) {
            this.BindData();
        }

        protected void gvParagrafi_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvParagrafi.PageIndex = e.NewPageIndex;
            this.BindData();
        }

        protected void gvParagrafi_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                ((HyperLink)e.Row.Cells[0].FindControl("hlGoToArgumentsView")).NavigateUrl = "~/Management/ArgoAndSubArgomento.aspx?Query=" + gvParagrafi.DataKeys[e.Row.RowIndex]["idparagrafo"];
            }
        }

        protected void ibtnNuovoParagrafo_Click(object sender, ImageClickEventArgs e) {

        }
    }
}