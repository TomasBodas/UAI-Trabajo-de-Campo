using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UAICampo.Services;


namespace UAICampo.DAL
{
    public class DAL_Profile_SQL : DAL_Abstract<User>
    {

        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        private const string TABLE_USER_PROFILE = "account_profile";
        private const string TABLE_PROFILE = "profile";


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
