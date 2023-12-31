﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.DAL;
using UAICampo.Services;
using Microsoft.VisualBasic;
using UAICampo.DAL.SQL;
using UAICampo.Services.Composite;

namespace UAICampo.BLL
{
    public class BLL_SessionManager
    {
        public void Login(String userName, string password )
        { 
            //SQL Connection
            DAL_User_SQL dalUser = new DAL_User_SQL();
            DAL_Profile_SQL dalProfile = new DAL_Profile_SQL();
            DAL_Language_SQL dalLanguages = new DAL_Language_SQL();
            DAL_Licences_SQL dalLicenses = new DAL_Licences_SQL();

            BLL_Licences bllLicenses = new BLL_Licences();

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

                    //License
                    user.Licenses = dalLicenses.getUserLicence(user);
                    //Recursive licenses
                    bllLicenses.getUserLicences(user);

                    //Get user selected language
                    user.language = dalLanguages.getUserLanguage(user);


                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "LOGIN_OK",
                        Description = String.Format("Account {0} logged successfully", user.Username),
                        Type = LogType.Control,
                        User = user.Id
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
                            User = user.Id
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
                    User = user.Id
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
                User = user.Id
            });
            sm.logout();
            return true;
        }
    }
}
