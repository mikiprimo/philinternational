using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text;


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

        public static MySqlDataReader SelectQueryOld(String sql)
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

        public static DataView SelectQuery(String sql)
        {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dv = dt.DefaultView;

                    return dv;
                }
                catch (MySqlException)
                {
                    return dv;
                }
                finally { conn.Close(); }
            }            
        }

        public static int ExecuteQuery(String sql, String tableName)
        {

            string sqlOptimize = "OPTIMIZE TABLE " + tableName; 
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlCommand commandOptmize = new MySqlCommand(sqlOptimize, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                commandOptmize.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
            return 0;
           
        }

        public static int CreateNewIndex(String idKey, String tableName)
        {
            int newIndex = -1;
            String sql = "SELECT MAX( " + idKey + " +1 ) indice FROM " + tableName + "";
            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                String a = dr[0]["indice"].ToString(); ;
                if (a == "") a = "1";
                newIndex = Convert.ToInt32(a);
            }

            return newIndex;
        }
        public static void closeConnection(MySql.Data.MySqlClient.MySqlConnection conn)
        {
            conn.Close();
        }
    }
}