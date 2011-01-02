using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text;

namespace Philinternational.Layers {
    /// <summary>
    /// Operational functions About Paragrafo
    /// </summary>
    public class ParagrafoGateway {
        //PARAGRAFI
        private static String _SELECT = "SELECT idparagrafo, descrizione, stato FROM paragrafo";
        private static String _UPDATE = "UPDATE paragrafo SET descrizione = @descrizione, stato =@stato WHERE idparagrafo = @idparagrafo";
        //ARGOMENTI
        private static String _SELECT_ARGUMENTS = "SELECT idargomento, idparagrafo, descrizione, stato WHERE idparagrafo = @idparagrafo";

        /// <summary>
        /// UPDATE PARAGRAFO
        /// </summary>
        /// <param name="MyParagrafo"></param>
        /// <returns></returns>
        internal static Boolean UpdateParag(ParagrafoEntity MyParagrafo) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idparagrafo", MyParagrafo.idparagrafo);
            command.Parameters.AddWithValue("descrizione", MyParagrafo.descrizione);
            command.Parameters.AddWithValue("stato", MyParagrafo.state.id);

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
        /// SELECT PARAGRAFI
        /// </summary>
        /// <returns></returns>
        internal static DataView SelectParag() {
            {
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
                    } catch  {
                        return dv;
                    }
                }
            }
        }

        /// <summary>
        /// SELECT ARGUMENTS
        /// </summary>
        /// <returns></returns>
        internal static DataView SelectArgs() {
            {
                DataView dv = new DataView();
                using (MySqlConnection conn = ConnectionGateway.ConnectDB())
                using (MySqlCommand cmd = new MySqlCommand(_SELECT_ARGUMENTS, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
                    try {
                        conn.Open();
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dv = dt.DefaultView;

                        return dv;
                    } catch {
                        return dv;
                    }
                }
            }
        }
    }
}