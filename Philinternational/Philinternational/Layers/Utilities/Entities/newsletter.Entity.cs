using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Philinternational {
    [Serializable]
    public class NewsletterEntity {
        public Int32 id;
        public DateTime data_creazione;
        public String titolo;
        public String testo;
    }
}