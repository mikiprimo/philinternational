using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;


namespace Philinternational.Styles
{   
    public partial class Offerta : System.Web.UI.Page
    {
        String sqlOfferta = "SELECT a.idlotto idlotto, CONCAT( b.nome,  ' ', b.cognome ) persona, b.email email, a.prezzo_offerto, a.data_inserimento FROM offerta_per_corrispondenza a, anagrafica b WHERE a.idanagrafica = b.idanagrafica ORDER BY idlotto, prezzo_offerto DESC , data_inserimento ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindData();
            }
        }

        private void BindData()
        {
            
            OfferteConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            OfferteConnector.SelectCommand = sqlOfferta;
            OfferteConnector.DataBind();
        }

        protected void R_ItemCommand(object source, RepeaterCommandEventArgs e) { }
        protected void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) { }

        public void estraiDati(object sender, EventArgs e) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            try{}
            catch (MySqlException){}
            finally{}
        }
    }
}