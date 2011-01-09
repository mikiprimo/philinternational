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
    }
}