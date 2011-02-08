using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace Philinternational.Layers
{ 
    public class OfferteGateway
    {
        public String InsertOfferta(int idAnagrafica,String idLotto,float offerta) {
            String esito = "";
            Int32 idOfferta = ConnectionGateway.CreateNewIndex("idofferta", "offerta_per_corrispondenza");

            String data_inserimento = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            
            String sql = "INSERT INTO offerta_per_corrispondenza(idofferta,idlotto,idanagrafica,prezzo_offerto,data_inserimento) VALUES ";
            sql += "("+ idOfferta+","+ idLotto+","+ idAnagrafica+","+ offerta+",'"+ data_inserimento +"')";
            
            int a = ConnectionGateway.ExecuteQuery(sql, "offerta_per_corrispondenza");
            if (a == 0)
            {
                AsteGateway Asta = new AsteGateway();
                String[] esitoAsta = new String[2];
                esitoAsta = Asta.getDatiAsta();
                Boolean esitoMovimento = insertMovimento(idAnagrafica, esitoAsta.GetValue(0).ToString());
                if (esitoMovimento == false) esito = "KO";
            }
            else {
                esito = "KO";
            }
            return esito;
        }
        public Boolean checkOffertaGiaPresente(int IdAnagrafica, String idLotto) {

            String sql = "SELECT idlotto, idanagrafica FROM offerta_per_corrispondenza WHERE idlotto="+ idLotto+" AND idanagrafica="+ IdAnagrafica+"";
            MySqlDataReader dr = ConnectionGateway.SelectQuery(sql);
            if (!(dr == null))
            {
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        
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
            String sqlCheck = "SELECT idanagrafica,numero_asta from anagrafica_movimenti where idanagrafica= "+ idAnagrafica +" and numero_asta="+ idAsta +"";
            String sqlInsert ="INSERT INTO anagrafica_movimenti(idanagrafica,numero_asta) VALUES("+ idAnagrafica +","+ idAsta+")";

            MySqlDataReader dr = ConnectionGateway.SelectQuery(sqlCheck);
            if (!(dr == null))
            {
                if (dr.HasRows)
                {
                    return true;
                }
                else {
                    int a = ConnectionGateway.ExecuteQuery(sqlInsert, "anagrafica_movimenti");
                    if (a == 0)
                    {
                        return true;
                    }
                    else { return false; }

                }
            }else{
                return false;
            }
        }
        public Boolean insertCarrello(String idAnagrafica, string idLotto) {
            Int32 idcarrello = ConnectionGateway.CreateNewIndex("idcarrello", "carrello");
            String data_inserimento = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            String sqlCheck = "SELECT idanagrafica,idlotto from carrello where idanagrafica='" + idAnagrafica + "' AND idlotto=" + idLotto + "";
            String sqlInsert = "INSERT INTO carrello( idcarrello,idanagrafica,idlotto,data_inserimento) VALUES(" + idcarrello + ",'" + idAnagrafica + "'," + idLotto + ",'"+ data_inserimento+"')";

            MySqlDataReader dr = ConnectionGateway.SelectQuery(sqlCheck);
            if (!(dr == null))
            {
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    int a = ConnectionGateway.ExecuteQuery(sqlInsert, "carrello");
                    if (a == 0)
                    {
                        return true;
                    }
                    else { return false; }

                }
            }
            else
            {
                return false;
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

            String sql = "SELECT idlotto, idanagrafica FROM carrello WHERE idlotto=" + idLotto + " AND idanagrafica='" + idAnagrafica + "'";
            MySqlDataReader dr = ConnectionGateway.SelectQuery(sql);
            if (!(dr == null))
            {
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        
        }
    }
}