using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Philinternational.Layers;

namespace Philinternational
{
    public partial class offerta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack) {
                String chiave = Request["cod"];
                String codargomento = Request["arg"];
                String subargomento = Request["subarg"];
                loadData(chiave);

            }


        }
        private void loadData(String idlotto) {

            LoadImmagineOutput.InnerHtml = loadImmagine(idlotto);
        }
        private void FaiOfferta() { }

        private String loadImmagine(Object idLotto)
        {
            LottiGateway a = new LottiGateway();
            String chiave = idLotto.ToString();
            String outputImmagine = a.LoadImageByLotto(Page.ResolveClientUrl("~/images/asta/"), Page.ResolveClientUrl("~/images/immagine_non_disponibile.jpg"), chiave);

            return outputImmagine;
        }
    }
}