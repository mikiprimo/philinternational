using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text;

namespace Philinternational.Layers {
    /// <summary>
    /// Operational functions About News (News.aspx and NewsDetails.aspx)
    /// </summary>
    public class NewsGateway {
        private static String SELECT_NEWS = "SELECT idnews, DATE_FORMAT(data_pubblicazione,'%d.%m.%Y') as data_pubblicazione, titolo, testo, stato FROM news ORDER BY data_pubblicazione DESC";
        private static String SELECT_NEWS_BY_ID = "SELECT idnews,titolo,testo,DATE_FORMAT(data_pubblicazione,'%d.%m.%Y') as data_pubblicazione,stato from news where idnews=@codice";//ConfigurationManager.AppSettings["SelectNewsById"].ToString();
        private static String INSERT_NEWS = "INSERT INTO NEWS (idnews, data_pubblicazione, titolo, testo, stato) VALUES (@idNews, @data_pubblicazione, @titolo, @testo, @valueStato)";
        private static String UPDATE_NEWS = "UPDATE NEWS SET titolo = @titolo, testo = @testo, stato = @stato WHERE idnews = @idNews";
        private static String UPDATE_NEWS_STATE = "UPDATE NEWS SET stato = @stato WHERE idnews = @idNews";

        /// <summary>
        /// Select all news
        /// </summary>
        /// <returns></returns>
        internal static DataView SelectNews() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_NEWS, conn))
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
        /// NEWS (Get News By ID)
        /// </summary>
        /// <param name="codice"></param>
        /// <returns></returns>
        internal static newsEntity GetNewsById(String codice) {
            MySqlDataReader dr;
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(SELECT_NEWS_BY_ID, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("codice", codice);
            newsEntity myOnlyNews;
            try {
                conn.Open();
                dr = command.ExecuteReader();
                myOnlyNews = new newsEntity();
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
        ///INSERT NEWS
        /// </summary>
        /// <param name="MyNews"></param>
        /// <returns></returns>
        internal static Boolean InsertNews(newsEntity MyNews) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_NEWS, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idnews", MyNews.id);
            command.Parameters.AddWithValue("data_pubblicazione", MyNews.dataPubblicazione);
            command.Parameters.AddWithValue("titolo", MyNews.titolo);
            command.Parameters.AddWithValue("testo", MyNews.testo);
            command.Parameters.AddWithValue("valueStato", MyNews.state.id);
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
        /// UPDATE NEWS
        /// </summary>
        /// <param name="MyNews"></param>
        internal static Boolean UpdateNews(newsEntity MyNews) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_NEWS, conn);
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
        internal static Boolean UpdateNewsStateById(String idNews, Int32 newState) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_NEWS_STATE, conn);
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

        /// <summary>
        /// NEWS (DELETE NEWS BY A LIST OF NEWSID)
        /// </summary>
        /// <param name="NewsIdToBeErased"></param>
        /// <returns></returns>
        internal static Boolean DeleteNewsByIdList(List<String> NewsIdToBeErased) {
            String _DELETE_IDNEWSLIST = "DELETE FROM NEWS WHERE @ComposedConditions";

            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (String item in NewsIdToBeErased) {
                sb.Append("idnews = " + item + " OR ");
            }
            sb.Append("1=0");

            _DELETE_IDNEWSLIST = _DELETE_IDNEWSLIST.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(_DELETE_IDNEWSLIST, conn);
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