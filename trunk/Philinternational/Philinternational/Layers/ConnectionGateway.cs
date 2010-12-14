using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Philinternational.Layers
{
    public class ConnectionGateway
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

        [Obsolete("Non usare: rifarsi ai vari gateway!!")]
        public static MySqlDataReader SelectQuery(String sql)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = ConnectDB();
            MySqlDataReader dr;
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.CommandType = System.Data.CommandType.Text;
                dr = command.ExecuteReader();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                String a = ex.StackTrace;
                conn.Close();
                return null;
            }

            return dr;
        }

        [Obsolete("Non usare: rifarsi ai vari gateway!!")]
        public static int ExecuteQuery(String sql, String tableName)
        {
            MySqlDataReader dr = SelectQuery(sql);
            if (!(dr == null))
            {
                string sqlOptimize = "OPTIMIZE TABLE" + tableName;
                MySqlDataReader optomizeSql = SelectQuery(sqlOptimize);
            }
            else
            {
                return -1;
            }
            return 0;
        }

        [Obsolete("Non usare: rifarsi ai vari gateway!!")]
        public static int CreateNewIndex(String idKey, String tableName)
        {
            int newIndex = 0;
            String sql = "SELECT MAX( " + idKey + " +1 ) indice FROM " + tableName + "";

            MySqlDataReader dr = SelectQuery(sql);
            if (!(dr == null))
            {
                while (dr.Read())
                {
                    newIndex = Convert.ToInt32(dr["indice"]);
                }
            }
            else
            {
                return -1;
            }
            return newIndex;
        }
    }
}