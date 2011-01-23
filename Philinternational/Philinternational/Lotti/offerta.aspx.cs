using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational
{
    public partial class offerta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String chiave = Request["cod"];
                String codargomento = Request["arg"];
                String subargomento = Request["subarg"];
                codiceLotto.Value = chiave;
                loadData(chiave);

            }
            else {
                String esito = "";
                String offertaUtente = txtOfferta.Text;
                if (offertaUtente == "") offertaUtente = "0";
                esito = FaiOfferta(codiceLotto.Value, float.Parse(offertaUtente));
                if (esito =="" )
                {
                    buttonOfferta.Visible = false;
                    EsitoOperazione.InnerHtml = "<span class=\"ok\">Offerta Effettuata con successo</span>\n";
                }
                else {
                    String outputEsito = "<span class=\"ko\">Offerta Non Effettuata per [" + esito + "]</span>\n";
                    switch (esito) {
                        case "Login": outputEsito = "<span class=\"ko\">Per fare l'offerta devi essere autenticato. Effettua il Login</span>\n"; break;
                    
                    }
                    EsitoOperazione.InnerHtml = outputEsito;
                }
            
            }


        }
        private void loadData(String idlotto) {
            LottiGateway a = new LottiGateway();
            LoadImmagineOutput.InnerHtml = loadImmagine(idlotto);
            testoH1.InnerHtml = "Offerta per lotto <span style=\"color:#F00\">[" + idlotto + "]</span>";
            annoLotto.InnerHtml = a.getValueByField(idlotto, "anno");
            descrizioneLotto.InnerHtml = a.getValueByField(idlotto, "descrizione");
            prezzoLotto.InnerHtml = a.getValueByField(idlotto, "euro");
            statoLotto.InnerHtml = a.getValueByField(idlotto, "tipo_lotto");
        }
        private String FaiOfferta(String idLotto,float offerta) {
            String esito = "";
            
            LottiGateway Lotti = new LottiGateway();
            Offerte a = new Offerte();
            
            float offertaBase = float.Parse(Lotti.getValueByField(idLotto, "prezzo_base").ToString());

            if (offerta ==0)
            {
                return "Hai offerto 0 euro";
            }
            if (offerta < offertaBase) {
                return "Offerta troppo bassa";
            }



            if (HttpContext.Current.Session["idanagrafica"] != null)
            {
                String idAnagrafica = HttpContext.Current.Session["idanagrafica"].ToString();
                esito = a.InsertOfferta(idAnagrafica, idLotto, offerta);
            }
            else { return "Login"; }
            
            return esito;
        }

        private String loadImmagine(Object idLotto)
        {
            LottiGateway a = new LottiGateway();
            String chiave = idLotto.ToString();
            String outputImmagine = a.LoadImageByLotto(Page.ResolveClientUrl("~/images/asta/"), Page.ResolveClientUrl("~/images/immagine_non_disponibile.jpg"), chiave);

            return outputImmagine;
        }
    }
}