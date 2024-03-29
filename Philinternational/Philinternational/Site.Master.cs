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
using System.Web.Routing;

namespace Philinternational
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogoOutput.InnerHtml = loadLogo();            
            loadMenuccordion.InnerHtml = LoadMenuAccordion();
            areaGilardi.InnerHtml = viewOfferteFilatelia();
            //Verifica della visualizzazione Menu left
            if (AccountLayer.IsLogged())
            {
                this.PanelAdmin.Visible = AccountLayer.IsAdministrator();
                String esitoOfferta = ViewShortBasket();
                if (esitoOfferta != "") {

                    panelUser.InnerHtml = esitoOfferta;
                }
                try
                {
                    ((Label)this.HeadLoginView.FindControl("LoginName")).Text = ((logInfos)Session["log"]).nome;
                }
                catch (Exception)
                {
                    RefreshUnloggedUser();
                }
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
            String sql = "SELECT idparagrafo,descrizione FROM paragrafo where stato = 1 order by idparagrafo";
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
                        String sqlArg = "SELECT idargomento,descrizione FROM paragrafo_argomento where idparagrafo = " + (int)dr["idparagrafo"] + " and stato !=0 order by descrizione";
                        MySqlCommand commandArg = new MySqlCommand(sqlArg, conn2);
                        commandArg.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            conn2.Open();
                            drArg = commandArg.ExecuteReader();
                            if (drArg != null)
                            {
                                if (drArg.HasRows) {
                                    paragrafo += "<h3 class=\"paragrafo\"><a href=\"#\" title=\"Collezione " + (String)dr["descrizione"] + "\">" + (String)dr["descrizione"] + "</a></h3>\n";
                                    String rowArg = "";
                                    String nomeArgomento = "Lotti riferiti a " +  (String)dr["descrizione"];
                                    argomento = "<div class=\"evidenziatore\">\n<ul>\n";
                                    while (drArg.Read())
                                    {
                                        String vpdCapitolo = (String)dr["descrizione"];
                                        String vpdParagrafo =  (String)drArg["descrizione"];
                                        RouteValueDictionary parameters = new RouteValueDictionary { { "capitolo", vpdCapitolo.Replace(" ","-") }, { "paragrafo",vpdParagrafo.Replace(" ","-") }, { "idpar", (int)drArg["idargomento"] } };
                                        VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(null, "ElencoLotto", parameters);
                                       // rowArg += "<li class=\"argomento\"><a href=\"" + Page.ResolveClientUrl("~/Lotti/elencoLotto.aspx?arg=" + (int)drArg["idargomento"] + "&amp;subarg=0") + "\" title=\""+ (String)drArg["descrizione"] + "\" >" + (String)drArg["descrizione"] + "</a></li>\n";
                                         rowArg += "<li class=\"argomento\"><a href=\"" + vpd.VirtualPath + "\" title=\""+ nomeArgomento + " " + (String)drArg["descrizione"] + "\" >" + (String)drArg["descrizione"] + "</a></li>\n";
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

            logobody = "<a href=\"" + Page.ResolveClientUrl("~/Default.aspx") + "\"><img src=\"" + Page.ResolveClientUrl("~/images/masterPage/logo_philtinternational.png") + "\" height=\"91\" width=\"197\" alt=\"Home Page PhilInternational\"/></a>\n";
            logoOutput = (String)(logohead + logobody + logoend);
            return logoOutput;
        
        }
        private String ViewShortBasket() {
            int idAnagrafica = 0; 
            String showBasket = "";
            String tmpRow = "";
            float totale =0;
            try
            {
                idAnagrafica = ((logInfos)Session["log"]).idAnagrafica;
                //String sql = "SELECT idlotto, prezzo_offerto FROM offerta_per_corrispondenza WHERE idanagrafica ="+ idAnagrafica +"";
                String  sql ="SELECT o.idlotto idlotto ";
                        sql += ",o.prezzo_offerto prezzo_offerto ";
                        sql += ", b.id_argomento idargomento ";
                        sql += ",p.descrizione capitolo ";
                        sql += ",pa.descrizione paragrafo ";
                        sql += "from offerta_per_corrispondenza o";
                        sql +="    ,lotto b";
                        sql +="    ,paragrafo_argomento pa";
                        sql +="    ,paragrafo p ";
                        sql +=" where o.idlotto = b.idlotto";
                        sql +="  and b.id_argomento = pa.idargomento";
                        sql +=" and pa.idparagrafo = p.idparagrafo";
                        sql += " and o.idAnagrafica = " + idAnagrafica + "";
                        sql +=" order by data_inserimento DESC";
                        //Response.Write("gestioneordini[" + sql + "]");
                 
                DataView dr = ConnectionGateway.SelectQuery(sql);
                if (dr.Count > 0) {
                    showBasket += "<h3>Le mie offerte&nbsp;<a href=\"#\"  id=\"user1\">[ Chiudi ]</a></h3>\n";
                    showBasket += "<table id=\"listuser\">";
                    for (int i = 0; i < dr.Count; i++)
                    {
                        String vpdCapitolo = dr[i]["capitolo"].ToString();
                        String vpdParagrafo = dr[i]["paragrafo"].ToString();
                        RouteValueDictionary parameters = new RouteValueDictionary { { "capitolo", vpdCapitolo.Replace(" ", "-") }, { "paragrafo", vpdParagrafo.Replace(" ", "-") }, { "idpar", dr[i]["idargomento"] }, { "idlotto", dr[i]["idlotto"] } };
                        VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(null, "OffertaLotto", parameters);


                        tmpRow = "<tr>";
                        //tmpRow += "<td style=\"width:20%\"><a href=\"" + Page.ResolveClientUrl("~/Lotti/offerta.aspx?cod=" + dr[i]["idlotto"] + "") + "\">" + dr[i]["idlotto"] + "</a></td>";
                        tmpRow += "<td style=\"width:20%\"><a href=\"" + vpd.VirtualPath + "\">" + dr[i]["idlotto"] + "</a></td>";
                        tmpRow += "<td style=\"width:80%;text-align:right\">" + dr[i]["prezzo_offerto"] + " &euro;</td>";
                        tmpRow += "</tr>\n";
                        totale = totale + float.Parse(dr[i]["prezzo_offerto"].ToString());
                        showBasket += tmpRow;
                    }
                    String rowTotalPrice = "<tr><td colspan=\"2\" style=\"margin:1px 0px 0px 0px;text-align:right;font-weight:bold;border-top:1px solid #920000;background-color:#fff\">" + totale + " &euro;</td></tr>\n";
                    showBasket += rowTotalPrice + "</table>\n";
                }
            }
            catch {
                showBasket = "";
            }

            return showBasket;
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
                        String imgName = Page.ResolveClientUrl("~/images/gilardifilatelia/thumb/") + dr[i]["idlotto"] + ".jpg";
                        showOfferte += "<div class=\"gilardiFilatelia center\">";
                        showOfferte += "<h3>"+dr[i]["idlotto"] +"</h3>";
                        showOfferte += "<img src=\"" + imgName + "\" width=\"100\" height=\"100\" alt=\"Lotto " + dr[i]["idlotto"]  + "\"/>";
                        showOfferte += "<p style=\"line-height:20px\"><span style=\"text-decoration:underline\">Anno</span>: <span>" + dr[i]["anno"] + "</span></p>\n";
                        showOfferte += "<p style=\"line-height:20px\"><span style=\"text-decoration:underline\">Prezzo</span>: <span>" + dr[i]["prezzo"] + "</span></p>\n";
                        showOfferte += "<p>" + dr[i]["descrizione"] + "</p>";
                        showOfferte += "<a href=\"" + Page.ResolveClientUrl("~/Varie/ordineGilardiFilatelia.aspx") +"\" title=\"Ordina subito\">Ordina subito</a><br/><br/>\n";
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
