using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private User user { get;  set; }
        public void setUser(User pUser)
        {
            this.user = pUser;
        }

    }
}
