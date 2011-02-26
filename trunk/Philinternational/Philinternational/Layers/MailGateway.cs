using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.ComponentModel;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;

namespace Philinternational.Layers {
    public class MailGateway {
        protected static String SendGenericMail(String mailDestination, String mailSubject, String mailBody) {
            String esito = "";
            try {
                //parameter for send
                String smtp = MailSmtp();
                String username = MailUser();
                String password = MailPassword();
                String mailtoReply = MailtoReply();
                String mailAlias = MailAlias();

                SmtpClient client = new SmtpClient(smtp);
                client.Credentials = new NetworkCredential(username, password);

                MailMessage mailMsg = new MailMessage();

                mailMsg.From = new MailAddress(mailtoReply, mailAlias);
                mailMsg.To.Add(mailDestination);
                mailMsg.IsBodyHtml = true;
                mailMsg.Body = mailBody;
                mailMsg.Subject = mailSubject;
                client.Send(mailMsg);

            } catch (SmtpException ex) {
                Exception inner = ex.GetBaseException();
                esito = "Impossibile inviare il messaggio [ " + inner.Message + "]";
                return esito;
            }
            return esito;
        }

        public static Boolean SendNewsletters(ListItemCollection usersList, List<newsletterEntity> newsletters) {
            foreach (ListItem user in usersList) {
                foreach (newsletterEntity newsletter in newsletters) {
                    if (user.Selected) SendGenericMail(user.Value, newsletter.titolo, newsletter.testo);
                }
            }
            return true;
        }

        private static String MailSmtp() {
            String text = ConfigurationManager.AppSettings["mailSmtp"].ToString();
            return text;
        }

        private static String MailUser() {
            String text = ConfigurationManager.AppSettings["mailUser"].ToString();
            return text;
        }

        private static String MailPassword() {
            String text = ConfigurationManager.AppSettings["mailPassword"].ToString();
            return text;
        }

        private static String MailtoReply() {
            String text = ConfigurationManager.AppSettings["mailtoReply"].ToString();
            return text;
        }

        private static String MailAlias() {
            String text = ConfigurationManager.AppSettings["mailAlias"].ToString();
            return text;
        }




    }
}