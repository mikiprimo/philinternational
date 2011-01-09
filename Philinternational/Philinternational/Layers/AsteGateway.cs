using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Philinternational.Layers {
    public class AsteGateway {

        private static String _SELECT = "SELECT idasta, data_fine, stato FROM asta_elenco";

        internal static DataView SelectAste() {
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
    }
}