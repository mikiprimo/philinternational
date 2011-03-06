using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using System.Data;

namespace Philinternational.Styles {
    public partial class Newsletter : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!((logInfos)HttpContext.Current.Session["log"]).IsAdmin) Response.Redirect("~/Default.aspx");
            if (!IsPostBack) {
                IsViewGridVisible(true);
                this.BindData();
            }
        }

        public List<newsletterEntity> selectedNewsletters {
            get { return ((List<newsletterEntity>)ViewState["idNewsletters"]); }
            set { ViewState["idNewsletters"] = value; }
        }

        private void IsViewGridVisible(Boolean bol) {
            if (bol) mvNewsletterManager.SetActiveView(viewGrid);
            else mvNewsletterManager.SetActiveView(viewDistribution);
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
            MyNewsletter.id = Convert.ToInt32(gvNewsletters.DataKeys[e.RowIndex]["idnewsletter"]);
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

        /// <summary>
        /// Presenta la lista delle checkbox per ogni utente che vuole ricevere la newsletter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSendToAll_Click(object sender, ImageClickEventArgs e) {
            List<newsletterEntity> newsletterList = new List<newsletterEntity>();

            foreach (GridViewRow row in gvNewsletters.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) {
                        //Convert.ToInt32(gvNewsletters.DataKeys[row.RowIndex]["idnewsletter"])
                        newsletterEntity newsletter = new newsletterEntity();
                        newsletter.titolo = ((Label)gvNewsletters.Rows[row.RowIndex].FindControl("lblTitolo")).Text;
                        newsletter.testo = ((Label)gvNewsletters.Rows[row.RowIndex].FindControl("lblTesto")).Text;
                        newsletterList.Add(newsletter);
                    }
                }
            }

            //Se l'admin ha selezionato una o più newsletters da spedire

            if (newsletterList.Count > 0) {
                this.selectedNewsletters = newsletterList;

                List<ListItem> llItems = new List<ListItem>();
                DataView dv = AnagraficaGateway.SelectNewsletterEnabledUsers();
                foreach (DataRow li in dv.Table.Rows) {
                    ListItem item = new ListItem(" " + li[1].ToString() + " " + li[0].ToString() + " - " + li[2].ToString(), li[2].ToString());
                    llItems.Add(item);
                }
                cblDistribution.DataSource = llItems;
                cblDistribution.DataBind();
                foreach (ListItem c in cblDistribution.Items) {
                    c.Selected = true;
                }
                mvNewsletterManager.SetActiveView(viewDistribution);
            }

            this.BindData();
        }

        protected void ibtnSendMails_Click(object sender, ImageClickEventArgs e) {
            //TODO: Questa chiamata sarebbe da fare in un thread parallelo
            NewsletterGateway.DistributeNewsletterMailsToSelectedUsers(cblDistribution.Items, this.selectedNewsletters);
            Response.Redirect("~/Management/Newsletter.aspx");
        }
    }
}