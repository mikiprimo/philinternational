using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace Philinternational.Layers {
    public class AsteGateway {

        private static String _SELECT = "SELECT idasta, data_fine, stato FROM asta_elenco";
        private static String _INSERT_ASTA = "INSERT INTO asta_elenco (idasta, data_fine, stato) VALUES (@idasta, @data_fine, @stato)";
        private static String _UPDATE_ASTA = "UPDATE asta_elenco  SET idasta = @idasta, data_fine = @data_fine , stato = @stato WHERE idasta = @idasta";

        /// <summary>
        /// SELECT ASTE
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// DELETE a list of ASTE
        /// </summary>
        /// <param name="AsteIdToBeErased"></param>
        /// <returns></returns>
        internal static Boolean DeleteAste(List<Int32> AsteIdToBeErased) {
            String _DELETE_ASTE = "DELETE FROM asta_elenco WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (int item in AsteIdToBeErased) {
                sb.Append("idasta = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");

            _DELETE_ASTE = _DELETE_ASTE.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(_DELETE_ASTE, conn);
            command.CommandType = CommandType.Text;
            try {
                conn.Open();
                command.ExecuteNonQuery();
            } catch (MySqlException) {
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }

        /// <summary>
        /// INSERT ASTA
        /// </summary>
        /// <param name="MyAsta"></param>
        /// <returns></returns>
        internal static bool InsertAsta(astaEntity MyAsta) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_INSERT_ASTA, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idasta", MyAsta.id);
            command.Parameters.AddWithValue("data_fine", MyAsta.data_fine);
            command.Parameters.AddWithValue("stato", MyAsta.state.id);
            try {
                conn.Open();
                command.ExecuteNonQuery();
            } catch (MySql.Data.MySqlClient.MySqlException) {
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }

        /// <summary>
        /// UPDATE ASTA
        /// </summary>
        /// <param name="MyAsta"></param>
        /// <returns></returns>
        internal static Boolean UpdateAsta(astaEntity MyAsta) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE_ASTA, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idasta", MyAsta.id);
            command.Parameters.AddWithValue("data_fine", MyAsta.data_fine);
            command.Parameters.AddWithValue("stato", MyAsta.state.id);

            try {
                conn.Open();
                command.ExecuteNonQuery();
            } catch (MySqlException) {
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }

    }
}