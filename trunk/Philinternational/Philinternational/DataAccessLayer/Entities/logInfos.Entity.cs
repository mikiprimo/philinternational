using System;
using System.Collections.Generic;
using System.Web;

namespace Philinternational
{
    public class logInfos
    {
        String userName;
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        String password;
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        Boolean isAdmin;
        Boolean isAuthenticated;
        public int idAnagrafica;
        public string nome;
        public string cognome;
        public string codicefiscale;
        public string via;
        public string indirizzo;
        public string numcivico;
        public string cap;
        public string comune;
        public string provincia;
        public string email;
        public int stato;
        public int idprofilo;
        public DateTime datainserimento;

        public Boolean IsAdmin
        {
            get { return this.isAdmin; }
            set { this.isAdmin = value; }
        }

        public bool IsAuthenticated
        {
            get { return this.isAuthenticated; }
            set { this.isAuthenticated = value; }
        }

        public logInfos(String newUser, String newPassword, Boolean isAdmin, Boolean isAuthenticated)
        {
            this.userName = newUser;
            this.password = newPassword;
            this.IsAdmin = isAdmin;
            this.IsAuthenticated = isAuthenticated;
        }

        public logInfos()
        {
            this.isAdmin = false;
            this.IsAuthenticated = false;
        }
    }
}