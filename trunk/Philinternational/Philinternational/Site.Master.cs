﻿using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Philinternational
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            adBanner.Height = 60;
            adBanner.Width = 468;
            loadMenuccordion.InnerHtml = LoadMenuAccordion();
            LogoOutput.InnerHtml = loadLogo();
            areaGilardi.InnerHtml = viewOfferteFilatelia();
            //Verifica della visualizzazione Menu left
            if (AccountLayer.IsLogged())
            {
                this.menuLeftAdministration.Visible = AccountLayer.IsAdministrator();
                try
                {
                    ((Label)this.HeadLoginView.FindControl("LoginName")).Text = ((logInfos)Session["log"]).nome;
                }
                catch (Exception)
                {
                    RefreshUnloggedUser();
                }
                shortBasketOutput.InnerHtml = ViewShortBasket();
            }
        }
        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            RefreshUnloggedUser();
        }
        private void RefreshUnloggedUser()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
        private String LoadMenuAccordion() {
            String paragrafo = "";
            String argomento="";
            MySqlDataReader dr;
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            String sql = "SELECT idparagrafo,descrizione FROM paragrafo order by idparagrafo";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;            
            try
            {
                conn.Open();
                dr = command.ExecuteReader();
                if (dr != null)
                {
                    paragrafo = "<div id=\"accordion\">";
                    while (dr.Read())
                    {
                        MySqlDataReader drArg;
                        MySqlConnection conn2 = ConnectionGateway.ConnectDB();   
                        String sqlArg = "SELECT idargomento,descrizione FROM paragrafo_argomento where idparagrafo = "+ (int)dr["idparagrafo"]+" and stato !=0 order by idparagrafo";
                        MySqlCommand commandArg = new MySqlCommand(sqlArg, conn2);
                        commandArg.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            conn2.Open();
                            drArg = commandArg.ExecuteReader();
                            if (drArg != null)
                            {
                                if (drArg.HasRows) {
                                    paragrafo += "<h3 class=\"paragrafo\"><a href=\"#\">" + (String)dr["descrizione"] + "</a></h3>\n";
                                    String rowArg = "";
                                    argomento = "<div class=\"evidenziatore\">\n<ul>\n";
                                    while (drArg.Read())
                                    {
                                        rowArg += "<li class=\"argomento\"><a href=\"" + Page.ResolveClientUrl("~/Lotti/elencoLotto.aspx?arg=" + (int)drArg["idargomento"] + "&subarg=0") + "\" />" + (String)drArg["descrizione"] + "</a></li>\n";
                                    }
                                    argomento += rowArg + "</ul>\n</div>\n";
                                    paragrafo += argomento;
                                }//fine if
                            }
                        }
                        catch (MySql.Data.MySqlClient.MySqlException)
                        {
                            return "Errore ";
                        }
                        finally {
                            conn2.Close();
                        }

                    }
                    paragrafo += "</div>\n";//fine div accordion
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return paragrafo;
            }
            finally
            {
                conn.Close();
            }

            return paragrafo;

        }
        private String loadLogo() {
            String logohead = "<div class=\"Logo\">";
            String logobody = "";
            String logoend = "</div>\n";
            String logoOutput = "";

            logobody = "<a href=\"" + Page.ResolveClientUrl("~/default.aspx") + "\"><img src=\"" + Page.ResolveClientUrl("~/images/masterPage/logo_philtinternational.png") + "\" height=\"91\" width=\"197\" alt=\"Home Page PhilInternational\"/></a>\n";
            logoOutput = (String)(logohead + logobody + logoend);
            return logoOutput;
        
        }
        private String ViewShortBasket() {
            int idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
            String showBasket = "";
            String tmpRow = "";
            float totale =0;
            try
            {
                String sql = "SELECT idlotto, prezzo_offerto FROM offerta_per_corrispondenza WHERE idanagrafica ="+ idAnagrafica +"";
                DataView dr = ConnectionGateway.SelectQuery(sql);
                if (dr.Count > 0) {
                    showBasket += "\n<a href=\"#\" id=\"openOfferte\">Offerte già effettuate</a><div class=\"testo\">\n";
                    showBasket += "<table>";
                    for (int i = 0; i < dr.Count; i++)
                    {
                        tmpRow = "<tr>";
                        tmpRow += "<td style=\"width:20%\"><a href=\"" + Page.ResolveClientUrl("~/Lotti/offerta.aspx?cod=" + dr[i]["idlotto"] + "") + "\">" + dr[i]["idlotto"] + "</a></td>";
                        tmpRow += "<td style=\"width:80%;text-align:right\">" + dr[i]["prezzo_offerto"] + " &euro;</td>";
                        tmpRow += "</tr>\n";
                        totale = totale + float.Parse(dr[i]["prezzo_offerto"].ToString());
                        showBasket += tmpRow;
                    }
                    String rowTotalPrice = "<tr><td colspan=\"2\" style=\"text-align:right;font-weight:bold\">" + totale + " &euro;</td></tr>\n";
                    showBasket += rowTotalPrice;
                    showBasket += "<tr><td colspan=\"2\" style=\"text-align:right;font-weight:bold\"><a href=\"#\" id=\"closeOfferte\" >Chiudi</a></td></tr></table\n></div>\n";
                }
            }
            catch {
                showBasket = "";
            }

            return "";// showBasket;
        }
        private String viewOfferteFilatelia() {
            String showOfferte = "";
            try
            {
                String sql = "SELECT idlotto,anno,descrizione,prezzo FROM offerta_gilardifilatelia where stato=1 order by rand() LIMIT 4";
                DataView dr = ConnectionGateway.SelectQuery(sql);
                if (dr.Count > 0) {
                    showOfferte += "<h3 style=\"text-transform:uppercase;text-align:center\">Offerte www.gilardifilatelia.it</h3>\n";
                    for (int i = 0; i < dr.Count; i++) {
                        /* fase temporanea in attesa di ottimizzare il codice*/
                        String imgName = Page.ResolveClientUrl("~/images/gilardifilatelia/") + dr[i]["idlotto"] + ".jpg";
                        showOfferte += "<div class=\"gilardiFilatelia center\">";
                        showOfferte += "<h3>"+dr[i]["idlotto"] +"</h3>";
                        showOfferte += "<img src=\"" + imgName + "\" width=\"100\" height=\"100\" alt=\"Lotto " + dr[i]["idlotto"]  + "\"/>";
                        showOfferte += "<p style=\"line-height:20px\"><span style=\"text-decoration:underline\">Anno</span>: <span>" + dr[i]["anno"] + "</span></p>\n";
                        showOfferte += "<p style=\"line-height:20px\"><span style=\"text-decoration:underline\">Prezzo</span>: <span>" + dr[i]["prezzo"] + "</span></p>\n";
                        showOfferte += "<p>" + dr[i]["descrizione"] + "</p>";
                        //showOfferte += "<a href=\"" + Page.ResolveClientUrl("~/Varie/ordineGilardiFilatelia.aspx?cod=" + dr[i]["idlotto"]) + "\">Ordina subito</a><br/><br/>\n";
                        showOfferte += "<a href=\"" + Page.ResolveClientUrl("~/Varie/ordineGilardiFilatelia.aspx") +"\">Ordina subito</a><br/><br/>\n";
                        showOfferte += "</div>\n";
                    }
                }
            }
            catch {

                return showOfferte;
            }

            return showOfferte;
        }
    }
}
