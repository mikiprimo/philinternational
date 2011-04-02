using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.Services;
using Philinternational.Layers;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace Philinternational
{   
    public partial class OffertaFinale : System.Web.UI.Page
    {
        String sqlOfferta = "SELECT a.idofferta idofferta,a.idanagrafica idanagrafica,a.idlotto idlotto, CONCAT( b.nome,  ' ', b.cognome ) persona, b.email email, a.prezzo_offerto, a.data_inserimento,a.assegnazione assegnazione FROM offerta_per_corrispondenza a, anagrafica b WHERE a.idanagrafica = b.idanagrafica ORDER BY idlotto ASC, prezzo_offerto DESC , data_inserimento ASC";
        String sqlShowAssegnati = "SELECT a.idofferta idofferta,a.idanagrafica idanagrafica,a.idlotto idlotto, CONCAT( b.nome,  ' ', b.cognome ) persona, b.email email, a.prezzo_offerto, a.data_inserimento,a.assegnazione assegnazione FROM offerta_per_corrispondenza a, anagrafica b WHERE a.idanagrafica = b.idanagrafica AND assegnazione !='' ORDER BY idlotto ASC, prezzo_offerto DESC , data_inserimento ASC";
        String sqlSwhowAll = "SELECT a.idofferta idofferta,a.idanagrafica idanagrafica,a.idlotto idlotto, CONCAT( b.nome,  ' ', b.cognome ) persona, b.email email, a.prezzo_offerto, a.data_inserimento,a.assegnazione assegnazione FROM offerta_per_corrispondenza a, anagrafica b WHERE a.idanagrafica = b.idanagrafica ORDER BY idlotto ASC, prezzo_offerto DESC , data_inserimento ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                fldMessaggi.Visible = false;
                BindData(sqlOfferta);
            }
        }

        private void BindData(String sqlToLoad)
        {
            OfferteConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            OfferteConnector.SelectCommand = sqlToLoad;
            OfferteConnector.DataBind();
        }

        protected void R_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LinkButton btn = ((LinkButton)e.Item.FindControl("assegnaLotto"));
            String idLotto =btn.Attributes["myIdLotto"].ToString();
            int idOfferta = Int32.Parse(btn.Attributes["myIdOfferta"].ToString());
            int idAnagrafica = Int32.Parse(btn.Attributes["myIdAnagrafica"].ToString());

            int a = Layers.AssignLotto.aggiudicaLottoVincente(idOfferta, idLotto, idAnagrafica);
            switch (a) {
                case 0: BindData(sqlOfferta); 
                         fldMessaggi.Visible = true;
                         esitoEstrazione.InnerHtml = "Assegnazione del lotto [" + idLotto  + "] avvenuta correttamente";
                        break;
                case -1: BindData(sqlOfferta);
                         fldMessaggi.Visible = true;
                         esitoEstrazione.InnerHtml = "Assegnazione non avvenuta correttamente";
                         break;
                case -2: BindData(sqlOfferta);
                         fldMessaggi.Visible = true;
                         esitoEstrazione.InnerHtml = "Processo di annullamento offerte non vincenti non avvenuto correttamente";
                        break;
            }
        }

        public void showElencoCompleto(object sender, EventArgs e) {
            BindData(sqlSwhowAll);
        
        }

        public void showElencoAssegnati(object sender, EventArgs e)
        {
            BindData(sqlShowAssegnati);
        }

        
        public void estraiDati(object sender, EventArgs e) {
            esitoEstrazione.InnerHtml = "Estrazione in corso";
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            String orario = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day + "_" + DateTime.Now.Hour + DateTime.Now.Minute;
            String fileName = "estrazione_philinternational_" +  orario  +".csv";
            //DirectoryInfo dirName = new DirectoryInfo(@"c:\philinternational.it\");

            //if (!dirName.Exists)  dirName.Create();
            String dirName = Server.MapPath("uploadLotto\\");
            String pathName = dirName + fileName;
            FileInfo tmpFile = new FileInfo(pathName);
            if (tmpFile.Exists)  tmpFile.Delete();
            try{

                using (StreamWriter sw = new StreamWriter(tmpFile.ToString()))
                {
                    DataView dr = Layers.ConnectionGateway.SelectQuery(sqlSwhowAll);
                    String writeInFile = "";
                    sw.WriteLine("Lotto;Persona;E-mail;Offerta;Data Offerta;Assegnazione");
                    for (int i = 0; i < dr.Count; i++)
                    {
                        String idlotto = dr[i]["idlotto"].ToString();
                        String persona = dr[i]["persona"].ToString();
                        String email = dr[i]["email"].ToString();
                        String prezzo_offerto = dr[i]["prezzo_offerto"].ToString();
                        String data_inserimento = dr[i]["data_inserimento"].ToString();
                        String assegnazione = dr[i]["assegnazione"].ToString();
                        writeInFile = idlotto + ";" + persona + ";" + email + ";" + prezzo_offerto + ";" + data_inserimento + ";" + assegnazione;
                        sw.WriteLine(writeInFile);
                    }
                    sw.Close();
                }
                fldMessaggi.Visible = true;
                esitoEstrazione.InnerHtml = "<a href=\"uploadLotto\\" + fileName + "\" title=\"" + fileName  + "\">" + fileName + "</a>";
            }
            catch (MySqlException){
                esitoEstrazione.InnerHtml = "File NON estratto";
            }
            finally{}
        }

        protected void R1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {            


            LinkButton btn = ((LinkButton)e.Item.FindControl("assegnaLotto"));
            String idOfferta = btn.Attributes["myIdOfferta"].ToString();
            OfferteGateway o  = new OfferteGateway();
            String esito = o.checkOffertaGiaAssegnata(idOfferta);
            if (esito.Trim() != "")
            {
                ((Label)e.Item.FindControl("lottoAssegnato")).Visible = true;
                ((Label)e.Item.FindControl("lottoAssegnato")).Text = esito;
                ((LinkButton)e.Item.FindControl("assegnaLotto")).Visible = false;
            }


        }

    }
}