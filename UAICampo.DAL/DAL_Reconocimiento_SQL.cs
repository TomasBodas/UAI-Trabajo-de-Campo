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
    public class DAL_Reconocimiento_SQL : DAL_Abstract<Reconocimiento>
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


        public List<Reconocimiento> getReceived(User us, int limit)
        {

            List<Reconocimiento> reconocimiento = new List<Reconocimiento>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                
                string query = "SELECT";

                if (limit != 0)
                {
                    query += $" TOP {limit}";
                }

                query += $" achievement.id, achievement.description, achievement.date, achievement.value, achievement.FK_receiver_achievement, achievement.FK_sender_achievement from achievement where FK_receiver_achievement = {us.Id}";

                if (limit != 0)
                {
                    query += $" ORDER BY id DESC";
                }

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            reconocimiento.Add(new Reconocimiento(new object[] { (int)sqlReader[0], (string)sqlReader[1], (string)sqlReader[2], (string)sqlReader[3] }));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return reconocimiento.ToList();
        }

        public List<Reconocimiento> getReceivedSuperiors(User us)
        {

            List<Reconocimiento> reconocimiento = new List<Reconocimiento>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                var twoMonthsAgo = DateTime.Now.AddDays(-60);

                string query = "SELECT";


                query += $" achievement.id, achievement.description, achievement.date, achievement.value, achievement.FK_receiver_achievement, achievement.FK_sender_achievement from achievement where FK_receiver_achievement = {us.Id} AND achievement.value > 1 AND achievement.date > '{twoMonthsAgo.ToString("yyyy-MM-dd")}'";


                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            reconocimiento.Add(new Reconocimiento(new object[] { (int)sqlReader[0], (string)sqlReader[1], (string)sqlReader[2], (string)sqlReader[3] }));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return reconocimiento.ToList();
        }

        public List<Reconocimiento> getLastReceived(User us)
        {

            List<Reconocimiento> reconocimiento = new List<Reconocimiento>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                var twoMonthsAgo = DateTime.Now.AddDays(-60);

                string query = "SELECT";


                query += $" achievement.id, achievement.description, achievement.date, achievement.value, achievement.FK_receiver_achievement, achievement.FK_sender_achievement from achievement where FK_receiver_achievement = {us.Id} AND achievement.date > '{twoMonthsAgo.ToString("yyyy-MM-dd")}'";


                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            reconocimiento.Add(new Reconocimiento(new object[] { (int)sqlReader[0], (string)sqlReader[1], (string)sqlReader[2], (string)sqlReader[3] }));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return reconocimiento.ToList();
        }

        public Reconocimiento Save(Reconocimiento Entity)
        {
            throw new NotImplementedException();
        }

        public IList<Reconocimiento> GetAll()
        {
            throw new NotImplementedException();
        }

        public Reconocimiento FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
