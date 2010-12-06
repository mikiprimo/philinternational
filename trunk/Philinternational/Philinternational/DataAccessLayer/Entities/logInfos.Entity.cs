using System;
using System.Collections.Generic;
using System.Web;

namespace Philinternational
{
    public class logInfos
    {
        String userName;
        String password;
        Boolean isAdmin;

        public Boolean IsAdmin
        {
            get { return isAdmin; }
        }

        public logInfos(String newUser, String newPassword, Boolean isAdmin)
        {
            this.userName = newUser;
            this.password = newPassword;
            this.isAdmin = isAdmin;
        }
    }
}