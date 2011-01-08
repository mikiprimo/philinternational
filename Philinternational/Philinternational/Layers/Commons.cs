using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI;

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

        public static IDictionary<string, object> GetValuesGridViewRow(GridViewRow row) {
            IOrderedDictionary dictionary = new OrderedDictionary();
            foreach (Control control in row.Controls) {
                DataControlFieldCell cell = control as DataControlFieldCell;

                if ((cell != null) && cell.Visible) {
                    cell.ContainingField.ExtractValuesFromCell(dictionary, cell, row.RowState, true);
                }
            }

            IDictionary<string, object> values = new Dictionary<string, object>();
            foreach (DictionaryEntry de in dictionary) {
                values[de.Key.ToString()] = de.Value;
            }
            return values;
        }

        public static String EpuratePriceForDBFloat(String prezzo) {
            String nuovoPrezzo = "";

            CharEnumerator charEnum = prezzo.GetEnumerator();
            Int32 counter = 0;
            Int32 convertedPw;
            while (charEnum.MoveNext()) {
                convertedPw = Convert.ToInt32(prezzo[counter]);
                if (convertedPw < 126) nuovoPrezzo = nuovoPrezzo + prezzo[counter];
                counter++;
            }
            nuovoPrezzo = nuovoPrezzo.Replace(",", "").Trim();
            return nuovoPrezzo;
        }
    }
}