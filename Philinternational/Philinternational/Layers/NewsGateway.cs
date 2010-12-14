using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Philinternational.Layers
{
    public class NewsGateway
    {
        internal static MySqlDataReader GetNewsById(string codice)
        {
            MySqlDataReader dr;
            MySql.Data.MySqlClient.MySqlConnection conn = ConnectionGateway.ConnectDB();
            conn.Open();
            MySqlCommand command = new MySqlCommand(ConfigurationManager.AppSettings["SelectNewsById"].ToString(), conn);
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.AddWithValue("codice", codice);
            try
            {
                dr = command.ExecuteReader();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return dr;
        }
    }
}