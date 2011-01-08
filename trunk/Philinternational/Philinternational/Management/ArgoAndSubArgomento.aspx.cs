using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Styles
{
    public partial class SubArgomento : System.Web.UI.Page
    {
        public int currentID {
            get { return (int)ViewState["currentID"]; }
            set { ViewState["currentID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.currentID = Convert.ToInt32(Request.QueryString["Query"]);
                BindData();
            }
        }

        private void BindData() {
            gvArguments.DataSource = ParagrafoGateway.SelectArgs(this.currentID);
            gvArguments.DataBind();
            gvSubArguments.DataBind();
        }

        protected void gvArguments_RowEditing(object sender, GridViewEditEventArgs e) {
            gvArguments.EditIndex = e.NewEditIndex;
            this.BindData();
        }

        protected void gvArguments_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            GridViewRow row = gvArguments.Rows[e.RowIndex];
            var newValues = Commons.GetValuesGridViewRow(row);

            ParagArgomentoEntity MyArgument = new ParagArgomentoEntity();
            MyArgument.id = Convert.ToInt32(gvArguments.DataKeys[e.RowIndex]["idargomento"]);
            MyArgument.idparagrafo = Convert.ToInt32(gvArguments.DataKeys[e.RowIndex]["idparagrafo"]);
            MyArgument.descrizione = (String)newValues["descrizione"];
            MyArgument.state = new Stato(((CheckBox)gvArguments.Rows[e.RowIndex].FindControl("chkUpdateStatus")).Checked == true ? 1 : 0, "");

            ParagrafoGateway.UpdateParagArgomento(MyArgument);
            gvArguments.EditIndex = -1;
            this.BindData();
        }

        protected void gvArguments_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {
            int selectedArgumentID = Convert.ToInt32(gvArguments.DataKeys[e.NewSelectedIndex]["idargomento"]);
            gvSubArguments.DataSource = ParagrafoGateway.SelectSubArgs(selectedArgumentID);
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
            MySubArgument.id = Convert.ToInt32(gvArguments.DataKeys[e.RowIndex]["idsub_argomento"]);
            MySubArgument.idargomento = Convert.ToInt32(gvArguments.DataKeys[e.RowIndex]["idargomento"]);
            MySubArgument.descrizione = (String)newValues["descrizione"];
            MySubArgument.state = new Stato(((CheckBox)gvArguments.Rows[e.RowIndex].FindControl("chkUpdateStatus")).Checked == true ? 1 : 0, "");

            ParagrafoGateway.UpdateParagSubArgomento(MySubArgument);
            gvArguments.EditIndex = -1;
            this.BindData();
        }
    }
}