using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Philinternational {
    public class lottoEntity {
        public Int32 id;
        public Int32 id_argomento;
        public Int32 id_subargomento;
        public String conferente;
        public String anno;
        public String tipo_lotto;
        public Int32 numero_pezzi;
        public String descrizione;
        public Double prezzo_base;
        public String euro;
        public String riferimento_sassone;
        public Stato state;
    }
}