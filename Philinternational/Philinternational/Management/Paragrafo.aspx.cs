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
            if(!IsPostBack) BindData();
        }

        private void BindData() {
            gvParagrafi.DataSource = ParagrafoGateway.SelectParag();
            gvParagrafi.DataBind();
        }

        protected void gvParagrafi_RowEditing(object sender, GridViewEditEventArgs e) {
            gvParagrafi.EditIndex = e.NewEditIndex;
            this.BindData();
        }

        protected void gvParagrafi_RowUpdating(object sender, GridViewUpdateEventArgs e) {

            GridViewRow row = gvParagrafi.Rows[e.RowIndex];
            var newValues = Commons.GetValuesGridViewRow(row);

            ParagrafoEntity MyParagrafo = new ParagrafoEntity();
            MyParagrafo.descrizione = (String)newValues["descrizione"];
            MyParagrafo.idparagrafo = Convert.ToInt32(gvParagrafi.DataKeys[e.RowIndex]["idparagrafo"]);
            MyParagrafo.state = new Stato(((CheckBox)gvParagrafi.Rows[e.RowIndex].FindControl("chkUpdateStatus")).Checked == true ? 1:0, "");

            ParagrafoGateway.UpdateParag(MyParagrafo);

            gvParagrafi.EditIndex = -1;
            this.BindData();
        }

        

        protected void gvParagrafi_PageIndexChanged(object sender, EventArgs e) {
            this.BindData();
        }
    }
}