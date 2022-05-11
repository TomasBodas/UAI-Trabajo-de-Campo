using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.Services;

namespace UAICampo.DAL.SQL
{
    public class DAL_User_SQL : DAL_Abstract<User>
    {
        //Test DB
        private static readonly string CONNECTION_STRING = "Data Source=.;Initial Catalog=Campo;Integrated Security=True";

        //Production DB
        //private static readonly string CONNECTION_STRING = "Data Source=.;Initial Catalog=CampoFinal;Integrated Security=True";

        private static Encrypt ENCRYPTION_SERVICE = new Encrypt();

        #region tables
        //table names
        private const string TABLE_user = "userTable";
        private const string TABLE_password = "passwordTable";
        private const string TABLE_userStatus = "userStatusTable";

        #endregion

        #region user columns/params
        //user table columns
        private const string COLUMN_USER_ID = "id";
        private const string COLUMN_USER_USERNAME = "userName";
        private const string COLUMN_USER_EMAIL = "email";

        //user params
        private static readonly string PARAM_USER_ID = $"@{COLUMN_USER_ID}";
        private static readonly string PARAM_USER_USERNAME = $"@{COLUMN_USER_USERNAME}";
        private static readonly string PARAM_USER_EMAIL = $"@{COLUMN_USER_EMAIL}";
        #endregion

        #region password columns/params
        //password table columns
        private const string COLUMN_PASSWORD_ID = "id";
        private const string COLUMN_PASSWORD_PASSHASH = "passHash";

        //password params
        private static readonly string PARAM_PASSWORD_ID = $"@{COLUMN_PASSWORD_ID}";
        private static readonly string PARAM_PASSWORD_PASSHASH = $"@{COLUMN_PASSWORD_PASSHASH}";
        #endregion

        #region user status columns/params
        //user status table columns
        private const string COLUMN_USERSTATUS_ID = "id";
        private const string COLUMN_USERSTATUS_BLOCKED = "isBlocked";
        private const string COLUMN_USERSTATUS_ATTEMPTS = "attempts";

        private static readonly string PARAM_USERSTATUS_ID = $"@{COLUMN_USERSTATUS_ID}";
        private static readonly string PARAM_USERSTATUS_BLOCKED = $"@{COLUMN_USERSTATUS_BLOCKED}";
        private static readonly string PARAM_USERSTATUS_ATTEMPTS = $"@{COLUMN_USERSTATUS_ATTEMPTS}";
        #endregion

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        public User findByUsername(string pUsername)
        {
            User user = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_user}.{COLUMN_USER_ID}, {TABLE_user}.{COLUMN_USER_USERNAME}, {TABLE_user}.{COLUMN_USER_EMAIL}, {TABLE_userStatus}.{COLUMN_USERSTATUS_BLOCKED}, {TABLE_userStatus}.{COLUMN_USERSTATUS_ATTEMPTS}" +
                                $" FROM {TABLE_user}" +
                                $" INNER JOIN {TABLE_userStatus} ON {TABLE_user}.{COLUMN_USER_ID} = {TABLE_userStatus}.{COLUMN_USERSTATUS_ID}" +
                                $" WHERE {TABLE_user}.{COLUMN_USER_USERNAME} = '{pUsername}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows) 
                    {
                        while (sqlReader.Read())
                        {
                            user = new User(new object[] {(int) sqlReader[0],
                                                    (string) sqlReader[1],
                                                    (string) sqlReader[2]});

                            user.IsBlocked = (bool)sqlReader[3];
                            user.Attempts = (int)sqlReader[4];
                        }
                    }
                    sqlReader.Close();
                }
            }
            return user;
        }
        public bool userPasswordMatcher(int pId, string inputPassword)
        {
            bool matches = false;
            string storesPass = "";

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_PASSWORD_PASSHASH}" +
                                $" FROM {TABLE_password}" +
                                $" WHERE {TABLE_password}.{COLUMN_PASSWORD_ID} = {pId}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            storesPass = (string)sqlReader[0];
                            storesPass = storesPass.Replace(" ", string.Empty);
                        }
                    }
                    sqlReader.Close();
                }
            }

            Encrypt serviceEncryption = new Encrypt();

            if (serviceEncryption.hashComparer(inputPassword, storesPass))
            {
                matches = true;
            }

            return matches;
        }
        public void UpdateUserStatus(User Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                string query = $"UPDATE {TABLE_userStatus}" +
                                $" SET {COLUMN_USERSTATUS_BLOCKED} = {PARAM_USERSTATUS_BLOCKED}, {COLUMN_USERSTATUS_ATTEMPTS} = {PARAM_USERSTATUS_ATTEMPTS}" +
                                $" WHERE {COLUMN_USER_ID} = {Entity.Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_BLOCKED, Entity.IsBlocked);
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_ATTEMPTS, Entity.Attempts);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        private int getNextUserId()
        {
            int id = 0;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT MAX({COLUMN_USER_ID})" +
                                $" FROM {TABLE_user}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            id = (int)sqlReader[0];
                        }
                    }
                    sqlReader.Close();
                }
            }
            id++;
            return id;
        }

        public User Save(User Entity)
        {
            Entity.Id = this.getNextUserId();
            Entity.IsBlocked = false;
            Entity.Attempts = 0;
            Entity.Password = ENCRYPTION_SERVICE.hasher(Entity.Password);

            //Saving User
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query =  $"INSERT INTO {TABLE_user} ({COLUMN_USER_ID}, {COLUMN_USER_USERNAME}, {COLUMN_USER_EMAIL})" +
                                $" VALUES ({PARAM_USER_ID}, {PARAM_USER_USERNAME}, {PARAM_USER_EMAIL})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_ID, Entity.Id);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_USERNAME, Entity.Username);
                    sqlCommand.Parameters.AddWithValue(PARAM_USER_EMAIL, Entity.Email);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }

            //Saving Password
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_password} ({COLUMN_PASSWORD_ID}, {COLUMN_PASSWORD_PASSHASH})" +
                                $" VALUES ({PARAM_PASSWORD_ID}, {PARAM_PASSWORD_PASSHASH})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_PASSWORD_ID, Entity.Id);
                    sqlCommand.Parameters.AddWithValue(PARAM_PASSWORD_PASSHASH, Entity.Password);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }

            //Saving Status
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_userStatus} ({COLUMN_USERSTATUS_ID}, {COLUMN_USERSTATUS_BLOCKED}, {COLUMN_USERSTATUS_ATTEMPTS})" +
                                $" VALUES ({PARAM_USERSTATUS_ID}, {PARAM_USERSTATUS_BLOCKED}, {PARAM_USERSTATUS_ATTEMPTS})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_ID, Entity.Id);
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_BLOCKED, Entity.IsBlocked);
                    sqlCommand.Parameters.AddWithValue(PARAM_USERSTATUS_ATTEMPTS, Entity.Attempts);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }

            return Entity;
        }

        //needs implementation

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
