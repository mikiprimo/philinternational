using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Philinternational.Management {
    public partial class offertaGilardiFilateliaDetail : System.Web.UI.Page {
        public String Codice {
            get { return ((String)ViewState["operationCode"]); }
            set { ViewState.Add("operationCode", value); }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                String codice = Request["cod"];
                if ((codice == null) || (codice == "-1")) codice = "-1";
                this.Codice = codice;

                if (this.Codice != "-1") {
                    GilardiFilateliaEntity myNews = GilardiFilateliaGateway.GetLottoById(codice);
                    lblDataPubblicazione.Text = myNews.dataInserimento.ToString("dd/MM/yyyy");
                    txtLotto.Text = myNews.idLotto.ToString();
                    txtPrezzo.Text = myNews.prezzo.ToString();
                    txtTesto.Text = myNews.descrizione.ToString();
                    txtAnno.Text = myNews.anno.ToString();
                    chkStato.Checked = Commons.GetCheckedState(myNews.state.id);
                }
            }
        }

        public void conferma(object sender, EventArgs e) {

        }

        private void ExamineResults(Boolean esito) {
            if (esito) ErrorUploadFile.InnerHtml = "Operazione effettuato con successo.";
            else ErrorUploadFile.InnerHtml = "Operazione non effettuata";
        }

        protected void ibtnConferma_Click(object sender, ImageClickEventArgs e) {
            ErrorUploadFile.InnerHtml = "";
            bool esito = false;
            if (uploadLotto.PostedFile != null && uploadLotto.PostedFile.ContentLength > 0) {
                string fn = System.IO.Path.GetFileName(uploadLotto.PostedFile.FileName);
                GilardiFilateliaEntity myEntity = new GilardiFilateliaEntity();
                string SaveLocation = Server.MapPath("..\\images\\gilardifilatelia\\") + fn;
                string SaveLocationThumb = Server.MapPath("..\\images\\gilardifilatelia\\thumb\\") + fn;
                //resize image
                ImageResize imageResize = new ImageResize();
                System.Drawing.Image imgPhoto = null;
                System.Drawing.Image imgPhotoOrig = System.Drawing.Image.FromFile(SaveLocation);
                imgPhoto = imageResize.ConstrainProportions(imgPhotoOrig, 100, ImageResize.Dimensions.Width);
                imgPhoto.Save(SaveLocationThumb, ImageFormat.Jpeg);
                imgPhoto.Dispose();
                try {
                    if (this.Codice == "-1") {
                        myEntity.idOfferta = Layers.ConnectionGateway.CreateNewIndex("idofferta", "offerta_gilardifilatelia");
                        myEntity.idLotto = Int32.Parse(txtLotto.Text);
                        myEntity.dataInserimento = DateTime.Now;
                        myEntity.descrizione = txtTesto.Text.ToString();
                        myEntity.anno = txtAnno.Text.ToString();
                        myEntity.prezzo = float.Parse(txtPrezzo.Text);
                        myEntity.state = new Stato(Commons.GetCheckedState(chkStato.Checked), "");

                        esito = GilardiFilateliaGateway.InsertRow(myEntity);
                    } else {
                        myEntity.idOfferta = Convert.ToInt32(this.Codice);
                        myEntity.idLotto = Int32.Parse(txtLotto.Text);
                        myEntity.dataInserimento = DateTime.Now;
                        myEntity.descrizione = txtTesto.Text.ToString();
                        myEntity.anno = txtAnno.Text.ToString();
                        myEntity.prezzo = float.Parse(txtPrezzo.Text);
                        myEntity.state = new Stato(Commons.GetCheckedState(chkStato.Checked), "");
                        esito = GilardiFilateliaGateway.UpdateRow(myEntity);
                    }
                    if (esito) {
                        uploadLotto.PostedFile.SaveAs(SaveLocation);
                    }

                    ExamineResults(esito);

                } catch (Exception ex) {
                    Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            } else {
                ErrorUploadFile.InnerHtml = "File non caricato";
            }
        }

        protected void ibtnReset_Click(object sender, ImageClickEventArgs e) {
            txtLotto.Text = "";
            txtAnno.Text = "";
            txtPrezzo.Text = "";
            txtTesto.Text = "";
        }

        protected void ibntTornaIndietro_Click(object sender, ImageClickEventArgs e) {
            Response.Redirect("~/Management/offertaGilardiFilatelia.aspx");
        }
    }
}