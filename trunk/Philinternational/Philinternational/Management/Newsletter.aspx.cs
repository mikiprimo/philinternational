using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
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

        public List<NewsletterEntity> selectedNewsletters {
            get { return ((List<NewsletterEntity>)ViewState["idNewsletters"]); }
            set { ViewState["idNewsletters"] = value; }
        }

        private void IsViewGridVisible(Boolean bol) {
            if (bol) mvNewsletterManager.SetActiveView(viewGrid);
            else mvNewsletterManager.SetActiveView(viewDistribution);
        }

        private void BindData() {
            gvNewsletters.DataSource = NewsletterGateway.SelectNewsletters();
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

            NewsletterEntity MyNewsletter = new NewsletterEntity();
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
            List<NewsletterEntity> newsletterList = new List<NewsletterEntity>();

            foreach (GridViewRow row in gvNewsletters.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) {
                        //Convert.ToInt32(gvNewsletters.DataKeys[row.RowIndex]["idnewsletter"])
                        NewsletterEntity newsletter = new NewsletterEntity();
                        String idNewsletter = gvNewsletters.DataKeys[row.RowIndex]["idnewsletter"].ToString();

                        String sql = "SELECT titolo, testo FROM newsletter WHERE idnewsletter = "+ idNewsletter +"";
                        MySqlConnection conn = ConnectionGateway.ConnectDB();
                        MySqlDataReader dr;
                        MySqlCommand command = command = new MySqlCommand(sql, conn);
                        command.CommandType = System.Data.CommandType.Text;
                        String titolo = ""; 
                        String testo = "";

                        try
                        {
                            conn.Open();
                            dr = command.ExecuteReader();
                            if (dr != null){
                                while (dr.Read()) {
                                    titolo = (String)dr["titolo"];
                                    testo = (String)dr["testo"];
                                }
                                newsletter.titolo = titolo;
                                newsletter.testo = testo;
                                //newsletter.titolo = (String)(row.Cells[row.RowIndex].FindControl("hlNewsDetail"));
                                //newsletter.testo = (row.Cells[row.RowIndex].FindControl("txtUpdateTesto")).ToString();
                                newsletterList.Add(newsletter);
                            }
                        }
                        catch (Exception ex){
                            ErrorInside.InnerHtml = "Problema in fase di lettura newsletter. contattare il webmaster [" +  ex +"]";
                            newsletterList.Clear();
                        }

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

        protected void ibtnEditNewsletter_Click(object sender, ImageClickEventArgs e) {
            Response.Redirect("NewsletterDetail.aspx?idnl=" + gvNewsletters.DataKeys[0]["idnewsletter"].ToString());
        }
    }
}