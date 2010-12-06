using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

namespace Philinternational.Layers
{
    public class AccountLayer
    {
        internal static bool Authenticate(string userName, string password)
        {
            //Se trova l'utente nel db fa questo:

            logInfos userInfos = AccountDBTasks.GetUserInfos(userName, password);
            return userInfos.IsAuthenticated;
        }

        internal static bool IsLogged()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        internal static bool IsAdministrator()
        {
            //TODO: Impl. Verifica se l'utente registrato é un amministratore
            if (HttpContext.Current.Session["log"] != null)
            {
                logInfos logInfos = (logInfos)HttpContext.Current.Session["log"];
                return logInfos.IsAdmin;
            }
            else return false;
        }
    }
}