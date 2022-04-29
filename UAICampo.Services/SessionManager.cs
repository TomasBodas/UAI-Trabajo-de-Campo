using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using Microsoft.VisualBasic;

namespace UAICampo.Services
{
    public class SessionManager 
    {
        public void login(User pUser)
        {
            if (!UserInstance.getInstance().userIsLoggedIn())
            {
                UserInstance.getInstance().user = pUser;
            }
            else 
            {
                Interaction.MsgBox("User already logged in.");
            }
        }
        public void logout()
        {
            if (UserInstance.getInstance().userIsLoggedIn())
            {
                UserInstance.getInstance().user = null;
            }
        }
    }
}
