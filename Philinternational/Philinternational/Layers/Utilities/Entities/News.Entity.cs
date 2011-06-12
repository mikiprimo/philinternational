using System;
using System.Collections.Generic;
using System.Web;

namespace Philinternational {
    public class newsEntity {
        public int id;
        public DateTime dataPubblicazione;
        public String titolo, testo;
        public Stato state;
    }
}