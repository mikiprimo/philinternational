using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Styles {
    public partial class SubArgomento : System.Web.UI.Page {
        public int selectedParagrafoID {
            get { return (int)ViewState["selectedParagrafoID"]; }
            set { ViewState["selectedParagrafoID"] = value; }
        }

        public int selectedArgumentID {
            get { return (int)ViewState["selectedArgumentID"]; }
            set { ViewState["selectedArgumentID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.selectedParagrafoID = Convert.ToInt32(Request.QueryString["Query"]);
                BindData();
            }
        }

        private void BindData() {
            gvArguments.DataSource = ParagrafoGateway.SelectArgs(this.selectedParagrafoID);
            gvArguments.DataBind();
            try {
                gvSubArguments.DataSource = ParagrafoGateway.SelectSubArgs(this.selectedArgumentID);
                gvSubArguments.DataBind();
            } catch (Exception) { }
        }

        protected void gvArguments_RowEditing(object sender, GridViewEditEventArgs e) {
            gvArguments.EditIndex = e.NewEditIndex;
            this.BindData();
        }

        protected void gvArguments_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            GridViewRow row = gvArguments.Rows[e.RowIndex];
            var newValues = Commons.GetValuesGridViewRow(row);

            paragArgomentoEntity MyArgument = new paragArgomentoEntity();
            MyArgument.id = Convert.ToInt32(gvArguments.DataKeys[e.RowIndex]["idargomento"]);
            MyArgument.idparagrafo = Convert.ToInt32(gvArguments.DataKeys[e.RowIndex]["idparagrafo"]);
            MyArgument.descrizione = (String)newValues["descrizione"];
            MyArgument.state = new Stato(((CheckBox)gvArguments.Rows[e.RowIndex].FindControl("chkUpdateStatus")).Checked == true ? 1 : 0, "");

            ParagrafoGateway.UpdateParagArgomento(MyArgument);
            gvArguments.EditIndex = -1;
            this.BindData();
        }

        protected void gvArguments_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {
            this.selectedArgumentID = Convert.ToInt32(gvArguments.DataKeys[e.NewSelectedIndex]["idargomento"]);
            gvSubArguments.DataSource = ParagrafoGateway.SelectSubArgs(this.selectedArgumentID);
            gvSubArguments.DataBind();
        }

        //ROW EDITING

        protected void gvSubArguments_RowEditing(object sender, GridViewEditEventArgs e) {
            gvSubArguments.EditIndex = e.NewEditIndex;
            this.BindData();
        }

        protected void gvSubArguments_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            GridViewRow row = gvSubArguments.Rows[e.RowIndex];
            var newValues = Commons.GetValuesGridViewRow(row);

            paragSubArgomentoEntity MySubArgument = new paragSubArgomentoEntity();
            MySubArgument.id = Convert.ToInt32(gvSubArguments.DataKeys[e.RowIndex]["idsub_argomento"]);
            MySubArgument.idargomento = Convert.ToInt32(gvSubArguments.DataKeys[e.RowIndex]["idargomento"]);
            MySubArgument.descrizione = (String)newValues["descrizione"];
            MySubArgument.state = new Stato(((CheckBox)gvSubArguments.Rows[e.RowIndex].FindControl("chkUpdateStatus")).Checked == true ? 1 : 0, "");

            ParagrafoGateway.UpdateParagSubArgomento(MySubArgument);
            gvSubArguments.EditIndex = -1;
            this.BindData();
        }

        //Delete sub args
        protected void ibtnDeleteSelectedSubArgs_Click(object sender, ImageClickEventArgs e) {
            List<Int32> list = new List<int>();

            foreach (GridViewRow row in gvSubArguments.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) list.Add((int)gvSubArguments.DataKeys[row.RowIndex]["idsub_argomento"]);
                }
            }
            if (list.Count > 0) ParagrafoGateway.DeleteSubArguments(list);
            this.BindData();
        }

        protected void ibtnDeleteSelectedArgs_Click(object sender, ImageClickEventArgs e) {
            List<Int32> list = new List<Int32>();

            foreach (GridViewRow row in gvArguments.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) list.Add((int)gvArguments.DataKeys[row.RowIndex]["idargomento"]);
                }
            }
            if (list.Count > 0) ParagrafoGateway.DeleteArguments(list);
            this.BindData();
        }

        protected void ibtnCreateNewArgument_Click(object sender, ImageClickEventArgs e) {
            Response.Redirect("ArgomentoDetail.aspx?Query=" + this.selectedParagrafoID);
        }
    }
}