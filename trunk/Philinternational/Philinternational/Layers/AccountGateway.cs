using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Configuration;

namespace Philinternational.Layers {
    public class AccountGateway {

        public static String USERINFOS = "SELECT anagrafica.email, anagrafica.password, anagrafica.idanagrafica, anagrafica.nome, anagrafica.cognome, anagrafica.codice_fiscale, anagrafica.dom_via, anagrafica.dom_indirizzo, anagrafica.dom_num_civico, anagrafica.dom_cap, anagrafica.dom_comune, anagrafica.dom_provincia,anagrafica.dom_nazione, anagrafica.stato, anagrafica.data_inserimento, profilo.descrizione AS RoleDescription, profilo.amministrazione AS Role, anagrafica.idprofilo FROM anagrafica INNER JOIN profilo ON anagrafica.idprofilo = profilo.idprofilo WHERE  (anagrafica.email = @email) AND (anagrafica.password = @password) AND stato=1";

        public static logInfos GetUserInfos(string eMail, string password) {
            logInfos myLogInfos = new logInfos();
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            try {
                conn.Open();
                CheckDBPasswordForOldNonEncryption(eMail, password);
                //Encrypt Password
                password = GeneralUtilities.Encrypt(password);

                MySqlCommand command = new MySqlCommand(USERINFOS, conn);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("email", eMail);
                command.Parameters.AddWithValue("password", password);
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read()) {
                    myLogInfos.eMail = (String)dr["email"];
                    myLogInfos.Password = (String)dr["password"];

                    myLogInfos.RoleDescription = (String)dr["RoleDescription"];
                    myLogInfos.Role = (int)dr["Role"];

                    myLogInfos.idAnagrafica = (int)dr["idanagrafica"];
                    myLogInfos.nome = (String)dr["nome"];
                    myLogInfos.cognome = (String)dr["cognome"];
                    myLogInfos.codicefiscale = dr["codice_fiscale"] != null ? dr["codice_fiscale"].ToString() : "";
                    myLogInfos.dom_via = dr["dom_via"] == System.DBNull.Value ? "" : (String)dr["dom_via"];
                    myLogInfos.dom_indirizzo = dr["dom_indirizzo"] == System.DBNull.Value ? "" : (String)dr["dom_indirizzo"];
                    myLogInfos.dom_numcivico = dr["dom_num_civico"] == System.DBNull.Value ? "" : (String)dr["dom_num_civico"];
                    myLogInfos.dom_cap = dr["dom_cap"] == System.DBNull.Value ? "" : (String)dr["dom_cap"];
                    myLogInfos.dom_comune = dr["dom_comune"] == System.DBNull.Value ? "" : (String)dr["dom_comune"];
                    myLogInfos.dom_provincia = dr["dom_provincia"] == System.DBNull.Value ? "" : (String)dr["dom_provincia"];
                    myLogInfos.dom_nazione = dr["dom_nazione"] == System.DBNull.Value ? "" : (String)dr["dom_nazione"];
                    myLogInfos.Stato = (int)dr["stato"];
                    myLogInfos.idprofilo = (int)dr["idprofilo"];
                    myLogInfos.datainserimento = (DateTime)dr["data_inserimento"];
                }
            } catch (MySql.Data.MySqlClient.MySqlException) {
                return new logInfos();
            } finally {
                conn.Close();
            }

            SetLogInfos(myLogInfos);
            return myLogInfos;
        }

        private static void CheckDBPasswordForOldNonEncryption(String email, String password) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            MySqlCommand command = new MySqlCommand(USERINFOS, conn);
            Int32 idAnagrafica = 0;
            String newEncryptedPasswordForDB = password;
            try {
                conn.Open();
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("email", email);
                command.Parameters.AddWithValue("password", password);
                MySqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows) {
                    while (dr.Read()) { idAnagrafica = (int)dr["idanagrafica"]; }
                    if (password.Length < 32) { //se la password inserita da utenza é < 32
                        //...allora sostituisco la password su DB con la stessa ma criptata
                        newEncryptedPasswordForDB = GeneralUtilities.Encrypt(password);
                        AnagraficaGateway.UpdateOldNonEncryptedPassword(idAnagrafica, email, newEncryptedPasswordForDB);
                    }
                }
            } catch (Exception) {
            } finally {
                conn.Close();
            }
        }

        internal static void SetLogInfos(logInfos logInfos) {
            //TODO: Da centralizzare la gestione delle sessioni
            HttpContext.Current.Session["log"] = logInfos;
        }

        public static string GetIdAnagraficaByEmail(String email) {
            String sql = "SELECT idanagrafica valore FROM anagrafica WHERE email='" + email + "'";
            String valore = "--";
            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                valore = dr[i]["valore"].ToString();
            }
            return valore;
        }

        public static string GetEmailByIdAnagrafica(int idAnagrafica) {
            String sql = "SELECT email valore FROM anagrafica WHERE idanagrafica= " + idAnagrafica + "";
            String valore = "";
            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                valore = dr[i]["valore"].ToString();
            }
            return valore;

        }

        public static String GetPersonaFromIdAnagrafica(int idAnagrafica) {
            String sql = "SELECT CONCAT(nome,' ' , cognome)  valore FROM anagrafica WHERE idanagrafica= " + idAnagrafica + "";
            String valore = "";
            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            for (int i = 0; i < dr.Count; i++) {
                valore = dr[i]["valore"].ToString();
            }
            return valore;
        }
        public static DataView ListEmailAdministration() {

            String sql = "SELECT b.email email from profilo a, anagrafica b where a.idprofilo = b.idprofilo and amministrazione =1";
            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);

            return dr;
        }
    }
}