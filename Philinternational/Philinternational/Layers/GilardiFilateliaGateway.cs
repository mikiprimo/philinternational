using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text;

namespace Philinternational.Layers
{
    public class GilardiFilateliaGateway
    {
        /// <summary>
        /// Operational functions About OffertaGilardiFilaelia (OffertaGilardiFilaelia.aspx and OffertaGilardiFilaeliaDetail.aspx)
        /// </summary>
        private static String SELECT= "SELECT idofferta, idlotto,anno,descrizione,prezzo,stato, DATE_FORMAT(data_inserimento,'%d.%m.%Y') as data_pubblicazione FROM offerta_gilardifilatelia ORDER BY data_inserimento DESC";
        private static String SELECTBYID = "SELECT idofferta, idlotto,anno,descrizione,prezzo,stato, DATE_FORMAT(data_inserimento,'%d.%m.%Y') as data_pubblicazione FROM offerta_gilardifilatelia where idofferta=@codice ORDER BY data_inserimento DESC";
        private static String _INSERT = "INSERT INTO offerta_gilardifilatelia (idofferta,idlotto, anno, descrizione, prezzo, stato, data_inserimento) VALUES (@idofferta,@idlotto, @anno, @descrizione, @prezzo, @valueStato, @data_inserimento)";
        private static String _UPDATE = "UPDATE offerta_gilardifilatelia SET idlotto = @idlotto,descrizione = @descrizione,anno = @anno,prezzo = @prezzo,stato = @valueStato,data_inserimento = @data_inserimento WHERE idofferta = @idofferta";
        private static String _UPDATE_STATE = "UPDATE offerta_gilardifilatelia SET stato = @valueStato WHERE idofferta = @idofferta";
        internal static object SelectRows()
        {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dv = dt.DefaultView;

                    return dv;
                }
                catch (MySqlException)
                {
                    return dv;
                }
            }
        }
        public static Boolean DeleteRow() { return false; }

        internal static GilardiFilateliaEntity GetLottoById(string codice)
        {
            MySqlDataReader dr;
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(SELECTBYID, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("codice", codice);
            GilardiFilateliaEntity myOnlyNews;
            try
            {
                conn.Open();
                dr = command.ExecuteReader();
                myOnlyNews = new GilardiFilateliaEntity();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        DateTime.TryParse(dr["data_inserimento"].ToString(), out myOnlyNews.dataInserimento);
                        myOnlyNews.idOfferta= (int)dr["idofferta"];
                        myOnlyNews.idLotto = (int)dr["idlotto"];
                        myOnlyNews.prezzo = (float)dr["prezzo"];
                        myOnlyNews.anno = (String)dr["anno"];
                        myOnlyNews.descrizione = (String)dr["testo"];
                        myOnlyNews.state = new Stato((int)dr["stato"], Layers.Commons.GetStato((int)dr["stato"]));
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return myOnlyNews;
        }
        internal static Boolean InsertRow(GilardiFilateliaEntity Myentity)
        {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_INSERT, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idofferta", Myentity.idOfferta);
            command.Parameters.AddWithValue("idlotto", Myentity.idLotto);

            command.Parameters.AddWithValue("anno", Myentity.anno);
            command.Parameters.AddWithValue("descrizione", Myentity.descrizione);
            command.Parameters.AddWithValue("prezzo", Myentity.prezzo);
            command.Parameters.AddWithValue("valueStato", Myentity.state.id);
            command.Parameters.AddWithValue("data_inserimento", Myentity.dataInserimento);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        internal static Boolean UpdateRow(GilardiFilateliaEntity MyEntity)
        {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idofferta", MyEntity.idOfferta);
            command.Parameters.AddWithValue("idlotto", MyEntity.idLotto);
            command.Parameters.AddWithValue("data_inserimento", MyEntity.dataInserimento);
            command.Parameters.AddWithValue("anno", MyEntity.anno);
            command.Parameters.AddWithValue("descrizione", MyEntity.descrizione);
            command.Parameters.AddWithValue("prezzo", MyEntity.prezzo);
            command.Parameters.AddWithValue("valueStato", MyEntity.state.id);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        internal static Boolean DeleteRowsByIdList(List<String> RowsIdToBeErased)
        {
            String _DELETE_IDNEWSLIST = "DELETE FROM offerta_gilardifilatelia WHERE @ComposedConditions";

            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (String item in RowsIdToBeErased)
            {
                sb.Append("idofferta = " + item + " OR ");
            }
            sb.Append("1=0");

            _DELETE_IDNEWSLIST = _DELETE_IDNEWSLIST.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(_DELETE_IDNEWSLIST, conn);
            command.CommandType = CommandType.Text;
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        internal static Boolean UpdateRowStateById(string idRow, int newState)
        {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(_UPDATE_STATE, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idOfferta", idRow);
            command.Parameters.AddWithValue("valueStato", newState);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    
    }
}