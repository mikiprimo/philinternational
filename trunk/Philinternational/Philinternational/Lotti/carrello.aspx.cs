using System.IO;
using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;

namespace Philinternational
{ 
    public partial class carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData() {
            String idAnagrafica = "0";
            String sql ="";
            if (AccountLayer.IsLogged())
            {
                idAnagrafica = Convert.ToString(((logInfos)Session["log"]).idAnagrafica);
                sql = "SELECT a.idcarrello idcarrello,a.idlotto idlotto,a.idanagrafica idanagrafica,b.tipo_lotto tipo_lotto,b.descrizione descrizione,b.anno anno,b.prezzo_base euro  FROM carrello a, lotto b where a.idlotto =  b.idlotto AND b.idlotto not in (select c.idlotto from offerta_per_corrispondenza c where a.idanagrafica = a.idanagrafica) and a.idanagrafica ='" + idAnagrafica + "' ORDER BY a.data_inserimento DESC";
            }
            else {
                idAnagrafica = Session.SessionID;
                sql = "SELECT a.idcarrello idcarrello,a.idlotto idlotto,a.idanagrafica idanagrafica,b.tipo_lotto tipo_lotto,b.descrizione descrizione,b.anno anno,b.prezzo_base euro  FROM carrello a, lotto b where a.idlotto =  b.idlotto AND a.idanagrafica ='" + idAnagrafica + "' ORDER BY a.data_inserimento DESC";
            }
            
            
            CarrelloConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            CarrelloConnector.SelectCommand = sql;
            CarrelloConnector.DataBind();
            OfferteGateway a = new OfferteGateway();
            Boolean esito = a.CheckLottiBySelect(idAnagrafica);
            if (esito) { noLotti.Visible = false; }
        }
        public String loadImmagine(Object idLotto)
        {
            LottiGateway a = new LottiGateway();
            String chiave = idLotto.ToString();
            String outputImmagine = a.LoadImageByLotto(Page.ResolveClientUrl("~/images/asta/"),Server.MapPath(Page.ResolveClientUrl("~/images/asta/")), Page.ResolveClientUrl("~/images/immagine_non_disponibile.jpg"), chiave);
            return outputImmagine;
        }
        private String FaiOfferta(String idLotto, float offerta)
        {
            String esito = "";
            LottiGateway Lotti = new LottiGateway();
            OfferteGateway a = new OfferteGateway();

            float offertaBase = float.Parse(Lotti.getValueByField(idLotto, "prezzo_base").ToString());

            if (offerta == 0)
            {
                return "Hai offerto 0 euro";
            }
            if (offerta < offertaBase)
            {
                return "Offerta troppo bassa";
            }

            if (AccountLayer.IsLogged())
            {
                int idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
                esito = a.InsertOfferta(idAnagrafica, idLotto, offerta); 
            }
            else
            {
                return "Per effettuare un'offerta devi prima effettuare il login";
            }
            return esito;
        }
        private Boolean RemoveToBasket(int idCarrello)
        {

            OfferteGateway carrello = new OfferteGateway();
            Boolean esito = carrello.DeleteCarrelloByIdCarrello(idCarrello);
            return esito;
        }
        protected void R_ItemCommand(Object sender, RepeaterCommandEventArgs e)
        {
            String action = e.CommandName;
            Boolean esito = false;
            switch (action){
                case "removeBasket": 
                        int value = Int32.Parse(e.CommandArgument.ToString());
                        esito = RemoveToBasket(value);
                        if (esito) Response.Redirect("carrello.aspx");
                        break;
                case "makeOffert":
                        String tmp = ((TextBox)e.Item.FindControl("txt_offerta")).Text;
                        if (tmp == "") tmp = "0";
                        int a = Int32.Parse(tmp);
                        Button btn = ((Button)e.Item.FindControl("btnOfferta"));
                        String idLotto =btn.Attributes["myIdLotto"].ToString();
                        int idCarrello = Int32.Parse(btn.Attributes["myIdcarrello"].ToString());
                        String esitoOfferta = FaiOfferta(idLotto, a);
                        if (esitoOfferta == ""){
                            Boolean esitoCarrello = RemoveToBasket(idCarrello);
                            Response.Redirect("carrello.aspx");
                        } 
                        else ((System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("esitoOfferta")).InnerHtml = esitoOfferta;
                        break;
            }

        }
        protected void offerta_OnDataBinding(Object sender, EventArgs e) {
            Button btn = ((Button)sender);
            String idLotto = btn.Attributes["myIdLotto"].ToString();
            OfferteGateway off = new OfferteGateway();
            String idAnagrafica = "0";
            if (AccountLayer.IsLogged())
            {
                idAnagrafica = Convert.ToString(((logInfos)Session["log"]).idAnagrafica);
            }else{
                idAnagrafica = Session.SessionID;
            }
            
            if (off.checkOffertaGiaPresente(idAnagrafica, idLotto))
            {
                btn.Visible=false;
            }
        }
    }
}