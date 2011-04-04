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


namespace Philinternational.Management
{
    public partial class StoricoOfferte : System.Web.UI.Page
    {
        String sqlOfferta = "SELECT b.idanagrafica idanagrafica, CONCAT( b.nome,  ' ', b.cognome ) persona,b.email email,a.numero_asta  numero_asta,a.data_inserimento data_inserimento FROM anagrafica_movimenti a, anagrafica b WHERE a.idanagrafica = b.idanagrafica order by  a.data_inserimento ASC";
        //String sqlShowAssegnati = "SELECT a.idofferta idofferta,a.idanagrafica idanagrafica,a.idlotto idlotto, CONCAT( b.nome,  ' ', b.cognome ) persona, b.email email, a.prezzo_offerto, a.data_inserimento,a.assegnazione assegnazione FROM offerta_per_corrispondenza a, anagrafica b WHERE a.idanagrafica = b.idanagrafica AND assegnazione !='' ORDER BY idlotto ASC, prezzo_offerto DESC , data_inserimento ASC";
        //String sqlSwhowAll = "SELECT a.idofferta idofferta,a.idanagrafica idanagrafica,a.idlotto idlotto, CONCAT( b.nome,  ' ', b.cognome ) persona, b.email email, a.prezzo_offerto, a.data_inserimento,a.assegnazione assegnazione FROM offerta_per_corrispondenza a, anagrafica b WHERE a.idanagrafica = b.idanagrafica ORDER BY idlotto ASC, prezzo_offerto DESC , data_inserimento ASC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fldMessaggi.Visible = true;
                BindData(sqlOfferta);
            }
        }
        private void BindData(String sqlToLoad)
        {
            OfferteConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            OfferteConnector.SelectCommand = sqlToLoad;
            OfferteConnector.DataBind();
        }

        public void estraiDati(object sender, EventArgs e)
        {
            esitoEstrazione.InnerHtml = "Estrazione in corso";
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            String orario = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day + "_" + DateTime.Now.Hour + DateTime.Now.Minute;
            String fileName = "estrazioneStorico_philinternational_" + orario + ".csv";
            //DirectoryInfo dirName = new DirectoryInfo(@"c:\philinternational.it\");

            //if (!dirName.Exists)  dirName.Create();
            String dirName = Server.MapPath("uploadLotto\\");
            String pathName = dirName + fileName;
            FileInfo tmpFile = new FileInfo(pathName);
            if (tmpFile.Exists) tmpFile.Delete();
            try
            {

                using (StreamWriter sw = new StreamWriter(tmpFile.ToString()))
                {
                    DataView dr = Layers.ConnectionGateway.SelectQuery(sqlOfferta);
                    String writeInFile = "";
                    sw.WriteLine("Asta;Persona;email,Data Inserimento");
                    for (int i = 0; i < dr.Count; i++)
                    {
                        String numero_asta = dr[i]["numero_asta"].ToString();
                        String persona = dr[i]["persona"].ToString();
                        String email = dr[i]["persona"].ToString();
                        String data_inserimento = dr[i]["data_inserimento"].ToString();
                        writeInFile = numero_asta + ";" + persona + ";" + email + ";" + data_inserimento + ";";
                        sw.WriteLine(writeInFile);
                    }
                    sw.Close();
                }
                fldMessaggi.Visible = true;
                esitoEstrazione.InnerHtml = "<a href=\"uploadLotto\\" + fileName + "\" title=\"" + fileName + "\">" + fileName + "</a>";
            }
            catch (MySqlException)
            {
                esitoEstrazione.InnerHtml = "File NON estratto";
            }
            finally { }
        }
    }
}