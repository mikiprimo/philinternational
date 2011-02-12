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
        private static string INSERT_ANAGRAFICA = "INSERT INTO anagrafica (idanagrafica, nome, cognome, codice_fiscale, res_via, res_indirizzo, res_num_civico, res_cap, res_comune, res_provincia, res_nazione, dom_via, dom_indirizzo, dom_num_civico, dom_cap, dom_comune, email, dom_provincia, dom_nazione, password, stato, data_inserimento, idprofilo) VALUES (@idanagrafica, @nome, @cognome, @codice_fiscale, @res_via, @res_indirizzo, @res_num_civico, @res_cap, @res_comune, @res_provincia, @res_nazione, @dom_via, @dom_indirizzo, @dom_num_civico, @dom_cap, @dom_comune, @email, @dom_provincia, @dom_nazione, @password, @stato, @data_inserimento, @idprofilo)";
        private static string SELECT_MAIL_ESISTENTE = "SELECT Count(*) FROM anagrafica WHERE email = @email";


        internal static Boolean InsertAnagrafica(anagraficaEntity newUser) {
            MySqlConnection conn = ConnectionGateway.ConnectDB();

            MySqlCommand command = new MySqlCommand(INSERT_ANAGRAFICA, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("idanagrafica", newUser.idanagrafica);
            command.Parameters.AddWithValue("nome", newUser.nome);
            command.Parameters.AddWithValue("cognome", newUser.cognome);
            command.Parameters.AddWithValue("codice_fiscale", newUser.codice_fiscale);
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
                } catch (MySqlException ex) {
                    return true;
                }
            }
        }
    }
}