using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UAICampo.Services ;


namespace UAICampo.DAL
{
    public class DAL_Profile_SQL : DAL_Abstract
    {

        private static readonly string CONNECTION_STRING = "Data Source=.;Initial Catalog=Campo;Integrated Security=True";

        private const string TABLE_USER_PROFILE = "User_Profile";
        private const string TABLE_PROFILE = "Profile";


        private const string COLUMN_PROFILE_IDPROFILE = "IdProfile";
        private const string COLUMN_PROFILE_NAME = "Name";
        private const string COLUMN_PROFILE_DESC = "Desc";

        private static readonly string PARAM_PROFILE_IDPROFILE = $"@{COLUMN_PROFILE_IDPROFILE}";
        private static readonly string PARAM_PROFILE_NAME = $"@{COLUMN_PROFILE_NAME}";
        private static readonly string PARAM_PROFILE_DESC = $"@{COLUMN_PROFILE_DESC}";

        private const string COLUMN_USER_PROFIL_IDPROFILE = "IdProfile";
        private const string COLUMN_USER_PROFIL_IDUSER = "IdUser";

        private static readonly string PARAM_USER_PROFIL_IDPROFILE = $"@{COLUMN_USER_PROFIL_IDPROFILE}";
        private static readonly string PARAM_USER_PROFIL_IDUSER = $"@{COLUMN_USER_PROFIL_IDUSER}";

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;


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
    }
}
