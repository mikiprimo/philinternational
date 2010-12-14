using System;
using System.Configuration;
using Philinternational.Layers;

namespace Philinternational.Management
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewsConnector.ConnectionString = Layers.ConnectionGateway.StringConnectDB();
                NewsConnector.SelectCommand = ConfigurationManager.AppSettings["SelectNews"].ToString();
                //  repeaterNews.DataBind();
                //ConnectionDB.UpdateCommand = "UPDATE news set titolo=@titolo,testo=@testo,stato=@stato where idnews=@idnews";
                //ConnectionDB.DeleteCommand = "DELETE FROM news where idnews=@idnews";
            }
        }

        protected static string ConvertiStato(int value)
        {
            return Commons.GetStato(value);
        }
    }
}