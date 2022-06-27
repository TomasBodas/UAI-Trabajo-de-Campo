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
    public class DAL_Tareas_SQL : DAL_Abstract<Tarea>
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


        public List<Tarea> getFinished(User user)
        {
            List<Tarea> tareas = new List<Tarea>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select task.id, task.title, task.description, task.dateCreated, task.dateDeadline, task.dateFinished, task.value, task.state, task.archived, task.FK_account_task, task.FK_epic_task, task.FK_team_task from task WHERE task.FK_account_task = {user.Id} AND task.archived = 1 ORDER BY task.id DESC";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            tareas.Add(new Tarea(new object[] { (int)sqlReader[0], (string)sqlReader[1], (string)sqlReader[2], (string)sqlReader[3], (string)sqlReader[4], (string)sqlReader[5], (string)sqlReader[6], (string)sqlReader[7], (string)sqlReader[8] }));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return tareas.ToList();
        }

        public List<Tarea> getAccomplished(User user)
        {
            List<Tarea> tareas = new List<Tarea>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select task.id, task.title, task.description, task.dateCreated, task.dateDeadline, task.dateFinished, task.value, task.state, task.archived, task.FK_account_task, task.FK_epic_task, task.FK_team_task from task WHERE task.FK_account_task = {user.Id} AND task.archived = 1 AND task.state = 'Closed' ORDER BY task.id DESC";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            tareas.Add(new Tarea(new object[] { (int)sqlReader[0], (string)sqlReader[1], (string)sqlReader[2], (string)sqlReader[3], (string)sqlReader[4], (string)sqlReader[5], (string)sqlReader[6], (string)sqlReader[7], (string)sqlReader[8] }));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return tareas.ToList();
        }

        public List<Tarea> getUnfinished(User user)
        {
            List<Tarea> tareas = new List<Tarea>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select task.id, task.title, task.description, task.dateCreated, task.dateDeadline, task.dateFinished, task.value, task.state, task.archived, task.FK_account_task, task.FK_epic_task, task.FK_team_task from task WHERE task.FK_account_task = {user.Id} AND task.archived = 1 AND task.state = 'Canceled' ORDER BY task.id DESC";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            tareas.Add(new Tarea(new object[] { (int)sqlReader[0], (string)sqlReader[1], (string)sqlReader[2], (string)sqlReader[3], (string)sqlReader[4], (string)sqlReader[5], (string)sqlReader[6], (string)sqlReader[7], (string)sqlReader[8] }));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return tareas.ToList();
        }


        public Tarea Save(Tarea Entity)
        {
            throw new NotImplementedException();
        }

        public IList<Tarea> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tarea FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
