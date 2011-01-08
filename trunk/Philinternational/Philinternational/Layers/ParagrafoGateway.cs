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
        internal static Boolean UpdateParag(paragrafoEntity MyParagrafo) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idparagrafo", MyParagrafo.idparagrafo);
            command.Parameters.AddWithValue("descrizione", MyParagrafo.descrizione);
            command.Parameters.AddWithValue("stato", MyParagrafo.state.id);

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
                    } catch (MySqlException) {
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
                } catch (MySqlException) {
                    return dv;
                }
            }
        }

        /// <summary>
        /// UPDATE ARGUMENT
        /// </summary>
        /// <param name="MyArgument"></param>
        /// <returns></returns>
        internal static Boolean UpdateParagArgomento(paragArgomentoEntity MyArgument) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE_ARGUMENTS, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idargomento", MyArgument.id);
            command.Parameters.AddWithValue("descrizione", MyArgument.descrizione);
            command.Parameters.AddWithValue("stato", MyArgument.state.id);

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
                } catch (MySqlException) {
                    return dv;
                }
            }
        }

        /// <summary>
        /// UPDATE SUB ARGUMENT
        /// </summary>
        /// <param name="MySubArgument"></param>
        /// <returns></returns>
        internal static Boolean UpdateParagSubArgomento(paragSubArgomentoEntity MySubArgument) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE_SUBARGUMENT, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idsub_argomento", MySubArgument.id);
            command.Parameters.AddWithValue("descrizione", MySubArgument.descrizione);
            command.Parameters.AddWithValue("stato", MySubArgument.state.id);

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
        /// DELETE SUB ARGUMENTS LIST
        /// </summary>
        /// <param name="p"></param>
        internal static Boolean DeleteSubArguments(List<Int32> SubArgsIdToBeErased) {
            String _DELETE_SUBARGUMENTS = "DELETE FROM paragrafo_subargomento WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (int item in SubArgsIdToBeErased) {
                sb.Append("idsub_argomento = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");

            _DELETE_SUBARGUMENTS = _DELETE_SUBARGUMENTS.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(_DELETE_SUBARGUMENTS, conn);
            command.CommandType = CommandType.Text;
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
        /// ARGUMENTS AND SUB ARGUMENTS (DELETE Arguments and all dependencies (subArgs and Lotto states)
        /// </summary>
        /// <param name="ArgsIdToBeErased"></param>
        /// <returns></returns>
        internal static Boolean DeleteArguments(List<Int32> ArgsIdToBeErased) {
            String _DELETE_ARGUMENTS = "DELETE FROM paragrafo_argomento WHERE @ComposedConditions";
            String _DELETE_SUBARGUMENTS = "DELETE FROM paragrafo_subargomento WHERE @ComposedConditions";

            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (int item in ArgsIdToBeErased) {
                sb.Append("idargomento = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");
            //TODO: Update also lotto states
            _DELETE_ARGUMENTS = _DELETE_ARGUMENTS.Replace("@ComposedConditions", sb.ToString());
            _DELETE_SUBARGUMENTS = _DELETE_SUBARGUMENTS.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(_DELETE_ARGUMENTS, conn);
            command.CommandType = CommandType.Text;
            MySqlCommand commandSubArgs = new MySqlCommand(_DELETE_ARGUMENTS, conn);
            commandSubArgs.CommandType = CommandType.Text;
            try {
                conn.Open();
                command.ExecuteNonQuery();
                commandSubArgs.ExecuteNonQuery();
            } catch (MySql.Data.MySqlClient.MySqlException) {
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }
    }
}