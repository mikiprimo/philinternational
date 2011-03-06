﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Philinternational.Layers;

namespace Philinternational.Styles
{
    public partial class Varie : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void aggiornaDatabase(object sender, EventArgs e)
        {
            String pathImage = Server.MapPath(Page.ResolveClientUrl("~/images/asta/"));
            String listaFile = "";
            LottiGateway lotti = new LottiGateway();
            DirectoryInfo listDir = new DirectoryInfo(pathImage);
            if (listDir.Exists)
            {
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
                            listaFile += idLotto + "<b> OK</b><br/>";
                        else
                            listaFile += idLotto + "<b> non aggiornato</b><br/>";
                    }catch{
                        listaFile += tmpName2 + "<b> non aggiornato</b><br/>";
                    }
                }
                esitoElaborazione.Text = listaFile;
            }else{
                esitoElaborazione.Text = "aggiornamento non possible. directory non esistente";
            }            
        }

        protected void loadImmagini(object sender, EventArgs e) { }

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