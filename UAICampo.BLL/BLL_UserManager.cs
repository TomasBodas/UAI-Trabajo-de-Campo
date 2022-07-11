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
using UAICampo.Services.Composite;

namespace UAICampo.BLL
{
    public class BLL_UserManager
    {
        //SQL Connection
       static  DAL_User_SQL dal_user = new DAL_User_SQL();
        static DAL_Profile_SQL dal_profile = new DAL_Profile_SQL();
        DAL_Language_SQL dal_language = new DAL_Language_SQL();

        public IUser createUser(string username, string password, string email)
        {
            //Instantiate new user to be saved
            User user = new User(username, password, email);

            //Default user profile data set.
            //Profile 2 --> Default
            //Language  --> English
            int DEFAULT_PROFILE_ID = 2;
            int DEFAULT_LANGUAGE_ID = 1;       

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

                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "USER_CREATED",
                        Description = String.Format("Account {0} created successfully", user.Username),
                        Type = LogType.Control,
                        User = user
                    });
                }
                catch (Exception)
                { }
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

        public bool BlockAccount(User user)
        {
            return dal_user.blockAccount(user);
        }
        public bool unblockAccount(User user)
        {
            return dal_user.unblockAccount(user);
        }
        public List<Profile> getUserProfiles(User user)
        {
            return dal_profile.getUserProfiles(user.Id);
        }
        public static List<IUser> getPositions(int teamId)
        {
            return dal_user.getPositions(teamId);
        }
        public static Profile getUserProfile(User user)
        {
            return dal_profile.getUserProfile(user.Id);
        }
        public Profile getProfileByName(string name)
        {
            return dal_profile.getProfileByName(name);
        }
        public static Profile getProfileById(int id)
        {
            return dal_profile.getProfileById(id);
        }
        public List<Profile> getNonAsignedProfileList(User user)
        {
            return dal_profile.getNonUserProfiles(user);
        }
        public bool AssignProfile(User user, Profile profile)
        {
            return dal_profile.AssignProfile(user, profile);
        }
        public bool RevokeProfile(User user, Profile profile)
        {
            return dal_profile.RevokeProfile(user, profile);
        }
        public List<Profile> getProfileList()
        {
            return dal_profile.getAllProfiles();
        }

        public List<Profile> getBusinessProfileList()
        {
            return dal_profile.getBusinessProfileList();
        }
        public List<User> GetUsers()
        {
            List<User> userList = dal_user.GetAll().ToList();
            List<User> fullDetailUserList = new List<User>();

            foreach (User user in userList)
            {
                fullDetailUserList.Add(dal_user.findByUsername(user.Username));
            }

            return fullDetailUserList;
        }
        public static User FindByUsername(string name)
        {
            return dal_user.findByUsername(name);
        }
        public static User FindById(int id)
        {
            return dal_user.FindById(id);
        }
        public bool setProfileLicense(Profile profile, Component license)
        {
            return dal_profile.addProfileLicense(profile, license);
        }
        public bool revokeProfileLicense(Profile profile, Component license)
        {
            return dal_profile.revokeProfileLicense(profile, license);
        }
        public bool createProfile(string profileName, string profileDesc, int value)
        {
            return dal_profile.createProfile(profileName, profileDesc, value);
        }
        public bool deleteProfile(Profile profile)
        {
            return dal_profile.deleteProfile(profile);
        }
        public bool changePassword(User user, string password)
        {
            return dal_user.changePassword(user, password);
        }
    }
}
