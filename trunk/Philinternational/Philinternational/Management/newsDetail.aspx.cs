using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Philinternational.Layers;
using System.Text;

namespace Philinternational.Management
{
    public partial class newsDetails : System.Web.UI.Page
    {
        public String Codice
        {
            get { return ((String)ViewState["operationCode"]); }
            set { ViewState.Add("operationCode", value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String codice = Request["cod"];
                if ((codice == null) || (codice == "-1")) codice = "-1";
                this.Codice = codice;

                if (this.Codice != "-1")
                {
                    NewsEntity myNews = NewsGateway.GetNewsById(codice);
                    lblDataPubblicazione.Text = myNews.dataPubblicazione.ToString("dd/MM/yyyy");
                    txtTitolo.Text = myNews.titolo;
                    txtTesto.Text = myNews.testo;
                    chkStato.Checked = Commons.GetCheckedState(myNews.state.id);
                }
            }
        }

        protected void conferma(object sender, EventArgs e)
        {
            NewsEntity MyNews = new NewsEntity();
            Boolean esito = false;

            if (this.Codice == "-1")
            {
                MyNews.dataPubblicazione = DateTime.Now;
                MyNews.id = Layers.ConnectionGateway.CreateNewIndex("idnews", "news");
                MyNews.titolo = txtTitolo.Text;
                MyNews.testo = txtTesto.Text;
                MyNews.state = new Stato(Commons.GetCheckedState(chkStato.Checked), "");

                esito = NewsGateway.InsertNews(MyNews);
            }
            else
            {
                MyNews.dataPubblicazione = DateTime.Now; // Da sostituire con la data immessa da utente
                MyNews.id = Convert.ToInt32(this.Codice);
                MyNews.titolo = txtTitolo.Text;
                MyNews.testo = txtTesto.Text;
                MyNews.state = new Stato(Commons.GetCheckedState(chkStato.Checked), "");

                esito = NewsGateway.UpdateNews(MyNews);
            }

            ExamineResults(esito);
        }

        /// <summary>
        /// Page level results manager
        /// </summary>
        /// <param name="esito"></param>
        private void ExamineResults(Boolean esito)
        {
            if (esito) esitoMessaggio.InnerHtml = "<span style=\"color:red\">Operazione effettuato con successo</span>";
            else esitoMessaggio.InnerHtml = "Operazione non effettuata";
        }
    }
}