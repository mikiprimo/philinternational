using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Philinternational.Layers
{
    public class Commons
    {
        public static String GetStato(int stato) {
            String retValue = "";
            String sql = "SELECT descrizione from legenda_stato where id_stato=" + stato;
            MySql.Data.MySqlClient.MySqlConnection conn = Layers.ConnectionGateway.ConnectDB();
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.CommandType = System.Data.CommandType.Text;
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    retValue = (String)dr["descrizione"];
                }
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return "--";
            }
            return retValue;
        }
    }
}