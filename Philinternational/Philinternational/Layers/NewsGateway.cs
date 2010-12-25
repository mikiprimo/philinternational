using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Philinternational.Layers {
    /// <summary>
    /// Operational functions About News (News.aspx and NewsDetails.aspx)
    /// </summary>
    public class NewsGateway {
        private static String _SELECT = ConfigurationManager.AppSettings["SelectNewsById"].ToString();
        private static String _INSERT = "INSERT INTO NEWS (idnews, data_pubblicazione, titolo, testo, stato) VALUES (@idNews, @data_pubblicazione, @titolo, @testo, @valueStato)";
        private static String _UPDATE = "UPDATE NEWS SET titolo = @titolo, testo = @testo, stato = @stato WHERE idnews = @idNews";
        private static String _UPDATE_NEWSSTATE = "UPDATE NEWS SET stato = @stato WHERE idnews = @idNews";
        //Da modificare ... specia neh! faccio il bagordo di natale e poi stasera finisco!!!!
        private static String _DELETE_IDNEWSLIST = "DELETE FROM forum_members WHERE e_mail='email@email.it' OR e_mail'=email2@email.it' OR e_mail='email3@email.it'";

        /// <summary>
        /// NEWS (Get News By ID)
        /// </summary>
        /// <param name="codice"></param>
        /// <returns></returns>
        internal static NewsEntity GetNewsById(string codice) {
            MySqlDataReader dr;
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_SELECT, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("codice", codice);
            NewsEntity myOnlyNews;
            try {
                conn.Open();
                dr = command.ExecuteReader();
                myOnlyNews = new NewsEntity();
                if (dr != null) {
                    while (dr.Read()) {
                        DateTime.TryParse(dr["data_pubblicazione"].ToString(), out myOnlyNews.dataPubblicazione);
                        myOnlyNews.titolo = (String)dr["titolo"];
                        myOnlyNews.testo = (String)dr["testo"];
                        myOnlyNews.state = new Stato((int)dr["stato"], Layers.Commons.GetStato((int)dr["stato"]));
                    }
                }
            } catch (MySql.Data.MySqlClient.MySqlException) {
                return null;
            } finally {
                conn.Close();
            }
            return myOnlyNews;
        }

        /// <summary>
        /// NEWS (Insert)
        /// </summary>
        /// <param name="MyNews"></param>
        /// <returns></returns>
        internal static Boolean InsertNews(NewsEntity MyNews) {
            MySqlDataReader dr;
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_INSERT, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idNews", MyNews.id);
            command.Parameters.AddWithValue("data_pubblicazione", MyNews.dataPubblicazione);
            command.Parameters.AddWithValue("titolo", MyNews.titolo);
            command.Parameters.AddWithValue("testo", MyNews.testo);
            command.Parameters.AddWithValue("stato", MyNews.state.id);
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
        /// NEWS (UPDATE)
        /// </summary>
        /// <param name="MyNews"></param>
        internal static Boolean UpdateNews(NewsEntity MyNews) {
            MySqlDataReader dr;
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idNews", MyNews.id);
            command.Parameters.AddWithValue("titolo", MyNews.titolo);
            command.Parameters.AddWithValue("testo", MyNews.testo);
            command.Parameters.AddWithValue("stato", MyNews.state.id);
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
        /// NEWS (UPDATE STATUS BY ID)
        /// </summary>
        /// <param name="idNews"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        internal static Boolean UpdateNewsStateById(string idNews, int newState) {
            MySqlDataReader dr;
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE_NEWSSTATE, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idNews", idNews);
            command.Parameters.AddWithValue("stato", newState);
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

        internal static void DeleteNewsByIdList(List<string> NewsIdToBeErased) {
            // AAHAHHAHAHHAHHAHAHRGHH! Ma ci arrivo neh!! e poi anche la cancellazione funzia
        }
    }
}