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
            if (tmp.Length > 10)
                tmp = tmp.Substring(0, 10);
            else {
                tmp = "";
            }
            dataScadenza.InnerHtml = a.ToString(tmp);
            infoOutput.InnerHtml = lodRotationNews();
            BindData();

        }

        private void BindData()
        {
            String sql = "SELECT idlotto, id_argomento, id_subargomento, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone, stato FROM lotto where stato !=0 order by rand() limit 4";
            LottoConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            LottoConnector.SelectCommand = sql;
            LottoConnector.DataBind();
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
    
     public String loadImmagine(Object idLotto)
     {
         LottiGateway a = new LottiGateway();
         String chiave = idLotto.ToString();
         String outputImmagine = a.LoadImageByLotto(Page.ResolveClientUrl("~/images/asta/"), Page.ResolveClientUrl("~/images/immagine_non_disponibile.jpg"), chiave);

         return outputImmagine;
     }

     public String VerificaOfferta(Object statoOfferta, Object idLotto)
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

         String outputVerifica = "<a href=\"" + Page.ResolveClientUrl("~/Lotti/offerta.aspx?cod=" + chiave + "&arg=" + idArgomento + "&subarg=" + idSubArgomento) + "\">Fai l'offerta</a>\n";
         if (AccountLayer.IsLogged()==true){
              try
                {
                    OfferteGateway a = new OfferteGateway();
                    int idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
                    bool checkOfferta = a.checkOffertaGiaPresente(idAnagrafica, chiave);
                    if (checkOfferta == true) { outputVerifica = "L'Offerta è già stata effettuata"; }
                    switch (stato)
                    {
                        case "0": outputVerifica = "Lotto non disponibile"; break;
                    }
                }
                catch (Exception)
                {
                    outputVerifica = "Nessuna offerta possibile";
                }
             
         }
         return outputVerifica;
     }

     public Boolean addToBasket(String idLotto)
     {
         String chiave = idLotto.ToString();

         String idAnagrafica = Session.SessionID;
         if (AccountLayer.IsLogged())
         {
             idAnagrafica = (((logInfos)Session["log"]).idAnagrafica).ToString();
         }

         OfferteGateway carrello = new OfferteGateway();
         Boolean esito = carrello.insertCarrello(idAnagrafica, chiave);
         return esito;
     }

     protected void R_ItemCommand(object source, RepeaterCommandEventArgs e)
     {

         String idLotto = e.CommandArgument.ToString();
         Boolean a = addToBasket(idLotto);
         if (a)
             esitoOperazione.InnerHtml = "Articolo [" + idLotto + "] inserito nel carrello";
         else
             esitoOperazione.InnerHtml = "Articolo [" + idLotto + "] <b>non</b> inserito nel carrello";
         // soncazzo.InnerHtml = a.ToString();

     }

     protected void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
     {
         object idlotto = e.Item.FindControl("idlotto");
         String chiave = ((System.Web.UI.HtmlControls.HtmlContainerControl)(idlotto)).InnerHtml;
         ((System.Web.UI.WebControls.LinkButton)(e.Item.FindControl("linkBasket"))).CommandName = "AddToBasket";
         ((LinkButton)(e.Item.FindControl("linkBasket"))).CommandArgument = chiave;
     }    
    
    }
}
