using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Philinternational.Layers
{
    public class NewsGateway
    {
        internal static NewsEntity GetNewsById(string codice)
        {
            MySqlDataReader dr;
            MySqlConnection conn =  ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(ConfigurationManager.AppSettings["SelectNewsById"].ToString(),conn);
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.AddWithValue("codice", codice);
            NewsEntity myOnlyNews;
            try
            {
                conn.Open();
                dr = command.ExecuteReader();
                myOnlyNews = new NewsEntity();
                 if (dr != null) //diverso !=
                {
                    while (dr.Read())
                    {
                        DateTime.TryParse(dr["data_pubblicazione"].ToString(), out myOnlyNews.dataPubblicazione);
                        myOnlyNews.titolo = (String)dr["titolo"];
                        myOnlyNews.testo = (String)dr["testo"];
                        myOnlyNews.state = new Stato((int)dr["stato"],Layers.Commons.GetStato((int)dr["stato"]));;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return myOnlyNews;
        }

       
    }
}