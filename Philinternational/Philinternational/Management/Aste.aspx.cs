using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational.Styles
{
    public partial class Aste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.BindData();
            }
        }

        private void BindData() {
            gvAste.DataSource = AsteGateway.SelectAste();
            gvAste.DataBind();
        }

        protected void ibtnCreateAsta_Click(object sender, ImageClickEventArgs e) {
            Response.Redirect("AstaDetail.aspx");
        }

        protected void ibtnDeleteSelectedAste_Click(object sender, ImageClickEventArgs e) {
            List<Int32> list = new List<Int32>();

            foreach (GridViewRow row in gvAste.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkUserSelection");
                    if (chk.Checked) list.Add(Convert.ToInt32(gvAste.DataKeys[row.RowIndex]["idasta"]));
                }
            }
            if (list.Count > 0) AsteGateway.DeleteAste(list);
            this.BindData();
        }

        protected void gvAste_RowEditing(object sender, GridViewEditEventArgs e) {
            gvAste.EditIndex = e.NewEditIndex;
            this.BindData();
        }

        //TODO: Da testare ancora
        protected void gvAste_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            GridViewRow row = gvAste.Rows[e.RowIndex];
            var newValues = Commons.GetValuesGridViewRow(row);

            astaEntity MyAsta = new astaEntity();
            MyAsta.id = Convert.ToInt32(gvAste.DataKeys[e.RowIndex]["idasta"]);
            MyAsta.data_fine = DateTime.Parse((String)newValues["data_fine"]);
            MyAsta.state = new Stato(((CheckBox)gvAste.Rows[e.RowIndex].FindControl("chkUpdateStatus")).Checked == true ? 1 : 0, "");

            AsteGateway.UpdateAsta(MyAsta);

            gvAste.EditIndex = -1;
            this.BindData();
        }

        protected void gvAste_PageIndexChanged(object sender, EventArgs e) {
            this.BindData();
        }

        protected void gvAste_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.gvAste.PageIndex = e.NewPageIndex;
            this.BindData();
        }
    }
}