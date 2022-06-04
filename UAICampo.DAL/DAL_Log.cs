﻿using System;
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
        private static readonly string CONNECTION_STRING = "Data Source=DESKTOP-4OC5GG6\\SQLEXPRESS;Initial Catalog=Campo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //table
        private const string TABLE_log = "eventLog";

        //log table columns
        private const string COLUMN_LOG_DATE = "date";
        private const string COLUMN_LOG_CODE = "code";
        private const string COLUMN_LOG_DESCRIPTION = "description";
        private const string COLUMN_LOG_TYPE = "type";
        private const string COLUMN_LOG_USERNAME = "username";

        //log params
        private static readonly string PARAM_LOG_DATE = $"@{COLUMN_LOG_DATE}";
        private static readonly string PARAM_LOG_CODE = $"@{COLUMN_LOG_CODE}";
        private static readonly string PARAM_LOG_DESCRIPTION = $"@{COLUMN_LOG_DESCRIPTION}";
        private static readonly string PARAM_LOG_TYPE = $"@{COLUMN_LOG_TYPE}";
        private static readonly string PARAM_LOG_USERNAME = $"@{COLUMN_LOG_USERNAME}";

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

        public IList<Log> GetAll()
        {
            throw new NotImplementedException();
        }

        public Log Save(Log Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_log} ({COLUMN_LOG_DATE}, {COLUMN_LOG_CODE}, {COLUMN_LOG_DESCRIPTION}, {COLUMN_LOG_TYPE}, {COLUMN_LOG_USERNAME})" +
                                $" VALUES ({PARAM_LOG_DATE}, {PARAM_LOG_CODE}, {PARAM_LOG_TYPE}, {PARAM_LOG_USERNAME})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_LOG_DATE, Entity.Date);
                    sqlCommand.Parameters.AddWithValue(PARAM_LOG_CODE, Entity.Code);
                    sqlCommand.Parameters.AddWithValue(PARAM_LOG_DESCRIPTION, Entity.Description);
                    sqlCommand.Parameters.AddWithValue(PARAM_LOG_TYPE, Entity.Type);
                    sqlCommand.Parameters.AddWithValue(PARAM_LOG_USERNAME, Entity.User.Id);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }

            return Entity;
        }

    }
}