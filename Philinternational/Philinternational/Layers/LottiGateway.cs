using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace Philinternational.Layers {
    public class LottiGateway {

        private static String _INSERT_ARGUMENT = "INSERT INTO lotto_tmp (idcatalogo, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone) VALUES (@idcatalogo, @conferente, @anno, @tipo_lotto, @numero_pezzi, @descrizione, @prezzo_base, @euro, @riferimento_sassone)";
        private static String _TRUNCATE_ALL_LOTTO_TABLES = "TRUNCATE TABLE       lotto_tmp; TRUNCATE TABLE       lotto_scartato; TRUNCATE TABLE       lotto;";

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
    }
}