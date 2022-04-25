using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services
{
    public class Session
    {
        private static Session SESSION;
        private Session() { }
        public Session getInstance()
        {
            if (SESSION == null)
            {
                SESSION = new Session();
            }
            return SESSION;
        }
        private IUser user { get;  set; }
        public void setUser(IUser pUser)
        {
            this.user = pUser;
        }

    }
}
