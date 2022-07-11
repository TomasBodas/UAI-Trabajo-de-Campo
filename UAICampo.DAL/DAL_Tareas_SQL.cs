using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.BE;
using UAICampo.Services;
using static UAICampo.BE.Tarea;

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


        public Tarea Save(Tarea t)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"insert into task (title, description, dateCreated, state, archived, value, dateDeadline, FK_team_task, FK_epic_task ) " +
                                $"values ('{t.Title}', '{t.Description}', convert(datetime, '{t.DateCreated}'), {0}, {0}, {t.Value}, convert(datetime, '{t.DateDeadline}'), {t.Equipo.Id}, {t.EpicaId})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }

                return t;
            }
        }

        public Epica SaveEpic(Epica Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO epic (title, description)" +
                                $" VALUES ('{Entity.Name}', '{Entity.Description}')";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {

                    sqlCommand.ExecuteNonQuery();
                }

                return Entity;
            }
        }
        public List<Epica> getAllEpics()
        {
            List<Epica> epics = new List<Epica>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select * from epic";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            epics.Add(new Epica(new object[] { (int)sqlReader[0], (string)sqlReader[1], (string)sqlReader[2]}));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return epics.ToList();
        }
        public List<Tarea> getTasksByTeam(IEquipo eq)
        {
            List<Tarea> tareas = new List<Tarea>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select id, title, description, dateCreated, dateDeadline, dateFinished, value, state, archived, FK_epic_task from task where FK_team_task = {eq.Id} and FK_account_task is null";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            tareas.Add(castDTO(sqlReader));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return tareas.ToList();
        }

        public List<Tarea> getTasksByUser(IEquipo eq, User user)
        {
            List<Tarea> tareas = new List<Tarea>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select id, title, description, dateCreated, dateDeadline, dateFinished, value, state, archived, FK_epic_task from task where FK_team_task = {eq.Id} and FK_account_task = {user.Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            tareas.Add(castDTO(sqlReader));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return tareas.ToList();
        }

        public Tarea castDTO(SqlDataReader data)
        {
            Tarea result = new Tarea();
            result.Id = Convert.ToInt32(data["id"]);
            result.Title = data["title"].ToString();
            result.Description = data["description"].ToString();
            result.DateCreated = Convert.ToDateTime(data["dateCreated"]);
            result.DateDeadline = Convert.ToDateTime(data["dateDeadline"]);
            //result.DateFinished = Convert.ToDateTime(data["dateFinished"]);
            result.Value = Convert.ToInt32(data["value"]);
            result.State = (StateType)Convert.ToInt32(data["state"]);
            result.Archived = Convert.ToBoolean(data["archived"]);
            result.EpicaId = Convert.ToInt32(data["FK_epic_task"]);
            return result;
        }

        public IUser getUserTask(Tarea Entity)
        {
            User user = new User();
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select account.id, account.username, account.email from account join task on FK_account_task = account.id where task.title = '{Entity.Title}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {

                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            user = new User(new object[] { sqlReader[0], sqlReader[1], sqlReader[2] });
                        }
                    }
                }

                return user;
            }
        }

        public bool assignMember(string tareatitle, int usId)
        {
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"update task set FK_account_task = {usId} where title = '{tareatitle}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        success = true;
                    }
                }

                sqlConnection.Close();
            }

            return success;
        }
        public IList<Tarea> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tarea FindById(int Id)
        {

            Tarea tarea = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select id, title, description, dateCreated, dateDeadline, dateFinished, value, state, archived, FK_epic_task from task where id = {Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            tarea = castDTO(sqlReader);

                        }
                    }
                    sqlReader.Close();
                }
            }
            return tarea;
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
