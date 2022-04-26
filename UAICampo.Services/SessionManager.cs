using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services
{
    public class SessionManager 
    {
        public void login(IUser pUser)
        {
            if (!UserInstance.getInstance().userIsLoggedIn())
            {
                UserInstance.getInstance().user = pUser;
            }
            else 
            {
                //error Ya tenemos un usuario loggeado
            }
        }
        public void logout()
        {
            if (UserInstance.getInstance().userIsLoggedIn())
            {
                UserInstance.getInstance().user = null;
            }
            else
            {
                //error No te podes desloggear potrque no hay usuario loggeado actualmente.
            }
        }
    }
}
