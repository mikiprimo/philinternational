using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace Philinternational.Layers {
    public class AsteGateway {

        private static String SELECT_ASTE = "SELECT idasta, data_fine, stato FROM asta_elenco";
        private static String INSERT_ASTA = "INSERT INTO asta_elenco (idasta, data_fine, stato) VALUES (@idasta, @data_fine, @stato)";
        private static String UPDATE_ASTA = "UPDATE asta_elenco  SET idasta = @idasta, data_fine = @data_fine , stato = @stato WHERE idasta = @idasta";

        /// <summary>
        /// SELECT ASTE
        /// </summary>
        /// <returns></returns>
        internal static DataView SelectAste() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_ASTE, conn))
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
            String DELETE_ASTE = "DELETE FROM asta_elenco WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (int item in AsteIdToBeErased) {
                sb.Append("idasta = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");

            DELETE_ASTE = DELETE_ASTE.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(DELETE_ASTE, conn);
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
        /// <param name="newAsta"></param>
        /// <returns></returns>
        internal static Boolean InsertAsta(astaEntity newAsta) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_ASTA, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idasta", newAsta.id);
            command.Parameters.AddWithValue("data_fine", newAsta.data_fine);
            command.Parameters.AddWithValue("stato", newAsta.state.id);
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
        /// <param name="newAsta"></param>
        /// <returns></returns>
        internal static Boolean UpdateAsta(astaEntity newAsta) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_ASTA, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idasta", newAsta.id);
            command.Parameters.AddWithValue("data_fine", newAsta.data_fine);
            command.Parameters.AddWithValue("stato", newAsta.state.id);

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

        public String[] GetDatiAsta()
        {
            String sql = "SELECT max(idasta) valore, data_fine FROM asta_elenco WHERE stato=1";
            String idAsta = "";
            String dataFine = "";
            string[] str = new string[2];
            str[0] = "--";
            str[1] = "";
            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                idAsta = dr[i]["valore"].ToString();                
                dataFine = dr[i]["data_fine"].ToString();
                if (idAsta == null) idAsta = "--";
                str[0] = idAsta;
                str[1] = dataFine;
            }

            return str;
        }

        public Boolean GetAstaAttiva()
        {
            String sql = "SELECT max(idasta) valore, stato FROM asta_elenco";;
            String stato = "";
            Boolean esito = false;
            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                stato = dr[i]["stato"].ToString();
                if (stato == "0") esito = false; else esito = true;
            }
            return esito;
        }

        public static String GetNumAstaAttiva() {
            String sql = "SELECT max(idasta) valore FROM asta_elenco"; ;
            String valore = "";

            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++)
            {
                valore = dr[i]["valore"].ToString();
            }
            return valore;
        
        
        }
    }
}