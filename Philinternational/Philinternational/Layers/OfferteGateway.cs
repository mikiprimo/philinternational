using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;


namespace Philinternational.Layers
{ 
    public class OfferteGateway
    {
        public String InsertOfferta(int idAnagrafica,String idLotto,float offerta) {
            String esito = "";
            Int32 idOfferta = ConnectionGateway.CreateNewIndex("idofferta", "offerta_per_corrispondenza");

            String data_inserimento = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

            AsteGateway myAsta = new AsteGateway();
            Boolean astaAttiva = myAsta.GetAstaAttiva();
            String assegnazione ="";
            if (!astaAttiva) assegnazione = "fuori asta";

            String sql = "INSERT INTO offerta_per_corrispondenza(idofferta,idlotto,idanagrafica,prezzo_offerto,data_inserimento,assegnazione) VALUES ";
            sql += "(" + idOfferta + "," + idLotto + "," + idAnagrafica + "," + offerta + ",'" + data_inserimento + "','" + assegnazione + "')";
            
            int a = ConnectionGateway.ExecuteQuery(sql, "offerta_per_corrispondenza");
            if (a == 0)
            {
                if (astaAttiva)
                {
                    String[] esitoAsta = new String[2];
                    esitoAsta = myAsta.GetDatiAsta();
                    String eMail = AccountGateway.GetEmailByIdAnagrafica(idAnagrafica);
                    String userName = AccountGateway.GetPersonaFromIdAnagrafica(idAnagrafica);
                    String esitoOfferta = MailList.SendOffertaToUser(userName, eMail, idLotto, offerta.ToString(), esitoAsta.GetValue(0).ToString());
                    String esitoAdmin = MailList.AvvisoOffertaAdmin(userName, idLotto, offerta.ToString());
                    Boolean esitoMovimento = insertMovimento(idAnagrafica, esitoAsta.GetValue(0).ToString());
                    if (esitoMovimento == false) esito = "Offerta non effettuata";
                }
                else {
                    String eMail = AccountGateway.GetEmailByIdAnagrafica(idAnagrafica);
                    String userName = AccountGateway.GetPersonaFromIdAnagrafica(idAnagrafica);
                    String esitoOfferta = MailList.SendOffertaNoAstaToUser(userName, eMail, idLotto);
                    String esitoAdmin = MailList.AvvisoAcquistoLottoNoAstaAdmin(userName, idLotto, offerta.ToString());
                    Boolean esitoMovimento = insertMovimento(idAnagrafica, "EXT");
                    if (esitoMovimento == false) esito = "Offerta non effettuata";                
                }
            }
            else {
                esito = "Offerta non effettuata";
            }
            return esito;
        }
        public Boolean checkOffertaGiaPresente(String IdAnagrafica, String idLotto) {

            String sql = "SELECT idlotto, idanagrafica FROM offerta_per_corrispondenza WHERE idlotto="+ idLotto+" AND idanagrafica='"+ IdAnagrafica+"'";
            DataView dr = ConnectionGateway.SelectQuery(sql);
            if (dr.Count > 0)
                return true;
            else return false;
        }
        public String checkOffertaGiaAssegnata(String idOfferta)
        {
            String a = "";
            String sql = "SELECT assegnazione FROM offerta_per_corrispondenza WHERE idofferta=" + idOfferta + "";
            DataView dr = ConnectionGateway.SelectQuery(sql);
            if (dr.Count > 0){
                a = dr[0]["assegnazione"].ToString();
            }
            return a;
            
        }
        public Boolean DeleteOfferta(int idOfferta) {
            String sql = "DELETE FROM offerta_per_corrispondenza where idofferta =" + idOfferta;
            int a = ConnectionGateway.ExecuteQuery(sql, "offerta_per_corrispondenza");
            if (a == 0) return true; else return false;
        
        }
        public Boolean DelleteAllOfferte()
        {
            String sql = "DELETE FROM offerta_per_corrispondenza";
            int a = ConnectionGateway.ExecuteQuery(sql, "offerta_per_corrispondenza");
            if (a == 0) return true; else return false;
        }
        private Boolean insertMovimento(int idAnagrafica, String idAsta) {
            String data_inserimento = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            String sqlCheck = "SELECT idanagrafica,numero_asta from anagrafica_movimenti where idanagrafica= "+ idAnagrafica +" and numero_asta='"+ idAsta +"'";
            String sqlInsert = "INSERT INTO anagrafica_movimenti(idanagrafica,numero_asta,data_inserimento) VALUES(" + idAnagrafica + ",'" + idAsta + "','" + data_inserimento + "')";

            DataView dr = Layers.ConnectionGateway.SelectQuery(sqlCheck);
            if (dr.Count > 0)
            {
                return true;
            }
            else {
                int a = ConnectionGateway.ExecuteQuery(sqlInsert, "anagrafica_movimenti");
                if (a == 0) return true; else  return false;
            }
        }
        public Boolean insertCarrello(String idAnagrafica, string idLotto) {
            Int32 idcarrello = ConnectionGateway.CreateNewIndex("idcarrello", "carrello");
            String data_inserimento = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            String sqlCheck = "SELECT idanagrafica,idlotto from carrello where idanagrafica='" + idAnagrafica + "' AND idlotto=" + idLotto + "";
            String sqlInsert = "INSERT INTO carrello( idcarrello,idanagrafica,idlotto,data_inserimento) VALUES(" + idcarrello + ",'" + idAnagrafica + "'," + idLotto + ",'"+ data_inserimento+"')";

            DataView dr = Layers.ConnectionGateway.SelectQuery(sqlCheck);
            if (dr.Count > 0)
            {
                return true;
            }
            else {
                int a = ConnectionGateway.ExecuteQuery(sqlInsert, "carrello");
                if (a == 0)
                {
                    return true;
                }
                else { return false; }            
            }

        }
        public Boolean DeleteCarrelloByIdCarrello(int idcarrello)
        {
            String sql = "DELETE FROM carrello where idcarrello =" + idcarrello;
            int a = ConnectionGateway.ExecuteQuery(sql, "carrello");
            if (a == 0) return true; else return false;
        }
        public Boolean DeleteCarrelloByIdAnagrafica(String idAnagrafica)
        {
            String sql = "DELETE FROM carrello where idanagrafica ='" + idAnagrafica + "'";
            int a = ConnectionGateway.ExecuteQuery(sql, "carrello");
            if (a == 0) return true; else return false;
        }
        public Boolean UpdateCarrello(String idAnagraficaOld,String idanagraficaNew)
        {
            String sql = "UPDATE carrello SET idanagrafica ='"+ idanagraficaNew+"' WHERE idanagrafica ='"+ idAnagraficaOld+"'";
            int a = ConnectionGateway.ExecuteQuery(sql, "carrello");
            if (a == 0) return true; else return false;
        }
        public String loadSingleLotto() { return ""; }
        public Boolean CheckLottoCarrello(String idAnagrafica, string idLotto)
        {
            Boolean esito = false;
            String sql = "SELECT idlotto, idanagrafica FROM carrello WHERE idlotto=" + idLotto + " AND idanagrafica='" + idAnagrafica + "'";

            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            if (dr.Count>0) esito=true;
            return esito;
        
        }
        public Boolean CheckLottiBySelect(String idAnagrafica) {
            Boolean esito = false;
            String sql = "SELECT count(*) conteggio  FROM carrello a, lotto b where a.idlotto =  b.idlotto AND b.idlotto not in (select c.idlotto from offerta_per_corrispondenza c where a.idanagrafica = a.idanagrafica) and a.idanagrafica ='" + idAnagrafica + "'";

            DataView dr = Layers.ConnectionGateway.SelectQuery(sql);
            if (dr.Count > 0) {
                int a = Int32.Parse(dr[0]["conteggio"].ToString());
                if (a > 0) esito = true;
            } 
            return esito;

        
        }
    }
}