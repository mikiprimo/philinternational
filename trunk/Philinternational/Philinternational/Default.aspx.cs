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
            AsteGateway Asta = new AsteGateway();
            String[] esito = new String[2];
            DateTime a = new DateTime();
            esito = Asta.getDatiAsta();
            String tmp = esito.GetValue(1).ToString();
            numeroAsta.InnerHtml = esito.GetValue(0).ToString();
            tmp = tmp.Substring(0, 10);
            dataScadenza.InnerHtml = a.ToString(tmp);
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
                            String esitoImmagine = loadImmagine(dr["idlotto"]);
                            String esitoOfferta  = VerificaOfferta(dr["stato"],dr["idlotto"]);
                            tmpLotto  = "<div class=\"bloccoLotto\">\n";
                            tmpLotto += "<h4>"+ dr["idlotto"] + "</h4>\n";
                            tmpLotto += "<p>"+ esitoImmagine + "</p>\n";
                            tmpLotto += "<p>Anno: <span>"+ dr["anno"] + "</span></p>\n";
                            tmpLotto += "<p>"+ dr["descrizione"] + "</p>\n";
                            tmpLotto += "<p>Condizione: <span>"+ dr["tipo_lotto"] + "</span></p>\n";
                            tmpLotto += "<p>Prezzo: <span>"+ dr["euro"] + "</span></p>\n";
                            tmpLotto += "<p class=\"lottoOfferta\">"+ esitoOfferta + "</p>\n";
                            tmpLotto += "</div>\n";
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

     private String loadImmagine(Object idLotto)
     {
         LottiGateway a = new LottiGateway();
         String chiave = idLotto.ToString();
         String outputImmagine = a.LoadImageByLotto(Page.ResolveClientUrl("~/images/asta/"), Page.ResolveClientUrl("~/images/immagine_non_disponibile.jpg"), chiave);

         return outputImmagine;
     }

     private String VerificaOfferta(Object statoOfferta, Object idLotto)
     {
         String stato = statoOfferta.ToString();
         String chiave = idLotto.ToString();
         String idArgomento = "";
         String idSubArgomento = "";
         LottiGateway Lotti = new LottiGateway();
         String[] esito = new String[2];
         esito = Lotti.getArgumentsByLotto(chiave);
         idArgomento = esito.GetValue(0).ToString();
         idSubArgomento = esito.GetValue(1).ToString();

         String outputVerifica = "<a href=\"" + Page.ResolveClientUrl("~/Lotti/carrello.aspx?cod=" + chiave) + "\">Aggiungi al carrello</a>\n";
         outputVerifica += "<a href=\"" + Page.ResolveClientUrl("~/Lotti/offerta.aspx?cod=" + chiave + "&arg=" + idArgomento + "&subarg=" + idSubArgomento) + "\">Fai l'offerta</a>\n";
         if (AccountLayer.IsLogged())
         {
             Offerte a = new Offerte();
             String idAnagrafica = "0";

             if (HttpContext.Current.Session["idanagrafica"] != null)
             {
                 idAnagrafica = HttpContext.Current.Session["idanagrafica"].ToString();
             }

             bool checkOfferta = a.checkOffertaGiaPresente(idAnagrafica, chiave);
             if (checkOfferta == true) { outputVerifica = "Offerta già effettuata"; }
             switch (stato)
             {
                 case "0": outputVerifica = "Lotto non disponibile"; break;
             }

         }
         return outputVerifica;
     }
    }
}
