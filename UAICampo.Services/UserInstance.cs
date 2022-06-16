using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.Services.Observer;

namespace UAICampo.Services
{
    public class UserInstance
    {
        private static UserInstance LOGGED_USER;
        public User user;
        private static object sync = new Object();

        public static UserInstance getInstance()
        {
            lock (sync)
            {
                if (LOGGED_USER == null)
                {
                    LOGGED_USER = new UserInstance();
                }
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
