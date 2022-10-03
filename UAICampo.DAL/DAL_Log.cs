using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Services;

namespace UAICampo.DAL
{
    public class DAL_Log : DAL_Abstract<Log>
    {
        //Test DB
        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        //table
        private const string TABLE_log = "eventLog";

        //log table columns
        private const string COLUMN_LOG_DATE = "date";
        private const string COLUMN_LOG_CODE = "code";
        private const string COLUMN_LOG_DESCRIPTION = "description";
        private const string COLUMN_LOG_TYPE = "type";
        private const string COLUMN_LOG_FK_USER = "FK_account_eventLog";

        //log params
        private static readonly string PARAM_LOG_DATE = $"@{COLUMN_LOG_DATE}";
        private static readonly string PARAM_LOG_CODE = $"@{COLUMN_LOG_CODE}";
        private static readonly string PARAM_LOG_DESCRIPTION = $"@{COLUMN_LOG_DESCRIPTION}";
        private static readonly string PARAM_LOG_TYPE = $"@{COLUMN_LOG_TYPE}";
        private static readonly string PARAM_LOG_USERNAME = $"@{COLUMN_LOG_FK_USER}";

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Log FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<Log> GetAll(DateTime? from = null, DateTime? to = null, string type = null)
        {
            List<Log> licenses = new List<Log>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $" SELECT {COLUMN_LOG_CODE}, {COLUMN_LOG_DESCRIPTION}, {COLUMN_LOG_TYPE}, {COLUMN_LOG_DATE}, {COLUMN_LOG_FK_USER}" +
                                $" FROM {TABLE_log}";

                if (from != null)
                {
                    query += $" WHERE {COLUMN_LOG_DATE} BETWEEN '{from?.ToString("yyyy-MM-dd")}' AND '{to?.ToString("yyyy-MM-dd")}'";
                }

                if (type != null)
                {
                    query += $" AND {COLUMN_LOG_TYPE} LIKE '%{type}%'";
                }


                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            licenses.Add(new Log( new Object[] { sqlReader[0], sqlReader[1], sqlReader[2], sqlReader[3], sqlReader[4] }));
                        }
                    }
                }
            }

            return licenses;
        }

        public Log Save(Log Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                if (Entity.User != null)
                {
                    string query = $"INSERT INTO {TABLE_log} ({COLUMN_LOG_DATE}, {COLUMN_LOG_CODE}, {COLUMN_LOG_DESCRIPTION}, {COLUMN_LOG_TYPE}, {COLUMN_LOG_FK_USER})" +
                                    $" VALUES ({PARAM_LOG_DATE}, {PARAM_LOG_CODE}, {PARAM_LOG_DESCRIPTION}, {PARAM_LOG_TYPE}, {PARAM_LOG_USERNAME})";

                    using (sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_DATE, Entity.Date);
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_CODE, Entity.Code);
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_DESCRIPTION, Entity.Description);
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_TYPE, Entity.Type.AsText());
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_USERNAME, Entity.User);

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                else
                {
                    string query = $"INSERT INTO {TABLE_log} ({COLUMN_LOG_DATE}, {COLUMN_LOG_CODE}, {COLUMN_LOG_DESCRIPTION}, {COLUMN_LOG_TYPE}, {COLUMN_LOG_FK_USER})" +
                                    $" VALUES ({PARAM_LOG_DATE}, {PARAM_LOG_CODE}, {PARAM_LOG_DESCRIPTION}, {PARAM_LOG_TYPE}, {PARAM_LOG_USERNAME})";

                    using (sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_DATE, Entity.Date);
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_CODE, Entity.Code);
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_DESCRIPTION, Entity.Description);
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_TYPE, Entity.Type.AsText());
                        sqlCommand.Parameters.AddWithValue(PARAM_LOG_USERNAME, 0);

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                sqlConnection.Close();
            }

            return Entity;
        }

        public IList<Log> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
