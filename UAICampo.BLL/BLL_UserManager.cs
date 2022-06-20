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
using UAICampo.BE;

namespace UAICampo.BLL
{
    public class BLL_UserManager
    {
        //SQL Connection
        DAL_User_SQL dal_user = new DAL_User_SQL();
        DAL_Profile_SQL dal_profile = new DAL_Profile_SQL();
        DAL_Language_SQL dal_language = new DAL_Language_SQL();

        string DEFAULT_PACIENT_PROFILE_NAME = "Pacient";
        string DEFAULT_PRACTICIONER_PROFILE_NAME = "Practitioner";

        public IUser createUser(string username, string password, string email, string name, string lastName, DateTime birthdate, int dni)
        {
            //Instantiate new user to be saved
            User user = new User(username, password, email, name, lastName, birthdate, dni);

            //Default user profile data set.
            //Language  --> English
            int DEFAULT_LANGUAGE_ID = 1;
            

            if (dal_user.findByUsername(username) == null)
            {
                try
                {
                    //if user is successfully created, it will return an instance of the user
                    user = dal_user.Save(user);

                    //Then we search for the newly created user again, to retrieve the ID
                    user = dal_user.findByUsername(user.Username);

                    //Then, to the newly created account, we add de "Pacient" profile.
                    dal_profile.addAccountProfile(findProfileByName(DEFAULT_PACIENT_PROFILE_NAME).ProfileId, user);

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
        public List<Profile> getUserProfile(User user)
        {
            return dal_profile.getUserProfiles(user.Id);
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
        public Profile findProfileByName(string profileName)
        {
            return dal_profile.findProfileByName(profileName);
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
        public bool setProfileLicense(Profile profile, Component license)
        {
            return dal_profile.addProfileLicense(profile, license);
        }
        public bool revokeProfileLicense(Profile profile, Component license)
        {
            return dal_profile.revokeProfileLicense(profile, license);
        }
        public bool createProfile(string profileName, string profileDesc)
        {
            return dal_profile.createProfile(profileName, profileDesc);
        }
        public bool deleteProfile(Profile profile)
        {
            return dal_profile.deleteProfile(profile);
        }
        public bool changePassword(User user, string password)
        {
            return dal_user.changePassword(user, password);
        }
        public bool promoteAccount(int number, User user)
        {
            bool success = false;

            if (dal_profile.promoteAccount(number,
                                                UserInstance.getInstance().user,
                                                dal_profile.findProfileByName(DEFAULT_PRACTICIONER_PROFILE_NAME)))
            {
                UserInstance.getInstance().user.profileList.Add(findProfileByName(DEFAULT_PRACTICIONER_PROFILE_NAME));
                success = true;
            }
            return success;
        }

        public List<Speciality> getAllSpecialities()
        {
            return dal_user.getAllSpecialities();
        }
        public bool addSpeciality(Speciality speciality, User user)
        {
            return dal_profile.addSpeciality(speciality, user);
        }
        public List<Procedure> loadProcedures(User user)
        {
            return dal_user.loadProcedures(user);
        }
        public bool addProcedure(Procedure procedure, User user)
        {
            return dal_user.addProcedure(procedure, user);
        }
        public bool removeProcedure(Procedure procedure)
        {
            return dal_user.removeProcedure(procedure);
        }
        public List<User> searchPractitionerResults(Speciality speciality, Province province)
        {
            return dal_user.searchPractitionerResults(speciality, province);
        }
        public List<Appointment> getAppointments(User user)
        {
            return dal_user.getAppointmentsPractitioner(user);
        }
        public bool confirmTurn(Appointment appointment)
        {
            return dal_user.confirmTurn(appointment);
        }
    }
}
