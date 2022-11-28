using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.BE;
using UAICampo.Services;

namespace UAICampo.DAL
{
    public class DAL_Propuesta_SQL : DAL_Abstract<UserPropuesto>
    {
        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        #region tables
        //table names
        private const string TABLE_user = "account";

        #endregion

        #region user columns/params
        //user table columns
        private const string COLUMN_USER_ID = "id";
        private const string COLUMN_USER_USERNAME = "username";
        private const string COLUMN_USER_EMAIL = "email";
        private const string COLUMN_USER_LANGUAGE = "FK_language_account";

        //user params
        private static readonly string PARAM_USER_ID = $"@{COLUMN_USER_ID}";
        private static readonly string PARAM_USER_USERNAME = $"@{COLUMN_USER_USERNAME}";
        private static readonly string PARAM_USER_EMAIL = $"@{COLUMN_USER_EMAIL}";
        private static readonly string PARAM_USER_LANGUAGE = $"@{COLUMN_USER_LANGUAGE}";
        #endregion
        public List<UserPropuesto> GetForPosition()
        {

            List<UserPropuesto> userList = new List<UserPropuesto>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = "select account.id, account.username, account.email from account LEFT JOIN account_team ON account.id = account_team.id_account LEFT JOIN account_profile on account.id = account_profile.id_account WHERE account_team.id_account IS NULL AND id_profile NOT LIKE 1 AND id_profile NOT LIKE 2 AND id_profile NOT LIKE 4";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            userList.Add(new UserPropuesto(new object[] { (int)sqlReader[0], (string)sqlReader[1] }));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return userList.ToList();
        }

        public UserPropuesto FindByUsername(string name)
        {

            UserPropuesto userList = new UserPropuesto();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select account.id, account.username, account.email from account LEFT JOIN account_team ON account.id = account_team.id_account LEFT JOIN account_profile on account.id = account_profile.id_account WHERE account_team.id_account IS NULL AND account.username = '{name}' AND id_profile NOT LIKE 1 AND id_profile NOT LIKE 2 AND id_profile NOT LIKE 4";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            userList = new UserPropuesto(new object[] { (int)sqlReader[0], (string)sqlReader[1] });
                        }
                    }
                    sqlReader.Close();
                }
            }

            return userList;
        }
        public UserPropuesto FindByUsernameExists(string name)
        {

            UserPropuesto userList = new UserPropuesto();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select account.id, account.username, account.email from account LEFT JOIN account_team ON account.id = account_team.id_account LEFT JOIN account_profile on account.id = account_profile.id_account WHERE account.username = '{name}' AND id_profile NOT LIKE 1 AND id_profile NOT LIKE 2 AND id_profile NOT LIKE 4";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            userList = new UserPropuesto(new object[] { (int)sqlReader[0], (string)sqlReader[1] });
                        }
                    }
                    sqlReader.Close();
                }
            }

            return userList;
        }
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public UserPropuesto FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<UserPropuesto> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserPropuesto Save(UserPropuesto Entity)
        {
            throw new NotImplementedException();
        }
    }
}
