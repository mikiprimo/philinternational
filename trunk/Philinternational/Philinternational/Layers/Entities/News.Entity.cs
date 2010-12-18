using System;
using System.Collections.Generic;
using System.Web;

namespace Philinternational
{
    public class NewsEntity
    {
        public int id;
        public DateTime dataPubblicazione;
        public String titolo, testo;
        public Stato state;
    }
}