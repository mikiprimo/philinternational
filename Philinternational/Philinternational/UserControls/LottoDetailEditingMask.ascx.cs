using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;
using System.Data;

namespace Philinternational.UserControls {
    public partial class LottoDetailEditingMask : System.Web.UI.UserControl {

        public String currentIdLotto { get { return ((String)ViewState["currentIdLotto"]); } set { ViewState["currentIdLotto"] = value; } }

        public String currentType { get { return ((String)ViewState["currentType"]); } set { ViewState["currentEmail"] = value; } }

        protected void Page_Load(object sender, EventArgs e) {
            this.currentIdLotto = GeneralUtilities.GetQueryString(Request.QueryString, "id");
            this.currentType = GeneralUtilities.GetQueryString(Request.QueryString, "type");
            LoadFormData(this.currentIdLotto);
        }

        private void LoadFormData(String idlotto) {
            DataView lotto = new DataView();
            switch (this.currentType) {
                case "pub": lotto = LottiGateway.SelectLottiById(Convert.ToInt32(idlotto));
                    break;
                case "tmp": lotto = LottiGateway.SelectLottiTemporaneiById(Convert.ToInt32(idlotto));
                    break;
            }

            txtConferente.Text = lotto[0]["conferente"].ToString();
            txtConferente.Text = lotto[0]["anno"].ToString();
            txtConferente.Text = lotto[0]["tipo_lotto"].ToString();
            txtConferente.Text = lotto[0]["numero_pezzi"].ToString();
            txtConferente.Text = lotto[0]["descrizione"].ToString();
            txtConferente.Text = lotto[0]["prezzo_base"].ToString();
            txtConferente.Text = lotto[0]["euro"].ToString();
            txtConferente.Text = lotto[0]["riferimento_sassone"].ToString();
        }

        protected void ibtnUpdateLotto_Click(object sender, ImageClickEventArgs e) {
            lottoEntity updateLotto = new lottoEntity();

            updateLotto.conferente = txtConferente.Text;
            updateLotto.anno = txtAnno.Text;
            updateLotto.tipo_lotto = txtTipoLotto.Text;
            updateLotto.numero_pezzi = Convert.ToInt32(txtNumeroPezzi.Text);
            updateLotto.descrizione = txtDescrizione.Text;
            updateLotto.prezzo_base = Convert.ToInt32(txtPrezzoBase.Text);
            updateLotto.euro = txtEuro.Text;
            updateLotto.riferimento_sassone = txtRiferimentoSassone.Text;
            updateLotto.id = Convert.ToInt32(currentIdLotto);

            switch (this.currentType) {
                case "pub": LottiGateway.UpdateLotti(updateLotto); break;
                case "tmp": LottiGateway.UpdateLottiTemporanei(updateLotto); break;
            }
        }
    }
}