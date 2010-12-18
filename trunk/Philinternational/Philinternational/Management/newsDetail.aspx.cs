using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Philinternational.Layers;
using System.Text;
//NOTA: Per il dettaglio si dovrebbe usare l'oggetto FormView che facilita un po le cose ma anche così va bene

namespace Philinternational.Management
{
    public partial class newsDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String codice = Request["cod"];
                if ((codice == null) || (codice == "-1")) codice = "-1";
                txtCodice.Value = codice;

                NewsEntity myNews = NewsGateway.GetNewsById(codice);
                lblDataPubblicazione.Text = myNews.dataPubblicazione.ToString("dd/MM/yyyy");
                txtTitolo.Text = myNews.titolo;
                txtTesto.Text = myNews.testo;
                chkStato.Checked = Commons.GetCheckedState(myNews.state.id);
            }
        }

        //TODO: Da incapsulare in NewsGateway, la insert sempre in web.config con le @ per ogni parametro
        protected void conferma(object sender, EventArgs e){
            int valueStato;
            String sqlNews="";
            //StringBuilder sqlNews = new StringBuilder();
            String testo = txtTesto.Text;
            String titolo = txtTitolo.Text;
            if (chkStato.Checked == true)
            {
                valueStato = 1;
            }
            else {
                valueStato = 0;
            }
                

            if (txtCodice.Value == "-1")
            {
                int newIndice = Layers.ConnectionGateway.CreateNewIndex("idnews", "news");
                if (newIndice>0){
                    String data_pubblicazione = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    sqlNews = "Insert into news(idnews,data_pubblicazione,titolo,testo,stato)" ;
                    sqlNews += "VALUES";
                    sqlNews += "(" + newIndice + ",'" + data_pubblicazione + "','" + titolo + "','" + testo + "'," + valueStato + ")";
                    //In java come in C# non usare mai la concatenazione di stringhe perché ad ogni concatenazione crea una NUOVA copia della stringa fino a quel momento creata. Usa StringBuilder (namespace System.Text):
                    //ESEMPIO: StringBuilder pippo = new StringBuilder();
                    //pippo.Append("Michel ");
                    //pippo.Append("sei un ");
                    //pippo.Append("mito!");
                    //Inn questo caso in memoria ci sarà solo "Michel sei un mito". Con la concatenazione di prima invece in memoria avremmo avuto: "Michel" e a seguire "Michel sei un" e a seguire "Michel sei un mito!" -- 3 is pegg che one!!
                }else{
                }
                
            }
            else {
                sqlNews = "UPDATE news SET ";
                sqlNews += " titolo='"+ titolo+"'";
                sqlNews += ",testo='" + testo + "'";
                sqlNews += ",stato='" + valueStato + "'";
                sqlNews += " WHERE idnews=" + txtCodice.Value;
                
            }

            int esito = Layers.ConnectionGateway.ExecuteQuery(sqlNews, "news");
            if (esito == 0)
            {
                esitoMessaggio.InnerHtml = "<span style=\"color:red\">Operazione effettuato con successo</span>";
            }
            else {
                esitoMessaggio.InnerHtml = "Operazione non effettuata";
            }

        }


    }
}