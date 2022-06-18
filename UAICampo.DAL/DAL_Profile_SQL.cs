using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UAICampo.Services;
using UAICampo.Services.Composite;

namespace UAICampo.DAL
{
    public class DAL_Profile_SQL : DAL_Abstract<User>
    {

        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        private const string TABLE_USER_PROFILE = "account_profile";
        private const string TABLE_PROFILE = "profile";
        private const string TABLE_PROFILE_LICENSE = "profile_license";
        private const string TABLE_MATRICULA = "Matriculas";


        private const string COLUMN_PROFILE_IDPROFILE = "id";
        private const string COLUMN_PROFILE_NAME = "name";
        private const string COLUMN_PROFILE_DESC = "description";
        private static readonly string PARAM_PROFILE_IDPROFILE = $"@{COLUMN_PROFILE_IDPROFILE}";
        private static readonly string PARAM_PROFILE_NAME = $"@{COLUMN_PROFILE_NAME}";
        private static readonly string PARAM_PROFILE_DESC = $"@{COLUMN_PROFILE_DESC}";


        private const string COLUMN_USER_PROFIL_IDPROFILE = "id_profile";
        private const string COLUMN_USER_PROFIL_IDUSER = "id_account";
        private static readonly string PARAM_USER_PROFIL_IDPROFILE = $"@{COLUMN_USER_PROFIL_IDPROFILE}";
        private static readonly string PARAM_USER_PROFIL_IDUSER = $"@{COLUMN_USER_PROFIL_IDUSER}";


        private const string COLUMN_PROFILE_LICENSE_idProfile = "id_profile";
        private const string COLUMN_PROFILE_LICENSE_idLicense = "id_license";
        private static readonly string PARAM_PROFILE_LICENSE_idProfile = $"@{COLUMN_PROFILE_LICENSE_idProfile}";
        private static readonly string PARAM_PROFILE_LICENSE_idLicense = $"@{COLUMN_PROFILE_LICENSE_idLicense}";

        private const string COLUMN_MATRICULA_MATRICULA = "Matricula";
        private static readonly string PARAM_MATRICULA_MATRICULA = $"@{COLUMN_MATRICULA_MATRICULA}";

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        public void addAccountProfile(int profileId, User Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_USER_PROFILE} ({COLUMN_USER_PROFIL_IDPROFILE}, {COLUMN_USER_PROFIL_IDUSER})" +
                                $" VALUES ({PARAM_USER_PROFIL_IDPROFILE}, {PARAM_USER_PROFIL_IDUSER})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_PROFIL_IDPROFILE, profileId);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_PROFIL_IDUSER, Entity.Id);
                    
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<Profile> getUserProfiles(int userId)
        {
            List<Profile> profileList = new List<Profile>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_PROFILE_IDPROFILE}, {COLUMN_PROFILE_NAME}, {COLUMN_PROFILE_DESC} " +
                                $" FROM {TABLE_PROFILE} " +
                                $" INNER JOIN {TABLE_USER_PROFILE} " +
                                $" ON {TABLE_USER_PROFILE}.{COLUMN_USER_PROFIL_IDPROFILE} = {TABLE_PROFILE}.{COLUMN_PROFILE_IDPROFILE}" +
                                $" WHERE {TABLE_USER_PROFILE}.{COLUMN_USER_PROFIL_IDUSER} = {userId}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {

                            profileList.Add( new Profile(new Object[] { sqlReader[0], sqlReader[1], sqlReader[2]}));
                        }
                    }

                    sqlReader.Close();
                }
            }

            return profileList;
        }

        public List<Profile> getNonUserProfiles(User user)
        {
            List<Profile> profileList = new List<Profile>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_PROFILE_IDPROFILE}, {COLUMN_PROFILE_NAME}, {COLUMN_PROFILE_DESC} " +
                                $" FROM {TABLE_PROFILE} " +
                                $" WHERE ({TABLE_PROFILE}.{COLUMN_PROFILE_IDPROFILE})" +
                                $" NOT IN (" +
                                $"      SELECT {TABLE_PROFILE}.{COLUMN_PROFILE_IDPROFILE}" +
                                $"      FROM {TABLE_PROFILE}" +
                                $"      INNER JOIN {TABLE_USER_PROFILE}" +
                                $"      ON {TABLE_USER_PROFILE}.{COLUMN_USER_PROFIL_IDPROFILE} = {TABLE_PROFILE}.{COLUMN_PROFILE_IDPROFILE}" +
                                $"      WHERE {TABLE_USER_PROFILE}.{COLUMN_USER_PROFIL_IDUSER} = {user.Id})";
                               

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {

                            profileList.Add(new Profile(new Object[] { sqlReader[0], sqlReader[1], sqlReader[2] }));
                        }
                    }

                    sqlReader.Close();
                }
            }

            return profileList;
        }
        public Profile findProfileByName(string profileName)
        {
            Profile profile = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_PROFILE_IDPROFILE}, {COLUMN_PROFILE_NAME}, {COLUMN_PROFILE_DESC} " +
                                $" FROM {TABLE_PROFILE} " +
                                $" WHERE {TABLE_PROFILE}.{COLUMN_PROFILE_NAME} = '{profileName}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {

                    
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {

                            profile = new Profile(new Object[] { sqlReader[0], sqlReader[1], sqlReader[2] });
                        }
                    }

                    sqlReader.Close();
                }
            }

            return profile;
        }
        public bool AssignProfile(User user, Profile profile)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_USER_PROFILE} ({COLUMN_USER_PROFIL_IDPROFILE}, {COLUMN_USER_PROFIL_IDUSER})" +
                                $" VALUES ( {profile.ProfileId}, {user.Id})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    int count = sqlCommand.ExecuteNonQuery();
                    if (count == 1)
                    {
                        success = true;
                    }
                }

                sqlConnection.Close();
            }

            return success;
        }

        public bool RevokeProfile(User user, Profile profile)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE FROM {TABLE_USER_PROFILE}" +
                                $" WHERE {TABLE_USER_PROFILE}.{COLUMN_USER_PROFIL_IDPROFILE} = {profile.ProfileId}" +
                                $"  AND {TABLE_USER_PROFILE}.{COLUMN_USER_PROFIL_IDUSER} = {user.Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    int count = sqlCommand.ExecuteNonQuery();
                    if (count == 1)
                    {
                        success = true;
                    }
                }

                sqlConnection.Close();
            }

            return success;
        }
        public List<Profile> getAllProfiles()
        {
            List<Profile> profileList = new List<Profile>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_PROFILE_IDPROFILE}, {COLUMN_PROFILE_NAME}, {COLUMN_PROFILE_DESC} " +
                                $" FROM {TABLE_PROFILE} ";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {

                            profileList.Add(new Profile(new Object[] { sqlReader[0], sqlReader[1], sqlReader[2] }));
                        }
                    }

                    sqlReader.Close();
                }
            }

            return profileList;
        }

        public bool addProfileLicense(Profile profile, Component license)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_PROFILE_LICENSE} ({COLUMN_PROFILE_LICENSE_idProfile}, {COLUMN_PROFILE_LICENSE_idLicense})" +
                                $" VALUES ( {PARAM_PROFILE_LICENSE_idProfile}, {PARAM_PROFILE_LICENSE_idLicense})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PROFILE_LICENSE_idProfile, profile.ProfileId);
                    sqlCommand.Parameters.AddWithValue(PARAM_PROFILE_LICENSE_idLicense, license.Id);

                    int count = sqlCommand.ExecuteNonQuery();
                    if (count == 1)
                    {
                        success = true;
                    }
                }

                sqlConnection.Close();
            }

            return success;
        }

        public bool revokeProfileLicense(Profile profile, Component license)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE FROM {TABLE_PROFILE_LICENSE}" +
                                $" WHERE {COLUMN_PROFILE_LICENSE_idProfile} = {PARAM_PROFILE_LICENSE_idProfile} " +
                                $" AND {COLUMN_PROFILE_LICENSE_idLicense} = {PARAM_PROFILE_LICENSE_idLicense}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PROFILE_LICENSE_idProfile, profile.ProfileId);
                    sqlCommand.Parameters.AddWithValue(PARAM_PROFILE_LICENSE_idLicense, license.Id);

                    int count = sqlCommand.ExecuteNonQuery();
                    if (count == 1)
                    {
                        success = true;
                    }
                }

                sqlConnection.Close();
            }

            return success;
        }
        public bool createProfile(string profileName, string profileDesc)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_PROFILE} ({COLUMN_PROFILE_NAME}, {COLUMN_PROFILE_DESC})" +
                                $" VALUES ( {PARAM_PROFILE_NAME}, {PARAM_PROFILE_DESC})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PROFILE_NAME, profileName);
                    sqlCommand.Parameters.AddWithValue(PARAM_PROFILE_DESC, profileDesc);

                    int count = sqlCommand.ExecuteNonQuery();
                    if (count == 1)
                    {
                        success = true;
                    }
                }

                sqlConnection.Close();
            }

            return success;
        }
        public bool deleteProfile(Profile profile)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"BEGIN TRANSACTION profileDel" +
                                $" BEGIN TRY" +
                                    $" DELETE FROM {TABLE_USER_PROFILE}" +
                                    $" WHERE {TABLE_USER_PROFILE}.{COLUMN_USER_PROFIL_IDPROFILE} = {profile.ProfileId}" +
                                    $" DELETE FROM {TABLE_PROFILE_LICENSE}" +
                                    $" WHERE {TABLE_PROFILE_LICENSE}.{COLUMN_PROFILE_LICENSE_idProfile} = {profile.ProfileId}" +
                                    $" DELETE FROM {TABLE_PROFILE}" +
                                    $" WHERE {TABLE_PROFILE}.{COLUMN_PROFILE_IDPROFILE} = {profile.ProfileId}" +
                                    $" COMMIT TRANSACTION profileDel" +
                                $" END TRY" +
                                $" BEGIN CATCH" +
                                    $" ROLLBACK TRANSACTION profileDel" +
                                $" END CATCH";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {

                    int count = sqlCommand.ExecuteNonQuery();
                    if (count > 0)
                    {
                        success = true;
                    }
                }

                sqlConnection.Close();
            }

            return success;
        }
        public bool promoteAccount(int numeroMatricula, User user, Profile profile)
        {
            bool success = false;

            if (validateMatricula(numeroMatricula))
            {
                using (sqlConnection = new SqlConnection(CONNECTION_STRING))
                {
                    sqlConnection.Open();

                    string query = $"INSERT INTO {TABLE_USER_PROFILE} ({COLUMN_USER_PROFIL_IDPROFILE}, {COLUMN_USER_PROFIL_IDUSER})" +
                                $" VALUES ( {profile.ProfileId}, {user.Id})";

                    using (sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        int count = sqlCommand.ExecuteNonQuery();
                        if (count == 1)
                        {
                            success = true;
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return success;
        }

        //This method should be modified acordingly, once the REFEPS credentials are provided.
        private bool validateMatricula(int numeroMatricula)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_MATRICULA}.{COLUMN_MATRICULA_MATRICULA} " +
                                $" FROM {TABLE_MATRICULA} " +
                                $" WHERE {COLUMN_MATRICULA_MATRICULA} = {numeroMatricula}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        success = true;
                    }

                    sqlReader.Close();
                }
                sqlConnection.Close();
            }
            return success;
        }
        public User Save(User Entity)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
