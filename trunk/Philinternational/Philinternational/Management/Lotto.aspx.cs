using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Philinternational.Management
{
    public partial class Lotto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibtnPubblicaLottiSelezionati_Click(object sender, ImageClickEventArgs e) {
            //Muove la riga dalla tabella lotti_tmp alla tabella lotti e mette lo stato (su quest'ultima) in disattivo
        }

        protected void ibtnAttivaSelezionati_Click(object sender, ImageClickEventArgs e) {
            //Update su db dei lotti selezionati da attivare
        }

        protected void ibtnDisattivaSelezionati_Click(object sender, ImageClickEventArgs e) {
            //Update su db dei lotti selezionati da sospendere
        }

        protected void ibtnCercaLotto_Click(object sender, ImageClickEventArgs e) {
            //Filtro sulla dataview e rebind della gridview
        }
    }
}