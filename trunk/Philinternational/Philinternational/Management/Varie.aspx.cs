using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Philinternational.Layers;
using System.Net;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;

namespace Philinternational.Styles
{
    public partial class Varie : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            String pathImage = Server.MapPath(Page.ResolveClientUrl("~/images/asta/"));
        }


        protected void cleanAsta(object sender, EventArgs e)
        {
            /*
             Passaggi
             * - eliminazione immagini asta
             * - truncate tabella carrello
             * - truncate tabella lotto
             * - truncate tabella lotto_scartato
             * - truncate tabella_tmp
             * - offerta_per_corrispondenza
             */
            esitoElaborazione.Text = "";
            String sql = "";
            int esitoSql = 0;
            bool checkEsitoSql = false;
            String pathImage = Server.MapPath(Page.ResolveClientUrl("~/images/asta/"));
            DirectoryInfo listDir = new DirectoryInfo(pathImage);
            ConnectionGateway myConn = new ConnectionGateway();
            if (listDir.Exists)
            {
                //int i = 1;
                foreach (FileInfo fi in listDir.GetFiles())
                {
                    //Response.Write (i + "]" + fi.Name.ToString() + "<br/>");
                    fi.Delete();
                    //i++;
                }
            }
            sql = "TRUNCATE TABLE carrello";
            esitoSql = ConnectionGateway.ExecuteQuery(sql, "carrello");
            if (esitoSql == 1) checkEsitoSql = true;
            
            sql = "TRUNCATE TABLE lotto";
            esitoSql = ConnectionGateway.ExecuteQuery(sql, "lotto");
            if (esitoSql == 1) checkEsitoSql = true;
            
            sql = "TRUNCATE TABLE lotto_scartato";
            esitoSql = ConnectionGateway.ExecuteQuery(sql, "lotto_scartato");
            if (esitoSql == 1) checkEsitoSql = true;
            sql = "TRUNCATE TABLE lotto_tmp";
            esitoSql = ConnectionGateway.ExecuteQuery(sql, "lotto_tmp");
            if (esitoSql == 1) checkEsitoSql = true;
            sql = "TRUNCATE TABLE offerta_per_corrispondenza";
            esitoSql = ConnectionGateway.ExecuteQuery(sql, "offerta_per_corrispondenza");
            if (esitoSql == 1) checkEsitoSql = true;


            if (checkEsitoSql)
            {
                esitoElaborazione.Text = "Pulizia asta non avvenuta correttamente. Contattare il webmaster";
            }
            else {
                esitoElaborazione.Text = "LA pulizia dell'asta &egrave; avvenuta correttamente. Puoi inserire il nuovo catalogo.";
            }

        
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
                System.Drawing.Image imgPhoto = null;
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
                        if (esitoLotto){
                            ImageResize imageResize = new ImageResize();
                            String pathImageThumb = Server.MapPath(Page.ResolveClientUrl("~/images/")) + "immagine_non_disponibile.jpg";
                            //Response.Write (pathImageThumb + "<br/>");
                            String nomeFile    = pathImage + fi.Name.ToString();
                            String fileNameThumb = Server.MapPath(Page.ResolveClientUrl("~/images/asta/thumb/")) + fi.Name.ToString();
                            //Response.Write(fileNameThumb + "<br/>");
                            System.Drawing.Image imgPhotoOrig = System.Drawing.Image.FromFile(nomeFile);
                            imgPhoto = imageResize.ConstrainProportions(imgPhotoOrig, 100, ImageResize.Dimensions.Width);
                            imgPhoto.Save(fileNameThumb, ImageFormat.Jpeg);
			                imgPhoto.Dispose();
                            listaFile += i + "]" + idLotto + "..........<b>OK</b><br/>";
                        }

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