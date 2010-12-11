using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Philinternational.Management
{
    public partial class WebForm1 : System.Web.UI.Page
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

        protected string ConvertiStato(object value) {
            String new_value="";
            String tmp_value = value.ToString();
            switch (tmp_value)
            {
                case "0": new_value = "Sospeso";break;
                case "1": new_value = "Attivo";break;
                default:new_value = "Da definire";break;
            }
            return new_value;
        }
    }
}