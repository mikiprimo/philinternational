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
            else {            
                Response.Write("ancora da implementare []");
            }
        }
        private void BindData() {
            int idAnagrafica = 0; 
            if (AccountLayer.IsLogged())
            {
                idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
            }
            
            String sql = "SELECT a.idcarrello idcarrello,a.idlotto idlotto,a.idanagrafica idanagrafica,b.tipo_lotto tipo_lotto,b.descrizione descrizione,b.anno anno,b.euro euro  FROM carrello a, lotto b where a.idlotto =  b.idlotto and b.idlotto not in (select c.idlotto from offerta_per_corrispondenza c where a.idanagrafica = a.idanagrafica) and a.idanagrafica =" + idAnagrafica + " ORDER BY a.data_inserimento DESC";
            CarrelloConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            CarrelloConnector.SelectCommand = sql;
            CarrelloConnector.DataBind();
        }
        public String loadImmagine(Object idLotto)
        {
            LottiGateway a = new LottiGateway();
            String chiave = idLotto.ToString();
            String outputImmagine = a.LoadImageByLotto(Page.ResolveClientUrl("~/images/asta/"), Page.ResolveClientUrl("~/images/immagine_non_disponibile.jpg"), chiave);
            return outputImmagine;
        }
        public void FaiOfferta(Object sender, EventArgs e) {
        
        }
        private String _FaiOfferta(String idLotto, float offerta)
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
                return "Login";
            }
            return esito;
        }
        private Boolean RemoveToBasket(int idCarrello)
        {

            OfferteGateway carrello = new OfferteGateway();
            Boolean esito = carrello.DeleteCarrelloByIdCarrello(idCarrello);
            return esito;
        }
        protected void R_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        String tmp = e.CommandArgument.ToString();
                        if (tmp == "") tmp = "0";
                        int a = Int32.Parse(tmp);
                        Response.Write("action pressed["+ action +"] and value ["+ a +"]");
                    break;

            }

        }
        protected void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            /*
            object idlotto = e.Item.FindControl("idlotto");
            String chiave = ((System.Web.UI.HtmlControls.HtmlContainerControl)(idlotto)).InnerHtml;
            ((System.Web.UI.WebControls.LinkButton)(e.Item.FindControl("linkBasket"))).CommandName = "AddToBasket";
            ((LinkButton)(e.Item.FindControl("linkBasket"))).CommandArgument = chiave;
             */
        }
        protected void offerta_OnDataBinding(Object sender, EventArgs e) {
            Button btn = ((Button)sender);
            String idLotto = btn.Attributes["myIdLotto"].ToString();
            OfferteGateway off = new OfferteGateway();
            String idAnagrafica = (((logInfos)Session["log"]).idAnagrafica).ToString();
            if (off.checkLottoOfferte(idAnagrafica, idLotto)) {
                btn.Visible=false;
                //btn.Text = idLotto;
            }

        }
        protected void offerta_OnClick(Object sender, RepeaterCommandEventArgs e)
        {
            String a = e.CommandArgument.ToString();
            Response.Write("Offerta On Click[" + a +"]");
            /*
            Button btn = ((Button)sender);
            String idLotto = btn.Attributes[""].ToString();
            CheckBox chk = ((CheckBox)sender);
            String idNews = chk.Attributes["myIdLotto"].ToString();
             */ 
        }

        protected void AssumiValore(Object sender, RepeaterCommandEventArgs e)
        {
            String a = e.CommandArgument.ToString();
            Response.Write("AssumiValore[" + a + "]");
            /*
            Button btn = ((Button)sender);
            String idLotto = btn.Attributes[""].ToString();
            CheckBox chk = ((CheckBox)sender);
            String idNews = chk.Attributes["myIdLotto"].ToString();
             */
        }
    }
}