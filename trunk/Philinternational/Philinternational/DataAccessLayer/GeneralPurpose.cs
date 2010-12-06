﻿using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Philinternational.Gateway
{
    public partial class AccountFacilities
    {
        public static logInfos GetUserInfos(string userName, string password)
        {
            logInfos myLogInfos = new logInfos();
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["PhilinternationalConnectionString"].ToString();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand command = new MySqlCommand(ConfigurationManager.AppSettings["UserInfos"].ToString(),conn);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("email", userName);
                command.Parameters.AddWithValue("password", password);
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    myLogInfos.UserName = (String)dr["email"];
                    myLogInfos.Password = (String)dr["password"];

                    myLogInfos.idAnagrafica = (int)dr["idanagrafica"];
                    myLogInfos.nome = (String)dr["nome"];
                    myLogInfos.cognome = (String)dr["cognome"];
                    myLogInfos.codicefiscale = dr["codice_fiscale"] != null ? dr["codice_fiscale"].ToString() : "";
                    myLogInfos.via = (String)dr["via"];
                    myLogInfos.indirizzo = (String)dr["indirizzo"];
                    myLogInfos.numcivico = (String)dr["num_civico"];
                    myLogInfos.cap = (String)dr["cap"];
                    myLogInfos.comune = (String)dr["comune"];
                    myLogInfos.provincia = (String)dr["provincia"];
                    myLogInfos.email = (String)dr["email"];
                    myLogInfos.stato = (int)dr["stato"];
                    myLogInfos.idprofilo = (int)dr["idprofilo"];
                    myLogInfos.datainserimento = (DateTime)dr["data_inserimento"];
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return new logInfos();
            }

            return myLogInfos;
        }
    }
}