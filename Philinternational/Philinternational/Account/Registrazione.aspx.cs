using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Philinternational.Account {
    public partial class Registrazione : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) { divDomicilio.Visible = false;
            }
        }

        protected void rb_CheckedChanged(object sender, EventArgs e) {
            if (rbSi.Checked) divDomicilio.Visible = true;
            else divDomicilio.Visible = false;
        }

        protected void CreateUserButton_Click(object sender, EventArgs e) {

        }
    }
}