using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

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
            lottoEntity lotto = new lottoEntity();
            switch (this.currentType) {
                case "pub": lotto = LottiGateway.SelectLotti(Convert.ToInt32(idlotto)); break;
                case "tmp": lotto = LottiGateway.SelectLottiTemporanei(Convert.ToInt32(idlotto)); break;
            }
        }

        protected void ibtnUpdateLotto_Click(object sender, ImageClickEventArgs e) {
            lottoEntity newLotto = new lottoEntity();

            //... Populate lotto

            switch (this.currentType) {
                case "pub": LottiGateway.UpdateLotti(newLotto); break;
                case "tmp": LottiGateway.UpdateLottiTemporanei(newLotto); break;
            }
        }
    }
}