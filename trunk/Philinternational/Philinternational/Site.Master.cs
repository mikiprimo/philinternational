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

            srvAccordion.InnerHtml = LoadMenuAccordion();
            //Verifica della visualizzazione Menu left
            if (AccountLayer.IsLogged())
            {
                this.menuLeftAdministration.Visible = AccountLayer.IsAdministrator();
                this.menuLeftAuthenticated.Visible = AccountLayer.IsLogged();
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
            String a = "";
            String b="";
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
                    a = "<div id=\"accordion\">";
                    while (dr.Read())
                    {
                        
                        MySqlDataReader drArg;
                        MySqlConnection conn2 = ConnectionGateway.ConnectDB();
                        
                        String sqlArg = "SELECT idargomento,descrizione FROM paragrafo_argomento where idparagrafo = "+ (int)dr["idparagrafo"]+" and stato !=0 order by idparagrafo";
                       // Response.Write(sqlArg + "<br/>");
                        MySqlCommand commandArg = new MySqlCommand(sqlArg, conn2);
                        commandArg.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            conn2.Open();
                            drArg = commandArg.ExecuteReader();
                            if (drArg != null)
                            {
                                if (drArg.HasRows) {
                                    a += "<h3><a href=\"#\">" + (String)dr["descrizione"] + "</a></h3>\n";
                                    String rowArg = "";
                                    b = "<div><ul>\n";
                                    while (drArg.Read())
                                    {
                                        //rowArg += "<li class=\"argomento\"><asp:HyperLink NavigateUrl=\"~/elencoLotto.aspx?arg=" + (int)drArg["idargomento"] + "&subarg=0\" runat=\"server\" />" + (String)drArg["descrizione"] + "</asp:HyperLink></li>\n";
                                        rowArg += "<li class=\"argomento\"><a href=\"elencoLotto.aspx?arg=" + (int)drArg["idargomento"] + "&subarg=0\" />" + (String)drArg["descrizione"] + "</a></li>\n";

                                    }
                                    b += rowArg + "</ul>\n</div>\n";
                                    //Response.Write(a + "<br/>");
                                    a += b;
                                }
                                
                                
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
                    a += "</div>\n";//fine div accordion
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return a;
            }
            finally
            {
                conn.Close();
            }

            return a;

        }
        private void LoadLottiRandom() { }
        private void LoadBannerRandom() { }
    }
}
