using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Philinternational.Management {
    public partial class AnagraficaDetail : System.Web.UI.Page {
        protected void Page_PreInit(object sender, EventArgs e) {
            if (!User.Identity.IsAuthenticated) Server.Transfer("~/Default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}