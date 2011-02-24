using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Philinternational.Layers {
    public class NewsletterGateway {

        private static String SELECT_NEWSLETTERS = "SELECT idnewsletter, data_creazione, titolo, testo FROM newsletter";
        private static String INSERT_NEWSLETTER = "INSERT INTO newsletter (idnewsletter, data_creazione, titolo, testo) VALUES (@idnewsletter, @data_creazione, @titolo, @testo)";
        private static String UPDATE_NEWSLETTER = "UPDATE newsletter  SET data_creazione = @data_creazione , titolo = @titolo, testo = @testo WHERE idnewsletter = @idnewsletter";

        /// <summary>
        /// SELECT NEWSLETTERS
        /// </summary>
        /// <returns></returns>
        internal static DataView SelectNewsletter() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_NEWSLETTERS, conn))
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
        /// DELETE NEWSLETTERS (A list of Newsletter)
        /// </summary>
        /// <param name="NewslettersIdToBeErased"></param>
        /// <returns></returns>
        internal static Boolean DeleteNewsletter(List<Int32> NewslettersIdToBeErased) {
            String _DELETE_NEWSLETTERS = "DELETE FROM newsletter WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (int item in NewslettersIdToBeErased) {
                sb.Append("idnewsletter = " + item.ToString() + " OR ");
            }
            sb.Append("1=0");

            _DELETE_NEWSLETTERS = _DELETE_NEWSLETTERS.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(_DELETE_NEWSLETTERS, conn);
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
        /// UPDATE NEWSLETTER
        /// </summary>
        /// <param name="MyNewsletter"></param>
        /// <returns></returns>
        internal static Boolean UpdateNewsletter(newsletterEntity MyNewsletter) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_NEWSLETTER, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idnewsletter", MyNewsletter.id);
            command.Parameters.AddWithValue("data_creazione", MyNewsletter.data_creazione);
            command.Parameters.AddWithValue("titolo", MyNewsletter.titolo);
            command.Parameters.AddWithValue("testo", MyNewsletter.testo);

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
        /// INSERT NEWSLETTER
        /// </summary>
        /// <param name="MyNewsletter"></param>
        /// <returns></returns>
        internal static Boolean InsertNewsletter(newsletterEntity MyNewsletter) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_NEWSLETTER, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idnewsletter", MyNewsletter.id);
            command.Parameters.AddWithValue("data_creazione", MyNewsletter.data_creazione);
            command.Parameters.AddWithValue("titolo", MyNewsletter.titolo);
            command.Parameters.AddWithValue("testo", MyNewsletter.testo);
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