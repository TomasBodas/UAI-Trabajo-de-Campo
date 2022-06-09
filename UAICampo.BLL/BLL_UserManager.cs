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
    public class BLL_UserManager
    {
        public IUser createUser(string username, string password, string email)
        {
            //Instantiate new user to be saved
            User user = new User(username, password, email);

            //Default user profile data set.
            //Profile 2 --> Default
            //Language  --> English
            int DEFAULT_PROFILE_ID = 2;
            int DEFAULT_LANGUAGE_ID = 1;


            //SQL Connection
            DAL_User_SQL dal_user = new DAL_User_SQL();
            DAL_Profile_SQL dal_profile = new DAL_Profile_SQL();
            DAL_Language_SQL dal_language = new DAL_Language_SQL();

            if (dal_user.findByUsername(username) == null)
            {
                try
                {
                    //if user is successfully created, it will return an instance of the user
                    user = dal_user.Save(user);

                    //Then we search for the newly created user again, to retrieve the ID
                    user = dal_user.findByUsername(user.Username);

                    //Then we add a default user profile to the newly created account
                    dal_profile.addAccountProfile(DEFAULT_PROFILE_ID, user);

                    //Finally, we add the default language for the newly created user as English
                    user.language = dal_language.FindById(DEFAULT_LANGUAGE_ID);
                    dal_user.UpdateLanguage(user, user.language);

                }
                catch (Exception)
                { }
                

                BLL_LogManager.addMessage(new Log
                {
                    Date = DateTime.Now,
                    Code = "USER_CREATED",
                    Description = String.Format("Account {0} created successfully", user.Username),
                    Type = LogType.Control,
                    User = user
                });
            }
            else
            {
                //if user is not created it will return a null user
                user = null;

                BLL_LogManager.addMessage(new Log
                {
                    Date = DateTime.Now,
                    Code = "USERNAME_ERROR",
                    Description = String.Format("Username already exists"),
                    Type = LogType.Warning,
                    User = user
                });
            }

            return user;
        }
    }
}
