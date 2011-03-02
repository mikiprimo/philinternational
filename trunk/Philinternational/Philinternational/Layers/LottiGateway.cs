using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Philinternational.Layers {
    public class LottiGateway {

        private static String SELECT_LOTTI = "SELECT idlotto, id_argomento, id_subargomento, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone, stato FROM lotto ORDER BY idlotto ASC";
        private static String SELECT_LOTTI_TEMPORANEI = "SELECT idcatalogo, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone FROM lotto_tmp ORDER BY idcatalogo ASC";
        private static String SELECT_LOTTI_SCARTATI = "SELECT idlotto_scartato, testo FROM lotto_scartato ORDER BY idlotto_scartato ASC";

        private static String SELECT_LOTTI_BY_ID = "SELECT idlotto, id_argomento, id_subargomento, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone, stato FROM lotto WHERE idlotto = @idlotto";
        private static String SELECT_LOTTI_TEMPORANEI_BY_ID = "SELECT idcatalogo, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone FROM lotto_tmp WHERE idcatalogo = @idcatalogo";
        private static String INSERT_LOTTO_TEMPORANEO = "INSERT INTO lotto_tmp (idcatalogo, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone) VALUES (@idcatalogo, @conferente, @anno, @tipo_lotto, @numero_pezzi, @descrizione, @prezzo_base, @euro, @riferimento_sassone)";
        private static String INSERT_LOTTO = "INSERT INTO lotto (idlotto, id_argomento, id_subargomento, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone, stato) VALUES (@idlotto, @id_argomento, @id_subargomento, @conferente, @anno, @tipo_lotto, @numero_pezzi, @descrizione, @prezzo_base, @euro, @riferimento_sassone, @stato)";
        private static String TRUNCATE_ALL_LOTTO_TABLES = "TRUNCATE TABLE       lotto_tmp; TRUNCATE TABLE       lotto_scartato; TRUNCATE TABLE       lotto;";
        private static String UPDATE_STATO_BY_ID_LOTTO = "UPDATE lotto SET stato = @stato WHERE idlotto = @idlotto";
        private static String UPDATE_LOTTO_DETAIL = "UPDATE lotto SET id_argomento = @id_argomento, id_subargomento = @id_subargomento, conferente = @conferente, anno = @anno, tipo_lotto = @tipo_lotto, numero_pezzi = @numero_pezzi, descrizione = @descrizione, prezzo_base = @prezzo_base, euro = @euro, riferimento_sassone = @riferimento_sassone WHERE idlotto = @idlotto";
        private static String UPDATE_LOTTO_TEMPORANEO_DETAIL = "UPDATE lotto_tmp SET conferente = @conferente, anno = @anno, tipo_lotto = @tipo_lotto, numero_pezzi = @numero_pezzi, descrizione = @descrizione, prezzo_base = @prezzo_base, euro = @euro, riferimento_sassone = @riferimento_sassone WHERE idcatalogo = @idcatalogo";

        internal static DataView SelectLotti() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_LOTTI, conn))
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

        internal static DataView SelectLottiById(Int32 id) {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_LOTTI_BY_ID, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
                try {
                    cmd.Parameters.AddWithValue("idlotto", id);
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

        internal static DataView SelectLottiTemporanei() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_LOTTI_TEMPORANEI, conn))
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

        internal static DataView SelectLottiTemporaneiById(Int32 id) {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_LOTTI_TEMPORANEI_BY_ID, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
                try {
                    cmd.Parameters.AddWithValue("idcatalogo", id);
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

        internal static DataView SelectLottiScartati() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_LOTTI_SCARTATI, conn))
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

            MySqlCommand command = new MySqlCommand(INSERT_LOTTO_TEMPORANEO, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idcatalogo", list[0]);
            command.Parameters.AddWithValue("conferente", list[1]);
            command.Parameters.AddWithValue("anno", list[2]);
            command.Parameters.AddWithValue("tipo_lotto", list[3]);
            command.Parameters.AddWithValue("numero_pezzi", list[4]);
            String newstring = Commons.EpurateInvalidCharacters(list[5]);
            command.Parameters.AddWithValue("descrizione", newstring);
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


        internal static Boolean InsertLotto(lottoEntity newLotto) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_LOTTO, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idlotto", newLotto.id);
            command.Parameters.AddWithValue("id_argomento", newLotto.id_argomento);
            command.Parameters.AddWithValue("id_subargomento", newLotto.id_subargomento);
            command.Parameters.AddWithValue("conferente", newLotto.conferente);
            command.Parameters.AddWithValue("anno", newLotto.anno);
            command.Parameters.AddWithValue("tipo_lotto", newLotto.tipo_lotto);
            command.Parameters.AddWithValue("numero_pezzi", newLotto.numero_pezzi);
            command.Parameters.AddWithValue("descrizione", newLotto.descrizione);
            command.Parameters.AddWithValue("prezzo_base", newLotto.prezzo_base);
            command.Parameters.AddWithValue("euro", newLotto.euro);
            command.Parameters.AddWithValue("riferimento_sassone", newLotto.riferimento_sassone);
            command.Parameters.AddWithValue("stato", new Stato(99, "da attivare").id);

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

        internal static Boolean InsertNewLotto(lottoEntity newLotto) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_LOTTO, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idlotto", newLotto.id);
            command.Parameters.AddWithValue("id_argomento", newLotto.id_argomento);
            command.Parameters.AddWithValue("id_subargomento", newLotto.id_subargomento);
            command.Parameters.AddWithValue("conferente", newLotto.conferente);
            command.Parameters.AddWithValue("anno", newLotto.anno);
            command.Parameters.AddWithValue("tipo_lotto", newLotto.tipo_lotto);
            command.Parameters.AddWithValue("numero_pezzi", newLotto.numero_pezzi);
            command.Parameters.AddWithValue("descrizione", newLotto.descrizione);
            command.Parameters.AddWithValue("prezzo_base", newLotto.prezzo_base);
            command.Parameters.AddWithValue("euro", newLotto.euro);
            command.Parameters.AddWithValue("riferimento_sassone", newLotto.riferimento_sassone);
            command.Parameters.AddWithValue("stato", newLotto.state.id);

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
        /// 
        /// </summary>
        /// <param name="idlotto"></param>
        internal static Boolean UpdateStatoByIDLotto(int idlotto, int stato) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_STATO_BY_ID_LOTTO, conn);
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

            MySqlCommand commandTruncate = new MySqlCommand(TRUNCATE_ALL_LOTTO_TABLES, conn);
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
            DataView dv = ParagrafoGateway.SelectArgomentiByListaParagrafi(ParList);

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

        public String[] getArgumentsByLotto(String idLotto) {
            String sql = "SELECT id_argomento, id_subargomento FROM lotto WHERE idlotto=" + idLotto;
            string[] str = new string[2];
            str[0] = "";
            str[1] = "";
            DataView dr = ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                str[0] = dr[i]["id_argomento"].ToString();
                str[1] = dr[i]["id_subargomento"].ToString();
            }
            return str;
        }

        private Boolean searchImageFromDisk(String idLotto) {
            Boolean stato = false;
            String nome_file = idLotto + ".jpg";
            String tmpPath = "";

            tmpPath = System.Web.HttpContext.Current.Server.MapPath(".") + "\\..\\images\\asta\\";
            DirectoryInfo MyDir = new DirectoryInfo(tmpPath);
            if (MyDir.Exists == true) {
                foreach (FileInfo file in MyDir.GetFiles()) {
                    if (file.Name == nome_file) return true;
                }
                return stato;
            } else {
                return stato;
            }

        }


        public String LoadImageByLotto(String NamePageYes, String NamePageNo, String idLotto) {

            String outputImmagine = "";
            bool esito = searchImageFromDisk(idLotto);
            if (esito) {
                String path = NamePageYes + idLotto + ".jpg";
                outputImmagine = "<a href=\"" + path + "\" rel=\"shadowbox;handleOversize:resize\" title=\"Lotto " + idLotto + "\" id=\"shadowimages\"><img src=\"" + path + "\" width=\"100\" height=\"100\" alt=\"Lotto " + idLotto + "\"/></a>\n";
            } else {
                outputImmagine = "<img src=\"" + NamePageNo + "\" width=\"100\" height=\"100\" alt=\"Lotto " + idLotto + "\"/>";
            }
            return outputImmagine;

        }

        public String getValueByField(String idlotto, String FieldName) {
            String sql = "SELECT " + FieldName + " valore FROM lotto WHERE idlotto=" + idlotto + "";
            String valore = "--";
            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                valore = dr[i]["valore"].ToString();
            }

            return valore;
        }

        /// <summary>
        /// Data una lista di ID Lotti ne elimina i relativi records
        /// </summary>
        /// <param name="list"></param>
        internal static Boolean DeleteLotti(List<Int32> LottiIdToBeErased) {
            String DELETE_LOTTI = "DELETE FROM lotto WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (int item in LottiIdToBeErased) {
                sb.Append("idlotto = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");

            DELETE_LOTTI = DELETE_LOTTI.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(DELETE_LOTTI, conn);
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

        internal static Boolean DeleteLottiTemporanei(List<Int32> LottiIdToBeErased) {
            String DELETE_LOTTI_TEMPORANEI = "DELETE FROM lotto_tmp WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (int item in LottiIdToBeErased) {
                sb.Append("idcatalogo = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");

            DELETE_LOTTI_TEMPORANEI = DELETE_LOTTI_TEMPORANEI.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(DELETE_LOTTI_TEMPORANEI, conn);
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

        internal static Boolean UpdateLotti(lottoEntity updateLotto) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_LOTTO_DETAIL, conn);
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("id_argomento", updateLotto.id_argomento);
            command.Parameters.AddWithValue("id_subargomento", updateLotto.id_subargomento);
            command.Parameters.AddWithValue("idlotto", updateLotto.id);
            command.Parameters.AddWithValue("conferente", updateLotto.conferente);
            command.Parameters.AddWithValue("anno", updateLotto.anno);
            command.Parameters.AddWithValue("tipo_lotto", updateLotto.tipo_lotto);
            command.Parameters.AddWithValue("numero_pezzi", updateLotto.numero_pezzi);
            command.Parameters.AddWithValue("descrizione", updateLotto.descrizione);
            command.Parameters.AddWithValue("prezzo_base", updateLotto.prezzo_base);
            command.Parameters.AddWithValue("euro", updateLotto.euro);
            command.Parameters.AddWithValue("riferimento_sassone", updateLotto.riferimento_sassone);

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

        internal static Boolean UpdateLottiTemporanei(lottoEntity newLotto) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_LOTTO_TEMPORANEO_DETAIL, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idcatalogo", newLotto.id);
            command.Parameters.AddWithValue("conferente", newLotto.conferente);
            command.Parameters.AddWithValue("anno", newLotto.anno);
            command.Parameters.AddWithValue("tipo_lotto", newLotto.tipo_lotto);
            command.Parameters.AddWithValue("numero_pezzi", newLotto.numero_pezzi);
            command.Parameters.AddWithValue("descrizione", newLotto.descrizione);
            command.Parameters.AddWithValue("prezzo_base", newLotto.prezzo_base);
            command.Parameters.AddWithValue("euro", newLotto.euro);
            command.Parameters.AddWithValue("riferimento_sassone", newLotto.riferimento_sassone);

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

        internal static Boolean AttivaLottiSelezionati(List<int> lottiToBeActivated) {
            String ACTIVATE_SELECTED_LOTTI = "UPDATE lotto SET stato = 1 WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (int item in lottiToBeActivated) {
                sb.Append("idlotto = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");

            ACTIVATE_SELECTED_LOTTI = ACTIVATE_SELECTED_LOTTI.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(ACTIVATE_SELECTED_LOTTI, conn);
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

        internal static void TransferLotti(List<Int32> listLottiTemporaneiId, String ArgId, String subArgId, Boolean isStateActive) {
            foreach (Int32 thisLottoId in listLottiTemporaneiId) {
                lottoEntity toBeTransferedLotto = new lottoEntity();
                DataView lotto = new DataView();
                lotto = SelectLottiTemporaneiById(thisLottoId);

                toBeTransferedLotto.id_argomento = Convert.ToInt32(ArgId);
                if (subArgId != "") toBeTransferedLotto.id_subargomento = Convert.ToInt32(subArgId);

                toBeTransferedLotto.id = Convert.ToInt32(lotto[0]["idcatalogo"].ToString());
                toBeTransferedLotto.conferente = lotto[0]["conferente"].ToString();
                toBeTransferedLotto.anno = lotto[0]["anno"].ToString();
                toBeTransferedLotto.tipo_lotto = lotto[0]["tipo_lotto"].ToString();
                toBeTransferedLotto.numero_pezzi = Convert.ToInt32(lotto[0]["numero_pezzi"].ToString());
                toBeTransferedLotto.descrizione = lotto[0]["descrizione"].ToString();
                toBeTransferedLotto.prezzo_base = Convert.ToDouble(lotto[0]["prezzo_base"].ToString()); //TODO: da verificare se scrive il prezzo giusto
                toBeTransferedLotto.euro = lotto[0]["euro"].ToString();
                toBeTransferedLotto.riferimento_sassone = lotto[0]["riferimento_sassone"].ToString();
                if (isStateActive) toBeTransferedLotto.state = new Stato(1, "attivo");
                else toBeTransferedLotto.state = new Stato(99, "da attivare");

                InsertNewLotto(toBeTransferedLotto);
                lotto.Delete(0);
            }
            DeleteLottiTemporanei(listLottiTemporaneiId);
        }
    }
}