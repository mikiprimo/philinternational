using System;
using System.Collections.Generic;
using System.Web;

namespace Philinternational
{
    public class GilardiFilateliaEntity
    {
        public int idOfferta;
        public int idLotto;
        public DateTime dataInserimento;
        public String anno;
        public String descrizione;
        public float prezzo;
        public Stato state;

    }
}