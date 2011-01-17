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

namespace Philinternational
{
    public partial class elencoLotto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int numPage = 1;
                if (Request["p"] != null) numPage = Int32.Parse(Request["p"]);
                int limitForPage = 10;

                String codargomento = Request["arg"];
                String subargomento = Request["subarg"];

                if (numPage == null || numPage == 0) numPage = 1;
                getTitle(codargomento, subargomento);
                BindData(codargomento, subargomento, numPage, limitForPage);
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
            nomeArgomentoOutput.InnerHtml = descrizione_paragrafo + " --><span class=\"NomeArgomento\">" + descrizione_argomento + "</span>";

        
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

        private bool searchImageFromDisk(String idLotto) {
            Boolean stato = false;
            String nome_file = idLotto + ".jpg";
            String tmpPath = "";
            tmpPath = Server.MapPath(".")  + "\\images\\asta\\";
            //Response.Write("PATH["+ tmpPath +"]");
            DirectoryInfo MyDir = new DirectoryInfo(@tmpPath);
            foreach(FileInfo file in MyDir.GetFiles()){
                if (file.Name == nome_file) return true;
            }            
            return stato;
        }

        public String loadImmagine(Object idLotto){
            String  chiave = idLotto.ToString();
            String outputImmagine ="";
            bool esito = searchImageFromDisk(chiave);
            if(esito){
                String path = Page.ResolveClientUrl("~/images/asta/")  + chiave + ".jpg";
                outputImmagine = "<a href=\"" + path + "\" rel=\"shadowbox;handleOversize:resize\" title=\"Lotto " + chiave + "\" id=\"shadowimages\"><img src=\"" + path  + "\" width=\"100\" height=\"100\" alt=\"Lotto "+ chiave +"\"/></a>";
            }else{
                String path = Page.ResolveClientUrl("~/images/immagine_non_disponibile.jpg");
                outputImmagine = "<img src=\"" + path + "\" width=\"100\" height=\"100\" alt=\"Lotto " + chiave + "\"/>";
            }
            return outputImmagine;
        }

        public String VerificaOfferta(Object statoOfferta, Object idLotto)
        {
            String stato = statoOfferta.ToString();
            String chiave = idLotto.ToString();

            String outputVerifica = "<a href=\"carrello.aspx?cod=" + chiave + "\">Aggiungi al carrello</a><a href=\"offerta.aspx?cod=" + chiave + "\">Fai l'offerta</a>\n";
            if (AccountLayer.IsLogged()) {
                switch (stato)
                {
                    //case "1": outputVerifica = ""; break;
                    case "99": outputVerifica = "Offerta già effettuata"; break;
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

                    tmpSql += "<li><a href=\"" +Page.ResolveClientUrl("~/elencoLotto.aspx?arg=" + codargomento +  "&subarg="+ subargomento+"&p=" + i +"") +  "\">" + i + "</a></li>";
                }
                tmpSql += "</ul></div>";
                Esito = tmpSql;
            }

            return Esito;        
        
        }
    }
}