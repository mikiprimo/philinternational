using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Philinternational.Layers;

namespace Philinternational.Management
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConnectionDB.ConnectionString = Layers.ConnectionDBTasks.StringConnectDB();
                ConnectionDB.SelectCommand = "SELECT idnews, data_pubblicazione, titolo, testo, stato FROM news ORDER BY data_pubblicazione DESC";
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