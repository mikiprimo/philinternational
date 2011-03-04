using System;
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
            //if (!((logInfos)HttpContext.Current.Session["log"]).IsAdmin) Response.Redirect("~/Default.aspx");
        }

        protected void aggiornaDatabase(object sender, EventArgs e)
        {
            
            String pathImage = Server.MapPath("..\\images\\asta\\");
            String listaFile = "";
            LottiGateway lotti = new LottiGateway();
            DirectoryInfo listDir = new DirectoryInfo(pathImage);
            if (listDir.Exists)
            {
                foreach (FileInfo fi in listDir.GetFiles())
                {
                    String tmp = fi.Name.ToString();

                    int indice = tmp.LastIndexOf(".");
                    int lunghezza = tmp.Length;
                    String tmpName2 = tmp.Substring(0, lunghezza - (lunghezza-indice));
                    int idLotto = Int32.Parse( tmpName2);

                    Boolean esitoLotto =  lotti.UpdateImageLotto(idLotto);
                    if (esitoLotto)
                        listaFile += idLotto + "<b> OK</b><br/>";
                    else
                        listaFile += idLotto + "<b> non aggiornato</b><br/>";
                }
                esitoImmagine.Text = listaFile;
            }
            else
            {
                esitoImmagine.Text = "aggiornamento non possible. directory non esistente";
            }
        }
    }
}