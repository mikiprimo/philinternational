using System;
using System.Collections.Generic;
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
            if (!IsPostBack){
                String chiave = Request["cod"];
                String codargomento = Request["arg"];
                String subargomento = Request["subarg"];
                codiceLotto.Value = chiave;
                loadData(chiave);

            }else {
                String esito = "";
                String offertaUtente = txtOfferta.Text;
                if (offertaUtente == "") offertaUtente = "0";
                esito = FaiOfferta(codiceLotto.Value, float.Parse(offertaUtente));
                if (esito =="" )
                {
                    int idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
                    String emailUtente = Layers.AccountGateway.GetEmailByIdAnagrafica(idAnagrafica);
                    AsteGateway Asta = new AsteGateway();
                    String[] esitoAsta = new String[2];
                    esitoAsta = Asta.getDatiAsta();
                    buttonOfferta.Visible = false;
                    String esitoMail = Layers.MailList.SendOffertaToUser(emailUtente, emailUtente, codiceLotto.Value, offertaUtente, esitoAsta.GetValue(0).ToString());
                    EsitoOperazione.InnerHtml = "<span class=\"ok\">Offerta Effettuata con successo<br/>" + esitoMail  + "<br/></span>\n";
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
            OfferteGateway o = new OfferteGateway();
            LoadImmagineOutput.InnerHtml = loadImmagine(idlotto);
            testoH1.InnerHtml = "Offerta per lotto <span style=\"color:#F00\">[" + idlotto + "]</span>";
            annoLotto.InnerHtml = a.getValueByField(idlotto, "anno");
            descrizioneLotto.InnerHtml = a.getValueByField(idlotto, "descrizione");
            prezzoLotto.InnerHtml = a.getValueByField(idlotto, "euro");
            statoLotto.InnerHtml = a.getValueByField(idlotto, "tipo_lotto");
            if (AccountLayer.IsLogged())
            {
                int idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
                Boolean esito = o.checkOffertaGiaPresente(idAnagrafica,idlotto);
                if (esito) showButton.Visible = false;
            }



        }
        private String FaiOfferta(String idLotto,float offerta) {
            String esito = "";
            
            LottiGateway Lotti = new LottiGateway();
            OfferteGateway a = new OfferteGateway();
            
            float offertaBase = float.Parse(Lotti.getValueByField(idLotto, "prezzo_base").ToString());

            if (offerta ==0)
            {
                return "Hai offerto 0 euro";
            }
            if (offerta < offertaBase) {
                return "Offerta troppo bassa";
            }

            if (AccountLayer.IsLogged())
            {
                int idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
                esito = a.InsertOfferta(idAnagrafica, idLotto, offerta);
            }
            else {
                return "Login";
            }


            
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