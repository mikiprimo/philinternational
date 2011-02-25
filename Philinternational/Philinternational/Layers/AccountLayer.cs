using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

namespace Philinternational.Layers
{
    public class AccountLayer
    {
        internal static Boolean Authenticate(string eMail, string password)
        {
            logInfos userInfos = AccountGateway.GetUserInfos(eMail, password);
            return userInfos.IsAuthenticated;
        }

        internal static bool IsLogged()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        internal static bool IsAdministrator()
        {
            if (HttpContext.Current.Session["log"] != null)
            {
                logInfos logInfos = (logInfos)HttpContext.Current.Session["log"];
                return logInfos.IsAdmin;
            }
            else return false;
        }
    }
}