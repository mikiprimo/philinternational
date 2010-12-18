using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Philinternational.Layers
{
    public class Commons
    {
        public static String GetStato(int id_stato) {
           return ((legendaStato)HttpContext.Current.Session["legendaStato"]).GetStatoById(id_stato).descrizione;
        }

        public static Boolean GetCheckedState(int value)
        {
            if (value == 1) return true;
            else return false;
        }
    }
}