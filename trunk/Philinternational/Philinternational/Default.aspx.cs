﻿using System;
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
            LottoRndOutput.InnerHtml = LoadLottiRandom();

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
    
     private String LoadLottiRandom() {

            String esitoLotto = "";
            String tmpLotto = "";

            MySqlDataReader dr;
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            String sql = "SELECT idlotto, id_argomento, id_subargomento, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone, stato FROM lotto where stato !=0 order by rand() limit 4";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            try{
                conn.Open();
                dr = command.ExecuteReader();
                if (dr != null)
                {
                    if (dr.HasRows) {
                        while (dr.Read())
                        {
                            elencoLotto a = new elencoLotto();
                            String esitoImmagine = a.loadImmagine(dr["idlotto"]);
                            String esitoOfferta = a.VerificaOfferta(dr["stato"],dr["idlotto"]);
                            tmpLotto  = "<div class=\"bloccoLotto\">\n";
                            tmpLotto += "<h4>"+ dr["idlotto"] + "</h4>\n";
                            tmpLotto += "<p>"+ esitoImmagine + "</p>\n";
                            tmpLotto += "<p>Anno: <span>"+ dr["anno"] + "</span></p>\n";
                            tmpLotto += "<p>"+ dr["descrizione"] + "</p>\n";
                            tmpLotto += "<p>Condizione: <span>"+ dr["tipo_lotto"] + "</span></p>\n";
                            tmpLotto += "<p>Prezzo: <span>"+ dr["euro"] + "</span></p>\n";
                            tmpLotto += "<p class=\"lottoOfferta\">"+ esitoOfferta + "</p>\n";
                            tmpLotto += "</div>";

                            esitoLotto += tmpLotto; 
                        }//end while
                    }
                }//end if

            }//end try
            catch (MySql.Data.MySqlClient.MySqlException){
                            return "Errore ";
           }
                        finally {
                            conn.Close();
                        }
        
        return esitoLotto;
        }   
    }



}
