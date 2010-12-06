using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

namespace Philinternational.Gateway.Account
{
    public class AccountFacilities
    {
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

        //TODO: Chiamata fisica al db (MOCKED TO TRUE)
        internal static bool Authenticate(string userName, string password)
        {
            //Se trova l'utente nel db fa questo:
            AccountFacilities.SetLogInfos(new logInfos(userName, password, true)); //Ho messo a true che vuol dire che é anche amministratore
            return true;

            //altrimenti fa questo (scommentare):
            //return false;
        }

        internal static bool IsLogged()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        internal static void SetLogInfos(logInfos logInfos)
        {
            //TODO: Da centralizzare la gestione delle sessioni
            HttpContext.Current.Session["log"] = logInfos;
        }
    }
}