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
        private static String _SELECT_ARGUMENTS = "SELECT idargomento, idparagrafo, descrizione, stato FROM paragrafo_argomento WHERE idparagrafo = @idparagrafo";
        private static String _UPDATE_ARGUMENTS = "UPDATE paragrafo_argomento SET descrizione = @descrizione, stato = @stato WHERE idargomento = @idargomento";
        //SUB ARGOMENTI
        private static String _SELECT_SUBARGUMENTS = "SELECT idsub_argomento, idargomento, descrizione, stato FROM paragrafo_subargomento WHERE idargomento = @idargomento";
        private static String _UPDATE_SUBARGUMENT = "UPDATE paragrafo_subargomento SET descrizione = @descrizione, stato = @stato WHERE idsub_argomento = @idsub_argomento";


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
                    } catch {
                        return dv;
                    }
                }
            }
        }

        //----------ARGUMENTS-------------//

        /// <summary>
        /// SELECT ARGUMENTS
        /// </summary>
        /// <returns></returns>
        internal static DataView SelectArgs(int idparagrafo) {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(_SELECT_ARGUMENTS, conn)) {
                try {
                    cmd.Parameters.AddWithValue("idparagrafo", idparagrafo);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dv = dt.DefaultView;

                    return dv;
                } catch (Exception) {
                    return dv;
                }
            }
        }

        /// <summary>
        /// UPDATE ARGUMENT
        /// </summary>
        /// <param name="MyArgument"></param>
        /// <returns></returns>
        internal static Boolean UpdateParagArgomento(ParagArgomentoEntity MyArgument) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE_ARGUMENTS, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idargomento", MyArgument.id);
            command.Parameters.AddWithValue("descrizione", MyArgument.descrizione);
            command.Parameters.AddWithValue("stato", MyArgument.state.id);

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

        //-------------SUB ARGUMENTS------------//

        /// <summary>
        /// SELECT SUB ARGUMENTS
        /// </summary>
        /// <param name="selectedArgumentID"></param>
        /// <returns></returns>
        internal static DataView SelectSubArgs(int selectedArgumentID) {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(_SELECT_SUBARGUMENTS, conn)) {
                try {
                    cmd.Parameters.AddWithValue("idargomento", selectedArgumentID);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dv = dt.DefaultView;

                    return dv;
                } catch (Exception err) {
                    return dv;
                }
            }
        }

        internal static void UpdateParagSubArgomento(paragSubArgomentoEntity MySubArgument) {
            throw new NotImplementedException();
        }
    }
}