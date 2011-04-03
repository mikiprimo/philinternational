using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.ComponentModel;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Text;

namespace Philinternational.Layers {
    public class MailList : MailGateway {

        public static String SendOffertaToUser(String userName, String eMail, String idLotto, String offerta, String idAsta) {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] Comunicazione offerta lotto " + idLotto + " dell'asta " + idAsta;
            BodyMail = "G.le " + userName + ",<br/>";
            BodyMail += "le comunichiamo che l'offerta di " + offerta + " euro relativa al lotto num&deg;" + idLotto + " è stata effettuata con successo.<br/>";
            BodyMail += "Al termine della seduta la contatteremo per comunicarle l'esito della sua offerta<br/>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            esito = SendGenericMail(eMail, soggetto, BodyMail);
            return esito;
        }

        public static String SendOffertaNoAstaToUser(String userName, String eMail, String idLotto)
        {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] Comunicazione aggiudicazione lotto " + idLotto;
            BodyMail = "Egregio " + userName + ",<br/>";
            BodyMail += "grazie per aver ordinato il lotto num&deg; " + idLotto + " come da condizioni di vendita al prezzo sono da aggiungere il 20% di commissione e le eventuali spese postali.<br/>";
            BodyMail += "A breve riceverà una mail con la nota di aggiudicazione ed i metodi di pagamento accettati.<br/>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            esito = SendGenericMail(eMail, soggetto, BodyMail);
            return esito;
        }
        public static String AvvisoOffertaAdmin(String userName, String idLotto, String offerta) {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[Offerta lotto] offerta di " + userName + " per lotto " + idLotto;
            BodyMail = "<p style=\"font-family:'Arial'\">Il cliente  " + userName + ",<br/>";
            BodyMail += "ha appena effettuato un'offerta di <b>" + offerta + "</b> euro relativa al lotto num&deg;" + idLotto + ".<br/></p>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            DataView mailAmministratori = Layers.AccountGateway.ListEmailAdministration();
            if (mailAmministratori.Count > 0) {
                for (int i = 0; i < mailAmministratori.Count; i++) {
                    esito = SendGenericMail(mailAmministratori[i]["email"].ToString(), soggetto, BodyMail);
                }
            }

            return esito;
        }

        public static String AvvisoAcquistoLottoNoAstaAdmin(String userName, String idLotto, String offerta)
        {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[lotto fuori asta] Proposta acquisto lotto " + idLotto + " fuori asta dell'utente " + userName;
            BodyMail = "<p>Il cliente  " + userName + ",<br/>";
            BodyMail += "ha appena richiesto di acquistare il lotto num&deg;" + idLotto + " del valore di <b>" + offerta + "</b> euro <br/></p>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            DataView mailAmministratori = Layers.AccountGateway.ListEmailAdministration();
            if (mailAmministratori.Count > 0)
            {
                for (int i = 0; i < mailAmministratori.Count; i++)
                {
                    esito = SendGenericMail(mailAmministratori[i]["email"].ToString(), soggetto, BodyMail);
                }
            }

            return esito;
        }
        public static String lottoAggiudicato(String persona, String eMail, String idLotto, String idAsta) {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] Comunicazione assegnazione lotto " + idLotto + " dell'asta " + idAsta;
            BodyMail = "G.le " + persona + ",<br/>";
            BodyMail += "le comunichiamo che si è aggiudicato il lotto " + idLotto + ".<br/>";
            BodyMail += "Nei prossimi giorni la contatteremo per determinare la modalità di pagamento.<br/>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            esito = SendGenericMail(eMail, soggetto, BodyMail);
            return esito;
        }
        public static String lottoPerso() { return ""; }
        public static String RegistrazioneUtente(String persona, String email, String password) {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] Conferma registrazione per " + persona;
            BodyMail = "G.le " + persona + ",<br/>";
            BodyMail += "di seguito le riportiamo i dati per poter accedere al sito e poter effettuare le sue offerte.<br/>";
            BodyMail += "username:<b>" + email + "</b><br/>";
            BodyMail += "password:" + password + "<br/><br/>";
            BodyMail += "Le ricordiamo di conservare con cura i dati di accesso.<br/>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            esito = SendGenericMail(email, soggetto, BodyMail);
            return esito;

        }

        public static String AttivazioneUtente(String persona, String email)
        {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] Conferma attivazione utenza";
            BodyMail = "G.le " + persona + ",<br/>";
            BodyMail += "la sua utenza è stata processata ed attivata correttamente.<br/>";
            BodyMail += "Le auguriamo una buona navigazione<br/>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            esito = SendGenericMail(email, soggetto, BodyMail);
            return esito;

        }

        public static String AvvisoAdminNuovaRegistrazione(String email) {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] nuova registrazione: " + email;
            BodyMail = "Amministratore,<br/>";
            BodyMail += "Si è appena registrato: " + email + "<br/>";
            BodyMail += "Per il dettaglio accedi al pannello di amministrazione<br/>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            DataView mailAmministratori = Layers.AccountGateway.ListEmailAdministration();
            if (mailAmministratori.Count > 0) {
                for (int i = 0; i < mailAmministratori.Count; i++) {
                    esito = SendGenericMail(mailAmministratori[i]["email"].ToString(), soggetto, BodyMail);
                }
            }

            return esito;

        }

        internal static Boolean CambioPassword(string persona, string email, string password) {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] Conferma cambio password per " + persona;
            BodyMail = "G.le " + persona + ",<br/>";
            BodyMail += "di seguito le riportiamo i nuovi dati per poter accedere al sito e poter effettuare le sue offerte.<br/>";
            BodyMail += "username:<b>" + email + "</b><br/>";
            BodyMail += "password:" + password + "<br/><br/>";
            BodyMail += "Le ricordiamo di conservare con cura i dati di accesso.<br/>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            esito = SendGenericMail(email, soggetto, BodyMail);
            return esito == "" ? true : false;
        }

        internal static Boolean ContattiToAdministrator(String riferimento, String subject, String mailMittente,String oggetto,String dataComunicazione) {
            
            String esitoMail = "";
            Boolean esito = false;
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] " + subject;
            BodyMail = "Il/la signor/signora " + riferimento + ",<br/>";
            BodyMail += "ha scritto quanto segue:<br/>";
            BodyMail += "<p>" + oggetto + "</p>";
            BodyMail += "<p>Alle ore: <b>" + dataComunicazione + "</b></p>";
            BodyMail += "<p>riferimento Mail: <b>" + mailMittente + "</b></p>";
            BodyMail += "Cordiali Saluti<br/>O' webmaster<br/>";

            DataView mailAmministratori = Layers.AccountGateway.ListEmailAdministration();
            if (mailAmministratori.Count > 0)
            {
                for (int i = 0; i < mailAmministratori.Count; i++)
                {
                    esitoMail = SendGenericMail(mailAmministratori[i]["email"].ToString(), soggetto, BodyMail);
                }
            }
            if (esitoMail != "") esito = true;
            return esito;
        }
        internal static Boolean ContattiToGuest(String riferimento, String subject, String mailMittente, String oggetto) {
            String esitoMail = "";
            Boolean esito = false;
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] COPIA " + subject;
            BodyMail = "<p>Il/la signor/signora " + riferimento + ",<br/>";
            BodyMail += "ha scritto quanto segue:</p>";
            BodyMail += "<p>" + oggetto + "</p>";
            BodyMail += "<p>riferimento Mail: " + mailMittente + "</p>";
            BodyMail += "Cordiali Saluti<br/>Lo Staff<br/>";
            esitoMail = SendGenericMail(mailMittente, soggetto, BodyMail);
            if (esitoMail != "") esito = true;
            return esito;
        }

        internal static Boolean OffertaGilardiFilatelia(String riferimento, String subject, String mailMittente, String oggetto, String dataComunicazione)
        {

            String esitoMail = "";
            Boolean esito = false;
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] " + subject;
            BodyMail = "Il/la signor/signora " + riferimento + ",<br/>";
            BodyMail += "ha scritto quanto segue:<br/>";
            BodyMail += "<p>" + oggetto + "</p>";
            BodyMail += "<p>Alle ore: <b>" + dataComunicazione + "</b></p>";
            BodyMail += "<p>riferimento Mail: <b>" + mailMittente + "</b></p>";
            BodyMail += "Cordiali Saluti<br/>O' webmaster<br/>";

            DataView mailAmministratori = Layers.AccountGateway.ListEmailAdministration();
            if (mailAmministratori.Count > 0)
            {
                for (int i = 0; i < mailAmministratori.Count; i++)
                {
                    esitoMail = SendGenericMail(mailAmministratori[i]["email"].ToString(), soggetto, BodyMail);
                }
            }
            if (esitoMail != "") esito = true;
            return esito;
        }
        internal static Boolean OffertaGilardiFilateliaToGuest(String riferimento, String subject, String mailMittente, String oggetto)
        {
            String esitoMail = "";
            Boolean esito = false;
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational.it] COPIA " + subject;
            BodyMail = "<p>Il/la signor/signora " + riferimento + ",<br/>";
            BodyMail += "ha scritto quanto segue:</p>";
            BodyMail += "<p>" + oggetto + "</p>";
            BodyMail += "<p>riferimento Mail: " + mailMittente + "</p>";
            BodyMail += "Cordiali Saluti<br/>Lo Staff<br/>";
            esitoMail = SendGenericMail(mailMittente, soggetto, BodyMail);
            if (esitoMail != "") esito = true;
            return esito;
        
        
        }
    }
}