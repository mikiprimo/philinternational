using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Philinternational.Layers;

namespace Philinternational.Management {
    public partial class AnagraficaDetail : System.Web.UI.Page {
        protected void Page_PreInit(object sender, EventArgs e) {
            if (!((logInfos)HttpContext.Current.Session["log"]).IsAdmin) Response.Redirect("~/Default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (GeneralUtilities.GetQueryString(Request.QueryString, "email") != null) {
                    this.userProfileMask.oldEmail = GeneralUtilities.GetQueryString(Request.QueryString, "email");
                }
                if (this.userProfileMask.oldEmail != null) this.userProfileMask.LoadFormData();
                else Response.Redirect("~/Management/Anagrafica.aspx");
            }
        }
    }
}