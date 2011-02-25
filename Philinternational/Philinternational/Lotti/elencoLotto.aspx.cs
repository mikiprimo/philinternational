using System;
using System.IO;
using System.Web.Security;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace Philinternational
{
    public partial class elencoLotto : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           // string qualePagina = this.Context.Items["fileName"].ToString();
            if (!IsPostBack)
            {
                int? numPage = 1;
                if (Request["p"] != null) numPage = Int32.Parse(Request["p"]);
                int limitForPage = 10;

                String codargomento = Request["arg"];
                String subargomento = Request["subarg"];
               
                getTitle(codargomento, subargomento);
                BindData(codargomento, subargomento, (int)numPage, limitForPage);
            }
        }
        protected void getTitle(String codargomento, String subargomento)
        {
            String sql = "";
            String descrizione_argomento = "";
            String descrizione_paragrafo = "";
            if (subargomento == null || subargomento == "0")
            {
                sql = "Select a.descrizione descrizione_argomento,b.descrizione descrizione_paragrafo from paragrafo_argomento a, paragrafo b  where a.idparagrafo = b.idparagrafo and idargomento=" + codargomento + "";
            }
            else {
                sql = "Select a.descrizione descrizione_argomento,c.descrizione descrizione_paragrafo from paragrafo_subargomento a, paragrafo_argomento b,paragrafo c  where c.idparagrafo = b.idparagrafo and a.idargomento = b.idparagrafo and a.idsub_argomento=" + codargomento + "";
            }

            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);

            for(int i=0;i<dr.Count;i++){
                descrizione_argomento = dr[i]["descrizione_argomento"].ToString();
                descrizione_paragrafo = dr[i]["descrizione_paragrafo"].ToString();
            }
            titlePage.InnerText = "Lotti presenti per l'argomento:" + descrizione_argomento;
            navigazioneOutput.InnerHtml = "<div class=\"navigazione\"><ul><li class=\"navTit1\">" + descrizione_paragrafo + "</li>--><li class=\"navTit2\"><a href=\"" + Page.ResolveClientUrl("~/Lotti/elencoLotto.aspx?arg=" + codargomento + "&subarg=" + subargomento) + "\">" + descrizione_argomento + "</a></li></ul></div>\n";
            
        
        }
        private void BindData(String codargomento, String subargomento, int numPage, int limitForPage)
        {
            String sql="";
            String limite = calcLimitForPage(codargomento, subargomento, numPage, limitForPage);
            if (subargomento == null || subargomento == "0")
            {
                sql = "SELECT idlotto, id_argomento, id_subargomento, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone, stato FROM lotto WHERE id_argomento=" + codargomento + "" + limite;
            }
            else
            {
                sql = "SELECT idlotto, id_argomento, id_subargomento, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone, stato FROM lotto WHERE id_subargomento=" + subargomento + "" + limite;
            }
            numPagineOutput.InnerHtml= showNumberPage( codargomento,  subargomento,  numPage,  limitForPage);
            LottoConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            LottoConnector.SelectCommand = sql;
            LottoConnector.DataBind();
        }
        public String loadImmagine(Object idLotto){
            LottiGateway a = new LottiGateway();
            String  chiave = idLotto.ToString();
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
            String outputVerifica = "<a href=\"" + Page.ResolveClientUrl("~/Lotti/offerta.aspx?cod=" + chiave + "&arg=" + idArgomento + "&subarg=" + idSubArgomento) + "\">Fai immediatamente l'offerta</a>\n";
            if (AccountLayer.IsLogged()) {
                OfferteGateway a = new OfferteGateway();
                int idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
                bool checkOfferta = a.checkOffertaGiaPresente(idAnagrafica, chiave);
                if (checkOfferta == true) { outputVerifica = "Offerta già effettuata"; }
                switch (stato)
                {
                    case "0": outputVerifica = "Lotto non disponibile"; break;
                }
            
            }
            return outputVerifica;
        }
        private String calcLimitForPage(String codargomento, String subargomento, int numPage, int limitForPage)
        {
            String tmpSql = "";
            String Esito;
            String limiteLotto = "0";
            int partenza = 0;
            /* STEP 2 -  ottengo il numero, il min ed il max per il paragrafo specifico*/
            String sql = "Select count(*) totale_lotti FROM lotto where stato!=0 and ";
            if (subargomento == null || subargomento == "0")
                tmpSql = "id_argomento=" + codargomento;
            else
                tmpSql = "id_subargomento=" + subargomento;

            sql += tmpSql;

            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                limiteLotto = dr[i]["totale_lotti"].ToString();
            }
            //dr.Close();
            /* STEP 3 scrittura finale della stringa*/
            Double recordperPagina;
            recordperPagina = Convert.ToInt32(limiteLotto) / limitForPage;
            if (recordperPagina <= 1) { 
                partenza  =0 + (limitForPage * (numPage - 1));
            } else {
                partenza = limitForPage * (numPage - 1);
            }

            Esito = " LIMIT "+ partenza +"," + limitForPage;
            return Esito;
        
        }
        private String showNumberPage(String codargomento, String subargomento, int numPage, int limitForPage)
        {

            String tmpSql = "";
            String Esito="";
            String limiteLotto = "0";
            /* STEP 2 -  ottengo il numero, il min ed il max per il paragrafo specifico*/
            String sql = "Select count(*) totale_lotti FROM lotto where stato!=0 and ";
            if (subargomento == null || subargomento == "0")
            {
                tmpSql = "id_argomento=" + codargomento;
            }
            else
            {
                tmpSql = "id_subargomento=" + subargomento;
            }

            sql += tmpSql;

            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                limiteLotto = dr[i]["totale_lotti"].ToString();
            }


            /* STEP 3 scrittura finale della stringa*/
            Double recordperPagina;
            recordperPagina = Convert.ToInt32(limiteLotto) / limitForPage;
            if (recordperPagina <= 1)
            {
                //Esito = "<div class=\"numPagina\">&nbsp;</div>";
                Esito = "";
            }
            else
            {
                tmpSql = "<div class=\"numPagina\"><ul>";
                for (int i = 1; i <= recordperPagina; i++)
                {
                    String iSelected = "";
                    if (i == numPage) iSelected = "class=\"bold\"";
                    tmpSql += "<li " + iSelected  + "><a href=\"" + Page.ResolveClientUrl("~/Lotti/elencoLotto.aspx?arg=" + codargomento + "&subarg=" + subargomento + "&p=" + i + "") + "\">" + i + "</a></li>";
                }
                tmpSql += "</ul></div>";
                Esito = tmpSql;
            }

            return Esito;        
        
        }
        public Boolean addToBasket(String idLotto) {
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
        protected void R_ItemCommand(Object source, RepeaterCommandEventArgs e)
        {
            String idLotto = e.CommandArgument.ToString();
            OfferteGateway o = new OfferteGateway();
            String idAnagrafica = "";
            if (AccountLayer.IsLogged())
            {
                idAnagrafica = (((logInfos)Session["log"]).idAnagrafica).ToString();
            }
            else {
                idAnagrafica = Session.SessionID;
            }
            Boolean esitoCheck = o.CheckLottoCarrello(idAnagrafica, idLotto);
            if (esitoCheck)
            {
                ((Label)e.Item.FindControl("linkBasketAdded")).Visible = true;
                ((LinkButton)e.Item.FindControl("linkBasket")).Visible = false;
            
            }else{
                Boolean a = addToBasket(idLotto);
                if (a) {
                    ((Label)e.Item.FindControl("linkBasketAdded")).Visible = true;
                    ((LinkButton)e.Item.FindControl("linkBasket")).Visible = false;
                }
            }
        }
        protected void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            object idlotto = e.Item.FindControl("idlotto");
            String chiave = ((System.Web.UI.HtmlControls.HtmlContainerControl)(idlotto)).InnerHtml;
            ((System.Web.UI.WebControls.LinkButton)(e.Item.FindControl("linkBasket"))).CommandName = "AddToBasket";
            ((LinkButton)(e.Item.FindControl("linkBasket"))).CommandArgument = chiave;
            OfferteGateway o = new OfferteGateway();
            String idAnagrafica = "";
            if (AccountLayer.IsLogged())
            {
                idAnagrafica = (((logInfos)Session["log"]).idAnagrafica).ToString();
            }
            else
            {
                idAnagrafica = Session.SessionID;
            }
            Boolean esitoCheck = o.CheckLottoCarrello(idAnagrafica, chiave);
            if (esitoCheck)
            {
                ((Label)e.Item.FindControl("linkBasketAdded")).Visible = true;
                ((LinkButton)e.Item.FindControl("linkBasket")).Visible = false;

            }
        }    
    }
    
}