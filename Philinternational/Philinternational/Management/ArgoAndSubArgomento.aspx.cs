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
                this.currentID = 1;
                BindData();
            }
        }

        private void BindData() {
            gvArguments.DataSource = ParagrafoGateway.SelectArgs();
            gvArguments.DataBind();
        }
    }
}