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

            //XML Dal Connection
            //DAL_User dalUser = new DAL_User();

            //SQL Connection
            DAL_User_SQL dalUser = new DAL_User_SQL();
            DAL_Profile_SQL dalProfile = new DAL_Profile_SQL();
            DAL_Licences_SQL dalLicences = new DAL_Licences_SQL();

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

                    //Search for all user profiles.
                    user.profileList = dalProfile.getUserProfiles(user.Id);

                    //Retrieve composite pattern defined licences por each user profile
                    if (user.profileList.Count > 0)
                    {
                        foreach (Profile profile in user.profileList)
                        {
                            //User.licences = bll_Login.getLicenses(User.id)
                        }
                    }

                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "LOGIN_OK",
                        Description = String.Format("Account {0} logged successfully", user.Username),
                        Type = LogType.Control,
                        User = user
                    });
                }
                else
                {
                    //User status handling
                    if (user.Attempts == 3)
                    {
                        user.IsBlocked = true;
                        Interaction.MsgBox("Account blocked due to repeated attempts.");
                        BLL_LogManager.addMessage(new Log
                        {
                            Date = DateTime.Now,
                            Code = "BLOCKED",
                            Description = String.Format("Account {0} blocked due to repeated attempts.", user.Username),
                            Type = LogType.Warning,
                            User = user
                        });
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
                BLL_LogManager.addMessage(new Log
                {
                    Date = DateTime.Now,
                    Code = "LOGIN_ERROR",
                    Description = String.Format("Login error. Please try again."),
                    Type = LogType.Error,
                    User = user
                });
            }
        }

        public bool Logout()
        {
            User user = UserInstance.getInstance().user;
            SessionManager sm = new SessionManager();
            BLL_LogManager.addMessage(new Log
            {
                Date = DateTime.Now,
                Code = "LOGOUT",
                Description = String.Format("Account {0} logged out", user.Username),
                Type = LogType.Control,
                User = user
            });
            sm.logout();
            return true;
        }
    }
}
