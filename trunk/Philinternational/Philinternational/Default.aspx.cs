using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;

namespace Philinternational
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            infoOutput.InnerHtml = lodRotationNews();

        }

        private static String lodRotationNews()
        {
            String elencoNews_head = "<ul id=\"ticker\">\n";
            String elencoNews_body = "";
            String elencoNews_end = "</ul>\n";
            String elencoNews;
            MySqlDataReader dr;
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            String sql = "SELECT data_pubblicazione, titolo,testo FROM news where stato=1 order by data_pubblicazione DESC";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                conn.Open();
                dr = command.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        elencoNews_body += "<li>";
                        elencoNews_body += "<span>" + (String)dr["titolo"] + "</span>\n";
                        elencoNews_body += "<p>" + (String)dr["testo"] + "</p>\n";
                        elencoNews_body += "</li>\n";
                    }//end while
                }//fine dr!= null

            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                elencoNews_body = "<li>Nessuna Notizia presente<br/></li>\n";
                elencoNews =   elencoNews_head + elencoNews_body + elencoNews_end;
                return elencoNews;
            }
            finally
            {
                conn.Close();
            }

            elencoNews = elencoNews_head + elencoNews_body + elencoNews_end;
            return elencoNews;

        }
    }
}
