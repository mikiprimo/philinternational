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
                String codargomento = Request["arg"];
                String subargomento = Request["subarg"];
                getTitle(codargomento, subargomento);
                BindData(codargomento, subargomento);
                bool pippo = searchImageFromDisk("2");
                Response.Write("bool pippo:" + pippo);

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
            nomeArgomento.InnerText = descrizione_paragrafo + " [" + descrizione_argomento + "]";

        
        }

        private void BindData(String codargomento,String subargomento)
        {
            String sql="";
            if (subargomento == null || subargomento == "0")
            {
                sql = "SELECT idlotto, id_argomento, id_subargomento, conferente, anno, tipo_lotto, numero_pezzi, descrizione, prezzo_base, euro, riferimento_sassone, stato FROM lotto WHERE id_argomento=" + codargomento + "";
            }
            else
            {
                sql = "";
            }
            LottoConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            LottoConnector.SelectCommand = sql;
            LottoConnector.DataBind();
        }

        private bool searchImageFromDisk(String idlotto) {
            Boolean stato = false;
            String nome_file = idlotto + ".jpg";
            String tmpPath = "";
            tmpPath = Server.MapPath(".")  + "\\images\\asta\\";
            //Response.Write("PATH["+ tmpPath +"]");
            DirectoryInfo MyDir = new DirectoryInfo(@tmpPath);
            foreach(FileInfo file in MyDir.GetFiles()){
                if (file.Name == nome_file) return true;
            }            
            return stato;
        }
 

    }
}