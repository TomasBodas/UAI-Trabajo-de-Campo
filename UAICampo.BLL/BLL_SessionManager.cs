using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.DAL;
using UAICampo.Services;
using Microsoft.VisualBasic;
using UAICampo.DAL.SQL;

namespace UAICampo.BLL
{
    public class BLL_SessionManager
    {
        public void Login(String userName, string password )
        { 

            //DAL_User dalUser = new DAL_User();
            DAL_User_SQL dalUser = new DAL_User_SQL();

            User user = null;

            //Retrieves user from database
            user = dalUser.findByUsername(userName);

            if (user != null)
            {
                SessionManager sessionManager = new SessionManager();
                if (dalUser.userPasswordMatcher(user.Id, password) && !user.IsBlocked )
                {
                    //Singleton setup
                    sessionManager.login(user);
                    user.Attempts = 0;
                    dalUser.UpdateUserStatus(user);
                }
                else
                {
                    //User status handling
                    if (user.Attempts == 3)
                    {
                        user.IsBlocked = true;
                        Interaction.MsgBox("Account blocked due to repeated attempts.");
                    }
                    else
                    {
                        user.Attempts++;
                        Interaction.MsgBox("Username/Password incorrect. Please try again.");
                    }

                    //update user status
                    dalUser.UpdateUserStatus(user);
                }
            }
            else
            {
                Interaction.MsgBox("Login error. Please try again.");
            }
        }

        public bool Logout()
        {
            SessionManager sm = new SessionManager();
            sm.logout();
            return true;
        }
    }
}
