using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Text;


namespace Philinternational.Layers
{
    public class AssignLotto
    {
        private const String _assegnaLottoVincente = "assegnato";
        private const String _assegnaLottoNonVincente = "non assegnato";
        private const String _lottoFuoriAsta = "fuori asta";
        public static int aggiudicaLottoVincente(int idOfferta,string idLotto, int idAnagrafica){
            int esitoLotto = -1;
            String sql = "UPDATE offerta_per_corrispondenza SET assegnazione ='" + _assegnaLottoVincente +"' WHERE idofferta = "+ idOfferta;
            int esito = ConnectionGateway.ExecuteQuery(sql, "offerta_per_corrispondenza");
            if (esito == 0) {
                //spedisci mail al vincitore
                String persona = AccountGateway.GetPersonaFromIdAnagrafica(idAnagrafica);
                String idAsta = AsteGateway.GetNumAstaAttiva();
                String email = Layers.AccountGateway.GetEmailByIdAnagrafica(idAnagrafica);
                String a = Layers.MailList.lottoAggiudicato(persona,email, idLotto,idAsta);
                //annulla tutte le altre offerta
                Boolean esitoNonVincente = segnaOffertaNonVincente(idLotto);
                if (!esitoNonVincente) esitoLotto = -2; else esitoLotto = 0;
            }
            return esitoLotto;


        }
        private static Boolean segnaOffertaNonVincente(String idLotto) {
            Boolean esitoLotto = false;
            String sql = "UPDATE offerta_per_corrispondenza SET assegnazione ='" + _assegnaLottoNonVincente + "' WHERE idlotto = " + idLotto + " AND assegnazione ='' ";
            int esito = ConnectionGateway.ExecuteQuery(sql, "offerta_per_corrispondenza");
            if(esito==0) esitoLotto=true;
            return esitoLotto;
        
        }

        private static Boolean segnaOffertaFuoriAsta(String idLotto)
        {
            Boolean esitoLotto = false;
            String sql = "UPDATE offerta_per_corrispondenza SET assegnazione ='" + _lottoFuoriAsta + "' WHERE idlotto = " + idLotto + "";
            int esito = ConnectionGateway.ExecuteQuery(sql, "offerta_per_corrispondenza");
            if (esito == 0) esitoLotto = true;
            return esitoLotto;

        }
        public static void checkStatoOfferta(String idOfferta) { }

        public static String getAssegnaLottoVincente() { return _assegnaLottoVincente; }
        public static String getAssegnaLottoNonVincente() { return _assegnaLottoNonVincente; }
        public static String getLottoFuoriAsta() { return _lottoFuoriAsta; }
        
    }
}