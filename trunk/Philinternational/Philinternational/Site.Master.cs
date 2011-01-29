using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;

namespace Philinternational
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadMenuccordion.InnerHtml = LoadMenuAccordion();
            LogoOutput.InnerHtml = loadLogo();
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
            
            String sql = "SELECT idlotto,prezzo_offerto from offerta_per_corrispondenza where idanagrafica=" + idAnagrafica + " order by data_inserimento DESC";
            MySqlDataReader dr = ConnectionGateway.SelectQuery(sql);
            if (!(dr == null))
            {
                if (dr.HasRows)
                {
                    showBasket += "<div><h3>Offerte già effettuate</h3>";
                    showBasket += "<table>";
                    while (dr.Read()) {

                        tmpRow = "<tr>";
                        tmpRow += "<td style=\"width:20%\"><a href=\"#\">"+ dr["idlotto"] +"</a></td>";
                        tmpRow += "<td style=\"width:80%;text-align:right\">" + dr["prezzo_offerto"] + "</td>";
                        tmpRow += "<tr>\n";
                        totale = totale + float.Parse(dr["prezzo_offerto"].ToString());
                        //ciclo da fare
                        showBasket += tmpRow;
                    }
                    String rowTotalPrice = "<tr><td colspan=\"2\" style=\"text-align:right;font-weight:bold\">" + totale + " euro </td></tr>\n";
                    showBasket += rowTotalPrice + "</table></div>\n";
                }
            }
            return showBasket;
        }    
    }
}
