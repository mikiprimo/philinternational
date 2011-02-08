using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Philinternational.Styles
{
    public partial class Offerta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindData();
            }
        }

        private void BindData()
        {
            String sql = "SELECT a.idlotto idlotto, CONCAT( b.nome,  ' ', b.cognome ) persona, b.email email, a.prezzo_offerto, a.data_inserimento ";
                   sql +="  FROM offerta_per_corrispondenza a, anagrafica b ";
                   sql += "WHERE a.idanagrafica = b.idanagrafica ";
                   sql +=" ORDER BY idlotto, prezzo_offerto DESC , data_inserimento ASC";
            
            OfferteConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
            OfferteConnector.SelectCommand = sql;
            OfferteConnector.DataBind();
        }

        protected void R_ItemCommand(object source, RepeaterCommandEventArgs e) { }
        protected void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) { }
    }
}