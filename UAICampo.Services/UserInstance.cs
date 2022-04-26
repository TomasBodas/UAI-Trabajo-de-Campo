using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services
{
    public class UserInstance
    {
        private static UserInstance LOGGED_USER;
        public IUser user;
        private UserInstance()
        {

        }

        public static UserInstance getInstance()
        {
            if (LOGGED_USER == null)
            {
                LOGGED_USER = new UserInstance();
            }
            return LOGGED_USER;
        }
        public bool userIsLoggedIn()
        {
            if (this.user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
