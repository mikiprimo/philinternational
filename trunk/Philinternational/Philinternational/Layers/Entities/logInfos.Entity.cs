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

        private String _RoleDescription;
        public String RoleDescription
        {
            get { return _RoleDescription; }
            set
            {
                _RoleDescription = value;
                if (value == "Amministratore" || value == "webmaster")
                {
                    this._IsAdmin = true;
                }
                else this._IsAdmin = false;
                this._IsAuthenticated = true;
            }
        }

        private int _Role;
        public int Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        private Boolean _IsAdmin = false;
        public Boolean IsAdmin
        {
            get { return this._IsAdmin; }
        }

        private Boolean _IsAuthenticated = false;
        public bool IsAuthenticated
        {
            get { return this._IsAuthenticated; }
        }
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

        public logInfos(String newUser, String newPassword)
        {
            this.userName = newUser;
            this.password = newPassword;
        }

        public logInfos()
        {
            this._IsAdmin = false;
            this._IsAuthenticated = false;
        }
    }
}