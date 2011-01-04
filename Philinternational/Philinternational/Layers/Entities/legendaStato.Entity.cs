using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Philinternational
{
    public class Stato
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { this._id = value; }
        }

        private string _descrizione;
        public string descrizione
        {
            get { return _descrizione; }
            set { this._descrizione = value; }
        }

        public Stato(int id, string descrizione)
        {
            this._id = id;
            this._descrizione = descrizione;
        }
    }

    public class legendaStato
    {
        public legendaStato()
        {
        }

        private List<Stato> list = new List<Stato>();

        public void PopulateAvailableLegendaStato()
        {
            MySql.Data.MySqlClient.MySqlConnection conn = Layers.ConnectionGateway.ConnectDB();
            conn.Open();
            MySqlCommand command = new MySqlCommand(ConfigurationManager.AppSettings["LegendaStato"].ToString(), conn);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Stato((int)dr["id_stato"], (string)dr["descrizione"]));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
            }
            finally { conn.Close(); }
        }

        public Stato GetStatoById(int IDtoFind)
        {
            Stato result = list.Find(
            delegate(Stato st)
            {
                return st.id == IDtoFind;
            }
            );
            if (result != null) return result;
            else return new Stato(-1, "None");
        }
    }
}