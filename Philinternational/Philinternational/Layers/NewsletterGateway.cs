using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace Philinternational.Layers {
    public class NewsletterGateway {

        private static String _SELECT = "SELECT idnewsletter, data_creazione, titolo, testo FROM newsletter";

        internal static DataView SelectNewsletter() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(_SELECT, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
                try {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dv = dt.DefaultView;

                    return dv;
                } catch (MySqlException) {
                    return dv;
                }
            }
        }

        internal static void DeleteNewsletter(List<int> list) {
            throw new NotImplementedException();
        }

        internal static void UpdateNewsletter(newsletterEntity MyNewsletter) {
            throw new NotImplementedException();
        }
    }
}