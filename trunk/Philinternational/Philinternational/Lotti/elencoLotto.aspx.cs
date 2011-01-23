﻿using System;
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
                sql = "";
            }

            MySqlDataReader dr = Layers.ConnectionGateway.SelectQuery(sql);
            if (!(dr == null))
            {
                while (dr.Read())
                {
                    descrizione_argomento = (string)dr["descrizione_argomento"];
                    descrizione_paragrafo = (string)dr["descrizione_paragrafo"];
                }
            }


            titlePage.InnerText = "Lotti presenti per l'argomento:" + descrizione_argomento;
            navigazioneOutput.InnerHtml = "<div class=\"navigazione\"><ul><li class=\"navTit1\">" + descrizione_paragrafo + "</li><li class=\"navTit2\"><a href=\"" + Page.ResolveClientUrl("~/Lotti/elencoLotto.aspx?arg=" + codargomento + "&subarg=" + subargomento) + "\">" + descrizione_argomento + "</a></li></ul></div>\n";

        
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

            String outputVerifica = "<a href=\"" + Page.ResolveClientUrl("~/Lotti/carrello.aspx?cod=" + chiave) + "\">Aggiungi al carrello</a>\n";
                   outputVerifica   += "<a href=\""+ Page.ResolveClientUrl("~/Lotti/offerta.aspx?cod="+ chiave +"&arg=" + idArgomento + "&subarg=" + idSubArgomento )+"\">Fai l'offerta</a>\n";
            if (AccountLayer.IsLogged()) {
                Offerte a = new Offerte();
                String idAnagrafica = "0";

                if (HttpContext.Current.Session["idanagrafica"] !=null)
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
        private String calcLimitForPage(String codargomento, String subargomento, int numPage, int limitForPage)
        {
            String tmpSql = "";
            String Esito;
            String limiteLotto ="";
            int partenza =0;
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
            MySqlDataReader dr = Layers.ConnectionGateway.SelectQuery(sql);
            if (!(dr == null))
            {
                while (dr.Read())
                {

                    limiteLotto =dr["totale_lotti"].ToString();
                }
            }
            else
            {
                limiteLotto = "0";

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
            String limiteLotto = "";
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
            MySqlDataReader dr = Layers.ConnectionGateway.SelectQuery(sql);
            if (!(dr == null))
            {
                while (dr.Read())
                {

                    limiteLotto = dr["totale_lotti"].ToString();
                }
            }
            else
            {
                limiteLotto = "0";

            }
            //dr.Close();
            /* STEP 3 scrittura finale della stringa*/
            Double recordperPagina;
            recordperPagina = Convert.ToInt32(limiteLotto) / limitForPage;
            if (recordperPagina <= 1)
            {
                Esito = "<div class=\"numPagina\">&nbsp;</div>";
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
    }
}