using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Philinternational.Management {
    public partial class Profile : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (GeneralUtilities.GetQueryString(Request.QueryString, "email") != null) {
                    this.userProfileMask.oldEmail = GeneralUtilities.GetQueryString(Request.QueryString, "email");
                } else {
                    this.userProfileMask.oldEmail = ((logInfos)HttpContext.Current.Session["log"]).eMail;
                    this.userProfileMask.LoadFormData();
                }
                //if (this.userProfileMask.oldEmail != null) this.userProfileMask.LoadFormData();
                //Response.Redirect("~/Default.aspx");
            }
        }
    }
}