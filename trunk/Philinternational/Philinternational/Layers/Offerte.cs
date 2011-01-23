using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace Philinternational.Layers
{
    public class Offerte
    {
        public  String InsertOfferta(String idAnagrafica,String idLotto,float offerta) {
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
        public  Boolean checkOffertaGiaPresente(String IdAnagrafica, String idLotto) {

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
        public  Boolean DeleteOfferta(String idOfferta) { return false; }
        public  Boolean DelleteAllOfferte() { return false; }
        private Boolean insertMovimento(String idAnagrafica, String idAsta) {
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
         
    }
}