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
            if (!IsPostBack) {
                //if (AccountLayer.IsLogged())
                   // OutputWishBasket.InnerHtml = LoadWishList();
                //else
                    //OutputWishBasket.InnerHtml = "";

                BindData();
            }
        }
        private void BindData() {
            int idAnagrafica = 0; 
            if (AccountLayer.IsLogged())
            {
                idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
            }
            
            String sql = "select a.idcarrello,a.idlotto idlotto,a.idanagrafica idanagrafica,b.tipo_lotto tipo_lotto,b.descrizione descrizione,b.anno anno,b.euro euro  FROM carrello a, lotto b where a.idlotto =  b.idlotto and b.idlotto not in (select c.idlotto from offerta_per_corrispondenza c where a.idanagrafica = a.idanagrafica) and a.idanagrafica =" + idAnagrafica + " order by a.data_inserimento DESC";
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

    }
}