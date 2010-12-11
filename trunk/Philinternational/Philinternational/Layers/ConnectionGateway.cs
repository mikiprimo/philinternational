using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Philinternational.Layers
{
    public class ConnectionDBTasks
    {
        public static MySqlConnection ConnectDB()
        {
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["PhilinternationalConnectionString"].ToString());
            return conn;
        }

        public static String StringConnectDB()
        {
            return ConfigurationManager.ConnectionStrings["PhilinternationalConnectionString"].ToString();
            
        }
    }
}