using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Philinternational.Layers;

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

                 MySqlDataReader dr = NewsGateway.GetNewsById(codice); //MAI concatenare le stringhe come avevi fatto prima! Fai sempre un metodo nel rispettivo Gateway (qui siamo in news quindi mi creo NewsGateway) può sembrare una palla ma rende futuri interventi molto più fattibili
                if (!(dr == null))
                {
                    while (dr.Read())
                    {
                        // = (DateTime)dr["data_pubblicazione"];
                        txtTitolo.Text = (String)dr["titolo"];
                        titoloDettaglioNews.InnerText = (String)dr["titolo"];
                        txtTesto.Text = (String)dr["testo"];
                        string getStato = Layers.Commons.GetStato((int)dr["stato"]);
                        if ((int)dr["stato"] == 1)
                            chkStato.Checked = true;
                        else
                            chkStato.Checked = false;
                        labelStato.InnerText = getStato;
                        labelDataPubblicazione.InnerHtml = Convert.ToString(dr["data_pubblicazione"]);
                    }
                }
            }
        }

        //TODO: Da incapsulare in NewsGateway
        protected void conferma(object sender, EventArgs e){
            int valueStato;
            String sqlNews="";
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
                    String data_pubblicazione = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    sqlNews = "Insert into news(idnews,data_pubblicazione,titolo,testo,stato)" ;
                    sqlNews += "VALUES";
                    sqlNews += "(" + newIndice + ",'" + data_pubblicazione + "','" + titolo + "','" + testo + "'," + valueStato + ")";
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