using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.ComponentModel;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Text;

namespace Philinternational.Layers
{
    public class MailList : MailGateway
    {

        public static String SendOffertaToUser(String userName, String eMail, String idLotto, String offerta, String idAsta)
        {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational] Comunicazione offerta lotto " + idLotto + " dell'asta " + idAsta;
            BodyMail = "G.le " + userName + ",<br/>";
            BodyMail += "le comunichiamo che l'offerta di " + offerta + " euro relativa al lotto num&deg;" + idLotto + " è stata effettuata con successo.<br/>";
            BodyMail += "Al termine della seduta la contatteremo per comunicarle l'esito della sua offerta<br/>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            esito = SendGenericMail(eMail, soggetto, BodyMail);
            return esito;
        }
        public static String AvvisoOffertaAdmin(String userName, String idLotto, String offerta) {
            String esito = "";
            String soggetto = "";
            String BodyMail = "";
            soggetto = "[philinternational] offerta di " + userName + " per lotto " + idLotto;
            BodyMail = "G.le " + userName + ",<br/>";
            BodyMail += "le comunichiamo che l'offerta di " + offerta + " euro relativa al lotto num&deg;" + idLotto + " è stata effettuata con successo.<br/>";
            BodyMail += "Al termine della seduta la contatteremo per comunicarle l'esito della sua offerta<br/>";
            BodyMail += "Cordiali Saluti<br/>Lo staff<br/>";
            DataView mailAmministratori = Layers.AccountGateway.ListEmailAdministration();
            if (mailAmministratori.Count > 0) {
                for (int i = 0; i < mailAmministratori.Count; i++) {
                    esito = SendGenericMail(mailAmministratori[i]["email"].ToString(), soggetto, BodyMail);    
                }
            }
            
            return esito;            
             }
        public static String lottoAggiudicato(String email,String idLotto) { return ""; }
        public static String lottoPerso() { return ""; }
        public static String RegistrazioneUtente(String email, String password) { return ""; }
        public static String AvvisoAdminNuovaRegistrazione(String email) { return ""; }
    }
}