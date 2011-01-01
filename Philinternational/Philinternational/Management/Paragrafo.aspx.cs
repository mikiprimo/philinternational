using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Philinternational.Layers;
using System.Collections.Specialized;
using System.Collections;

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

            ////ParagrafoEntity MyParagrafo = new ParagrafoEntity();
            ////MyParagrafo.descrizione = Description;
            ////MyParagrafo.idparagrafo = Convert.ToInt32(e.Keys[0].ToString());
            ////MyParagrafo.state = new Stato(Convert.ToInt32(State), "");
            ////this.BindData();
        }

        

        protected void gvParagrafi_PageIndexChanged(object sender, EventArgs e) {
            this.BindData();
        }
    }
}