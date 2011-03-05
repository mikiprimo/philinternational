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
        private static String SELECT_PARAGRAFI = "SELECT idparagrafo, descrizione, stato FROM paragrafo";
        private static String SELECT_ID_PARAGRAFO = "SELECT idparagrafo FROM paragrafo_argomento WHERE idargomento = @idargomento";
        private static String UPDATE_PARAGRAFO = "UPDATE paragrafo SET descrizione = @descrizione, stato =@stato WHERE idparagrafo = @idparagrafo";
        //ARGOMENTI
        private static String SELECT_ARGOMENTI = "SELECT idargomento, idparagrafo, descrizione, stato FROM paragrafo_argomento";
        private static String SELECT_ARGOMENTI_BY_IDPARAGRAFO = "SELECT idargomento, idparagrafo, descrizione, stato FROM paragrafo_argomento WHERE idparagrafo = @idparagrafo";
        private static String UPDATE_ARGOMENTI = "UPDATE paragrafo_argomento SET descrizione = @descrizione, stato = @stato WHERE idargomento = @idargomento";
        private static String INSERT_ARGOMENTI = "INSERT INTO paragrafo_argomento (idargomento, idparagrafo, descrizione, stato) VALUES (@idargomento, @idparagrafo, @descrizione, @stato)";
        //SUB ARGOMENTI
        private static String SELECT_SUBARGOMENTI_BYIDARGOMENTO = "SELECT idsub_argomento, idargomento, descrizione, stato FROM paragrafo_subargomento WHERE idargomento = @idargomento";
        private static String UPDATE_SUBARGOMENTI = "UPDATE paragrafo_subargomento SET descrizione = @descrizione, stato = @stato WHERE idsub_argomento = @idsub_argomento";
        private static String INSERT_SUBARGOMENTI = "INSERT INTO paragrafo_subargomento (idsub_argomento, idargomento, descrizione, stato) VALUES (@idsub_argomento, @idargomento, @descrizione, @stato)";
        private static string INSERT_PARAGRAFO = "INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES (@idparagrafo, @descrizione, @stato)";


        //----------PARAGRAFI-------------//

        /// <summary>
        /// UPDATE PARAGRAFO
        /// </summary>
        /// <param name="MyParagrafo"></param>
        /// <returns></returns>
        internal static Boolean UpdateParagrafi(paragrafoEntity MyParagrafo) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_PARAGRAFO, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idparagrafo", MyParagrafo.id);
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
        internal static DataView SelectParagrafi() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_PARAGRAFI, conn))
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

        internal static Int32 SelectIdParagrafo(Int32 actualIdArg) {
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_ID_PARAGRAFO, conn)) {
                try {
                    cmd.Parameters.AddWithValue("idargomento", actualIdArg);
                    conn.Open();
                    Int32 res = ((Int32)cmd.ExecuteScalar());
                    return res;
                } catch (MySqlException) {
                    return -1;
                }
            }
        }

        //----------ARGOMENTI-------------//

        /// <summary>
        /// SELECT ARGUMENTS
        /// </summary>
        /// <returns></returns>
        internal static DataView SelectArgomenti(Int32 idparagrafo) {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_ARGOMENTI_BY_IDPARAGRAFO, conn)) {
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
        /// SELECT ALL ARGUMENTS (For population pourpose in LottoDetail transfer lotto from tmp to published)
        /// </summary>
        /// <returns></returns>
        internal static DataView SelectAllArgomenti() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_ARGOMENTI, conn)) {
                try {
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
        internal static Boolean UpdateParagrafoArgomento(paragArgomentoEntity MyArgument) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_ARGOMENTI, conn);
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

        /// <summary>
        /// ARGUMENTS AND SUB ARGUMENTS : DELETE Arguments and all dependencies (subArgs and Lotto states)
        /// </summary>
        /// <param name="ArgsIdToBeErased"></param>
        /// <returns></returns>
        internal static Boolean DeleteArgomenti(List<Int32> ArgsIdToBeErased) {
            String _DELETE_ARGUMENTS = "DELETE FROM paragrafo_argomento WHERE @ComposedConditions";
            String _DELETE_SUBARGUMENTS = "DELETE FROM paragrafo_subargomento WHERE @ComposedConditions";

            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (int item in ArgsIdToBeErased) {
                sb.Append("idargomento = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");

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
                LottiGateway.EpurateLottoByArguments(ArgsIdToBeErased);
            }
            return true;
        }

        /// <summary>
        /// Data una lista di Paragrafi, ricava una lista di tutti gli argomenti distinti e coinvolti
        /// </summary>
        /// <param name="ParList"></param>
        /// <returns></returns>
        public static DataView SelectArgomentiByListaParagrafi(List<Int32> ParList) {
            String _EPURATE_LOTTO_PARAGRAPHS = "SELECT DISTINCT idargomento FROM paragrafo_argomento WHERE @ComposedConditions";

            //Fase 1: costruisco la query mettendo in ora la lista degli idparagrafo
            StringBuilder sb = new StringBuilder();
            foreach (int item in ParList) {
                sb.Append("idparagrafo = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");

            //Fase 2: Effettuo la query che restituisce una collection di idargomenti
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(_EPURATE_LOTTO_PARAGRAPHS, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
                try {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dv = dt.DefaultView;
                } catch (MySqlException) {
                }
            }
            return dv;
        }

        /// <summary>
        /// INSERT ARGUMENT
        /// </summary>
        /// <param name="MyArgument"></param>
        /// <returns></returns>
        internal static Boolean InsertArgomento(paragArgomentoEntity MyArgument) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_ARGOMENTI, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idargomento", MyArgument.id);
            command.Parameters.AddWithValue("idparagrafo", MyArgument.idparagrafo);
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

        //-------------SUB ARGOMENTI------------//

        /// <summary>
        /// SELECT SUB ARGUMENTS
        /// </summary>
        /// <param name="selectedArgumentID"></param>
        /// <returns></returns>
        internal static DataView SelectSubArgomentiByIdArgomento(Int32 selectedArgumentID) {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_SUBARGOMENTI_BYIDARGOMENTO, conn)) {
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

            MySqlCommand command = new MySqlCommand(UPDATE_SUBARGOMENTI, conn);
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
                LottiGateway.EpurateLottoBySubArguments(SubArgsIdToBeErased);
            }
            return true;
        }

        /// <summary>
        /// INSERT SUB ARGUMENT
        /// </summary>
        /// <param name="MySubArgument"></param>
        /// <returns></returns>
        internal static bool InsertSubArgomento(paragSubArgomentoEntity MySubArgument) {
            //TODO: Da testare (inserimento sub argomento)
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_SUBARGOMENTI, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idsub_argomento", MySubArgument.id);
            command.Parameters.AddWithValue("idargomento", MySubArgument.idargomento);
            command.Parameters.AddWithValue("descrizione", MySubArgument.descrizione);
            command.Parameters.AddWithValue("stato", MySubArgument.state.id);
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
        /// Inserimento nuovo paragrafo
        /// </summary>
        /// <param name="newParagrafo"></param>
        /// <returns></returns>
        internal static Boolean InsertParagrafo(paragrafoEntity newParagrafo) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_PARAGRAFO, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idparagrafo", newParagrafo.id);
            command.Parameters.AddWithValue("descrizione", newParagrafo.descrizione);
            command.Parameters.AddWithValue("stato", newParagrafo.state.id);
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
    }
}