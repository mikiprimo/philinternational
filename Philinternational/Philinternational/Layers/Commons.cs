﻿using System;
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

        public static Boolean GetStatoBoolean(int id_stato) {
            return GetStato(id_stato) == "attivo" ? true : false;
        }

        public static Boolean GetCheckedState(int value)
        {
            if (value == 1) return true;
            else return false;
        }

        public static int GetCheckedState(Boolean b)
        {
            if (b) return 1;
            else return 0;
        }

        internal static string GetStatoDescription(int p) {
            return p == 1 ? "attivo" : "sospeso";
        }
    }
}