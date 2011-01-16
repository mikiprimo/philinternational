using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Philinternational.Layers {
    public class LottiGateway {

        private static String _SELECT = "SELECT idlotto, id_argomento, id_subargomento, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone, stato FROM lotto";
        private static String _INSERT_ARGUMENT = "INSERT INTO lotto_tmp (idcatalogo, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone) VALUES (@idcatalogo, @conferente, @anno, @tipo_lotto, @numero_pezzi, @descrizione, @prezzo_base, @euro, @riferimento_sassone)";
        private static String _TRUNCATE_ALL_LOTTO_TABLES = "TRUNCATE TABLE       lotto_tmp; TRUNCATE TABLE       lotto_scartato; TRUNCATE TABLE       lotto;";
        private static String _UPDATE_LOTTI = "UPDATE lotto SET stato = @stato WHERE idlotto = @idlotto";


        internal static object SelectLotti() {
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
        /// Inserimento Lotto (Usato SOLO dalla procedura di popolamento lotti)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        internal static Boolean InsertLotto(List<String> list) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_INSERT_ARGUMENT, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idcatalogo", list[0]);
            command.Parameters.AddWithValue("conferente", list[1]);
            command.Parameters.AddWithValue("anno", list[2]);
            command.Parameters.AddWithValue("tipo_lotto", list[3]);
            command.Parameters.AddWithValue("numero_pezzi", list[4]);
            command.Parameters.AddWithValue("descrizione", list[5]);
            String nuovoPrezzo = Commons.EpuratePriceForDBFloat(list[6]);
            command.Parameters.AddWithValue("prezzo_base", nuovoPrezzo);
            command.Parameters.AddWithValue("euro", list[7]);
            command.Parameters.AddWithValue("riferimento_sassone", list[8]);

            try {
                conn.Open();
                command.ExecuteNonQuery();
            } catch (MySqlException) {
                return false; //TODO: sbattere nella scartati quelli che non é riuscita a piazzare nella tmp
            } finally {
                conn.Close();
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idlotto"></param>
        internal static Boolean UpdateStatoByIDLotto(int idlotto, int stato) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE_LOTTI, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idlotto", idlotto);
            command.Parameters.AddWithValue("stato", stato);

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
        /// Pulisce e resetta le tabelle lotto (tmp, scartati e lotti)
        /// </summary>
        /// <returns></returns>
        internal static Boolean TruncateAll() {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand commandTruncate = new MySqlCommand(_TRUNCATE_ALL_LOTTO_TABLES, conn);
            commandTruncate.CommandType = CommandType.Text;

            try {
                conn.Open();
                commandTruncate.ExecuteNonQuery();
            } catch (MySqlException) {
                return false;
            } finally {
                conn.Close();
            }
            return true;

        }

        /// <summary>
        /// Epura idarg e idsubarg della lotto dati una lista di paragrafi
        /// </summary>
        /// <param name="ParList"></param>
        /// <returns></returns>
        internal static Boolean EpurateLottoByParagraphs(List<Int32> ParList) {
            DataView dv = ParagrafoGateway.SelectArgumentsByParagraphsList(ParList);

            //Fase 3: Metto la collection in una lista e la passo alla funzione che epura gli argomenti/subargomenti
            List<Int32> list = new List<int>();
            for (int i = 0; i < dv.Count; i++) {
                list.Add(Convert.ToInt32(dv[i][0]));
            }
            Boolean esito = EpurateLottoByArguments(list);
            return esito;
        } 

        /// <summary>
        /// Epura idarg e idsubarg della lotto dati una lista di argomenti
        /// </summary>
        /// <param name="ArgList"></param>
        /// <returns></returns>
        internal static Boolean EpurateLottoByArguments(List<Int32> ArgList) { 
            String _EPURATE_LOTTO_ARGS = "UPDATE lotto SET id_argomento = NULL, id_subargomento = NULL WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            StringBuilder sb = new StringBuilder();
            foreach (int item in ArgList) {
                sb.Append("id_argomento = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");
            _EPURATE_LOTTO_ARGS = _EPURATE_LOTTO_ARGS.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(_EPURATE_LOTTO_ARGS, conn);
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
        /// Epura idsubarg della lotto dati una lista di subargomenti
        /// </summary>
        /// <param name="SubArgList"></param>
        /// <returns></returns>
        internal static Boolean EpurateLottoBySubArguments(List<Int32> SubArgList) {
            String _EPURATE_LOTTO_SUBARGS = "UPDATE lotto SET id_subargomento = NULL WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            StringBuilder sb = new StringBuilder();
            foreach (int item in SubArgList) {
                sb.Append("id_subargomento = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");
            _EPURATE_LOTTO_SUBARGS = _EPURATE_LOTTO_SUBARGS.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(_EPURATE_LOTTO_SUBARGS, conn);
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

        
    }
}