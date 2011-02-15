using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Philinternational.Layers {
    public class AnagraficaGateway {
        //TODO: Aggiungere Partita Iva
        private static string INSERT_ANAGRAFICA = "INSERT INTO anagrafica (idanagrafica, nome, cognome, codice_fiscale, partita_iva, res_via, res_indirizzo, res_num_civico, res_cap, res_comune, res_provincia, res_nazione, dom_via, dom_indirizzo, dom_num_civico, dom_cap, dom_comune, email, dom_provincia, dom_nazione, password, stato, data_inserimento, idprofilo) VALUES (@idanagrafica, @nome, @cognome, @codice_fiscale, @partita_iva, @res_via, @res_indirizzo, @res_num_civico, @res_cap, @res_comune, @res_provincia, @res_nazione, @dom_via, @dom_indirizzo, @dom_num_civico, @dom_cap, @dom_comune, @email, @dom_provincia, @dom_nazione, @password, @stato, @data_inserimento, @idprofilo)";
        private static string SELECT_MAIL_ESISTENTE = "SELECT Count(*) FROM anagrafica WHERE email = @email";
        private static string SELECT_ANAGRAFICA = "SELECT idanagrafica, nome, cognome, codice_fiscale, partita_iva, res_via, res_indirizzo, res_num_civico, res_cap, res_comune, res_provincia, res_nazione, dom_via, dom_indirizzo, dom_num_civico, dom_cap, dom_comune, email, dom_provincia, dom_nazione, password, stato, data_inserimento, idprofilo FROM anagrafica";
        private static String UPDATE_ANAGRAFICA_STATO = "UPDATE anagrafica SET stato = @stato WHERE email = @email";
        private static String IS_SUBSCRIBED_TO_NEWSLETTER = "SELECT Count(*) FROM anagrafica_dettaglio WHERE idanagrafica = @idanagrafica AND newsletter = 1";
        private static string SELECT_NEWSLETTER_ENABLED_USERS = "SELECT nome, cognome, email FROM anagrafica aa, anagrafica_dettaglio ad WHERE aa.idanagrafica = ad.idanagrafica AND ad.newsletter = 1";


        internal static Boolean InsertAnagrafica(anagraficaEntity newUser) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_ANAGRAFICA, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idanagrafica", newUser.idanagrafica);
            command.Parameters.AddWithValue("nome", newUser.nome);
            command.Parameters.AddWithValue("cognome", newUser.cognome);
            command.Parameters.AddWithValue("codice_fiscale", newUser.codice_fiscale);
            command.Parameters.AddWithValue("partita_iva", newUser.partita_iva);
            command.Parameters.AddWithValue("email", newUser.email);
            command.Parameters.AddWithValue("password", newUser.password);
            command.Parameters.AddWithValue("res_via", newUser.res_via);
            command.Parameters.AddWithValue("res_indirizzo", newUser.res_indirizzo);
            command.Parameters.AddWithValue("res_num_civico", newUser.res_num_civico);
            command.Parameters.AddWithValue("res_cap", newUser.res_cap);
            command.Parameters.AddWithValue("res_comune", newUser.res_comune);
            command.Parameters.AddWithValue("res_provincia", newUser.res_provincia);
            command.Parameters.AddWithValue("res_nazione", newUser.res_nazione);
            command.Parameters.AddWithValue("dom_via", newUser.dom_via);
            command.Parameters.AddWithValue("dom_indirizzo", newUser.dom_indirizzo);
            command.Parameters.AddWithValue("dom_num_civico", newUser.dom_num_civico);
            command.Parameters.AddWithValue("dom_cap", newUser.dom_cap);
            command.Parameters.AddWithValue("dom_comune", newUser.dom_comune);
            command.Parameters.AddWithValue("dom_provincia", newUser.dom_provincia);
            command.Parameters.AddWithValue("dom_nazione", newUser.dom_nazione);
            //Altri
            command.Parameters.AddWithValue("stato", new Stato(99, "da attivare").id);
            command.Parameters.AddWithValue("idprofilo", 2);
            command.Parameters.AddWithValue("data_inserimento", DateTime.Now);

            try {
                conn.Open();
                command.ExecuteNonQuery();
            } catch (MySqlException) {
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }

        internal static Boolean ExistMail(String mail) {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_MAIL_ESISTENTE, conn)) {
                try {
                    cmd.Parameters.AddWithValue("email", mail);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt.Rows.Count > 0 ? true : false;
                } catch (MySqlException) {
                    return true;
                }
            }
        }

        internal static DataView SelectAnagrafica() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_ANAGRAFICA, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
                try {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dv = dt.DefaultView;

                    return dv;
                } catch (MySqlException) {
                    return dv;
                }
            }
        }

        internal static Boolean UpdateStatoByMailAnagrafica(string mailAnagrafica, int stato) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(UPDATE_ANAGRAFICA_STATO, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("email", mailAnagrafica);
            command.Parameters.AddWithValue("stato", stato);

            try {
                conn.Open();
                command.ExecuteNonQuery();
            } catch (MySqlException) {
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }

        internal static Boolean DeleteAnagrafiche(List<String> AnagraficheMailsToBeErased) {
            String DELETE_ANAGRAFICA = "DELETE FROM anagrafica WHERE @ComposedConditions";
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            StringBuilder sb = new StringBuilder();
            foreach (String item in AnagraficheMailsToBeErased) {
                sb.Append("email = '" + item.ToString() + "' OR ");
            }
            sb.Append("1=0");

            DELETE_ANAGRAFICA = DELETE_ANAGRAFICA.Replace("@ComposedConditions", sb.ToString());
            MySqlCommand command = new MySqlCommand(DELETE_ANAGRAFICA, conn);
            command.CommandType = CommandType.Text;
            try {
                conn.Open();
                command.ExecuteNonQuery();
            } catch (MySqlException) {
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }

        internal static Boolean IsSubscribedToNewsletters(string idAnagrafica) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(IS_SUBSCRIBED_TO_NEWSLETTER, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idanagrafica", idAnagrafica);
            Boolean res = false;

            try {
                conn.Open();
                object obj = command.ExecuteScalar();

                if (obj != System.DBNull.Value) {
                    res = Convert.ToInt32(obj) == 1 ? true : false;
                }
            } catch (MySqlException) {
                return false;
            } finally {
                conn.Close();
            }
            return res;
        }

        internal static DataView SelectNewsletterEnabledUsers() {
            DataView dv = new DataView();
            using (MySqlConnection conn = ConnectionGateway.ConnectDB())
            using (MySqlCommand cmd = new MySqlCommand(SELECT_NEWSLETTER_ENABLED_USERS, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
                try {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dv = dt.DefaultView;

                    return dv;
                } catch (MySqlException) {
                    return dv;
                }
            }
        }
    }
}