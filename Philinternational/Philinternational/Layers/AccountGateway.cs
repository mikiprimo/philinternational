using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Philinternational.Layers
{
    public class AccountGateway
    {
        public static logInfos GetUserInfos(string eMail, string password)
        {
            logInfos myLogInfos = new logInfos();
            MySql.Data.MySqlClient.MySqlConnection conn = ConnectionGateway.ConnectDB();

            try
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand(ConfigurationManager.AppSettings["UserInfos"].ToString(),conn);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("email", eMail);
                command.Parameters.AddWithValue("password", password);
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    myLogInfos.eMail = (String)dr["email"];
                    myLogInfos.Password = (String)dr["password"];

                    myLogInfos.RoleDescription = (String)dr["RoleDescription"];
                    myLogInfos.Role = (int)dr["Role"];

                    myLogInfos.idAnagrafica = (int)dr["idanagrafica"];
                    myLogInfos.nome = (String)dr["nome"];
                    myLogInfos.cognome = (String)dr["cognome"];
                    myLogInfos.codicefiscale = dr["codice_fiscale"] != null ? dr["codice_fiscale"].ToString() : "";
                    myLogInfos.dom_via = (String)dr["dom_via"];
                    myLogInfos.dom_indirizzo = (String)dr["dom_indirizzo"];
                    myLogInfos.dom_numcivico = (String)dr["dom_num_civico"];
                    myLogInfos.dom_cap = (String)dr["dom_cap"];
                    myLogInfos.dom_comune = (String)dr["dom_comune"];
                    myLogInfos.dom_provincia = (String)dr["dom_provincia"];
                    myLogInfos.dom_nazione = (String)dr["dom_nazione"];
                    myLogInfos.stato = (int)dr["stato"];
                    myLogInfos.idprofilo = (int)dr["idprofilo"];
                    myLogInfos.datainserimento = (DateTime)dr["data_inserimento"];
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return new logInfos();
            }

            SetLogInfos(myLogInfos);
            return myLogInfos;
        }

        internal static void SetLogInfos(logInfos logInfos)
        {
            //TODO: Da centralizzare la gestione delle sessioni
            HttpContext.Current.Session["log"] = logInfos;
        }
    }
}