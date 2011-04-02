using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Philinternational.Layers;
using System.Net;
using System.Configuration;

namespace Philinternational.Styles
{
    public partial class Varie : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void aggiornaDatabase(object sender, EventArgs e)
        {
            spoolTesto.Visible = true;
            esitoElaborazione.Text = "";
            String pathImage = Server.MapPath(Page.ResolveClientUrl("~/images/asta/"));
            String listaFile = "";
            LottiGateway lotti = new LottiGateway();
            DirectoryInfo listDir = new DirectoryInfo(pathImage);
            if (listDir.Exists)
            {
                int i = 1;
                foreach (FileInfo fi in listDir.GetFiles())
                {
                    int idLotto = 0;
                    String tmp = fi.Name.ToString();
                    int indice = tmp.LastIndexOf(".");
                    int lunghezza = tmp.Length;
                    String tmpName2 = tmp.Substring(0, lunghezza - (lunghezza - indice));
                    try { 
                        idLotto = Int32.Parse( tmpName2);
                        Boolean esitoLotto =  lotti.UpdateImageLotto(idLotto);
                        if (esitoLotto)
                            listaFile += i + "]"+ idLotto + "..........<b>OK</b><br/>";
                        else
                            listaFile += i + "]" + idLotto + "..........<b><span style=\"color:#f00\"> non aggiornato</span></b><br/>";
                        i++;
                    }catch{
                        listaFile += tmpName2 + "..........<b> non aggiornato</b><br/>";
                    }
                }
                esitoElaborazione.Text = listaFile;
            }else{
                esitoElaborazione.Text = "aggiornamento non possible. directory non esistente";
            }            
        }
        protected void loadImmagini(object sender, EventArgs e) {

            ftpGateway myFtp = new ftpGateway();

         //   myFtp.FileName
        }
        protected void loadImmaginiOld(object sender, EventArgs e) {
                spoolTesto.Visible = true;
                esitoElaborazione.Text = "";
                DirectoryInfo dirName = new DirectoryInfo(@"c:\philinternational.it\immagini_asta\");
              //  FtpWebRequest a = new FtpWebRequest(ConfigurationManager.AppSettings["ftpPUrl"].ToString());
            

                if (dirName.Exists)
                {
                    String listaFile="";
                    int i = 1;
                    foreach (FileInfo fi in dirName.GetFiles())
                    {
                        try
                        {
                            String pathImage = Server.MapPath(Page.ResolveClientUrl("~/images/asta/"));
                            String nameDestination = fi.Name;
                            String finalcopy = pathImage + nameDestination;
                            fi.CopyTo(finalcopy);
                            listaFile += i +"] " + fi.Name + "...caricato con successo<br/>";
                        }
                        catch {
                            listaFile += "<b><span style=\"color:#f00\">" + i + "] " + fi.Name + "... non aggiornato</span></b><br/>";
                        }
                        i++;
                    }
                    esitoElaborazione.Text = listaFile;
                
                }
                else {                 
                    esitoElaborazione.Text ="La directory C:\\philinternational.it\\immagini_asta non esiste";
                }

                  
        }

        protected void loadLotti(object sender, EventArgs e)
        {
            String fn = "";
            if (FileLotto.PostedFile != null && FileLotto.PostedFile.ContentLength > 0)
            {
                fn = System.IO.Path.GetFileName(FileLotto.PostedFile.FileName);
                String dr = System.IO.Path.GetDirectoryName(FileLotto.FileName);

            }
            string SaveLocation = Server.MapPath("uploadLotto\\") + fn;
            FileLotto.SaveAs(SaveLocation);

            Int32 i = 0;
            LottiGateway.TruncateAll();
            //StreamReader rd = File.OpenText(SaveLocation);
            //while (!rd.EndOfStream) {
            //    List<String> list = new List<string>();
            //    String[] line = rd.ReadLine().Split(';');
            String[] lines = File.ReadAllLines(SaveLocation, System.Text.Encoding.Default);
            foreach (String unsplitted in lines)
            {
                String[] line = unsplitted.Split(';');
                List<String> list = new List<String>();

                list.Add(line[1]);
                list.Add(line[2]);
                list.Add(line[3]);
                list.Add(line[11]);
                list.Add(line[13]);
                list.Add(line[14]);
                list.Add(line[29]);
                list.Add(line[39]);
                list.Add(line[40]);

                if (i != 0) LottiGateway.InsertLottiTemporanei(list);
                i++;
            }
            //}
            esitoElaborazione.Text = "Sono stati caricati <b>" + i + "</b> lotti.";

        }
      
    }
}