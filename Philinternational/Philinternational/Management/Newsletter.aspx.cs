using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Styles {
    public partial class Newsletter : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.BindData();
            }
        }

        private void BindData() {
            gvNewsletters.DataSource = NewsletterGateway.SelectNewsletter();
            gvNewsletters.DataBind();
        }

        protected void ibtnCreateNewsletter_Click(object sender, ImageClickEventArgs e) {
            Response.Redirect("NewsletterDetail.aspx");
        }

        protected void ibtnDeleteSelectedNewsletters_Click(object sender, ImageClickEventArgs e) {
            List<Int32> list = new List<Int32>();

            foreach (GridViewRow row in gvNewsletters.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) list.Add(Convert.ToInt32(gvNewsletters.DataKeys[row.RowIndex]["idnewsletter"]));
                }
            }
            if (list.Count > 0) NewsletterGateway.DeleteNewsletter(list);
            this.BindData();
        }

        protected void gvNewsletters_RowEditing(object sender, GridViewEditEventArgs e) {
            gvNewsletters.EditIndex = e.NewEditIndex;
            this.BindData();
        }

        protected void gvNewsletters_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            GridViewRow row = gvNewsletters.Rows[e.RowIndex];
            var newValues = Commons.GetValuesGridViewRow(row);

            newsletterEntity MyNewsletter = new newsletterEntity();
            MyNewsletter.id = Convert.ToInt32(gvNewsletters.DataKeys[e.RowIndex]["idasta"]);
            MyNewsletter.data_creazione = DateTime.Parse((String)newValues["data_creazione"]);
            MyNewsletter.titolo = (String)newValues["titolo"];
            MyNewsletter.testo = (String)newValues["testo"];

            NewsletterGateway.UpdateNewsletter(MyNewsletter);

            gvNewsletters.EditIndex = -1;
            this.BindData();
        }

        protected void gvNewsletters_PageIndexChanged(object sender, EventArgs e) {
            this.BindData();
        }

        protected void gvNewsletters_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvNewsletters.PageIndex = e.NewPageIndex;
            this.BindData();
        }
    }
}