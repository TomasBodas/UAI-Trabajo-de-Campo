using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.DAL;
using UAICampo.Services;
using Microsoft.VisualBasic;

namespace UAICampo.BLL
{
    public class BLL_SessionManager
    {
        public void Login(String userName, string password )
        { 
            DAL_User dalUser = new DAL_User();
            IUser user = null;

            //Retrieves user from database
            user = dalUser.findByUsername(userName);

            if (user != null)
            {
                SessionManager sessionManager = new SessionManager();
                if (dalUser.userPasswordMatcher(user.Id, password))
                {
                    sessionManager.login(user);
                }
                else
                {
                    Interaction.MsgBox("Username/Password incorrect. Please try again.");
                }
            }
            else
            {
                Interaction.MsgBox("Login error. Please try again.");
            }
        }
    }
}
