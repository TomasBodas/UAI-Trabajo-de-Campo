using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.BE;
using UAICampo.Services;

namespace UAICampo.DAL
{
    public class DAL_Equipo_SQL : DAL_Abstract<Equipo>
    {
        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        //table names
        private const string TABLE_EQUIPO = "team";

        //TABLE_LANGUAGE Columns
        private const string COLUMN_EQUIPO_ID = "id";
        private const string COLUMN_EQUIPO_NAME = "name";
        private const string COLUMN_EQUIPO_VALUE = "value";

        private static readonly string PARAM_EQUIPO_ID = $"@{COLUMN_EQUIPO_ID}";
        private static readonly string PARAM_EQUIPO_NAME = $"@{COLUMN_EQUIPO_NAME}";
        private static readonly string PARAM_EQUIPO_VALUE = $"@{COLUMN_EQUIPO_VALUE}";

        //TABLE_accounts Columns
        private const string COLUMN_ACCOUNT_ID = "id";
        private const string COLUMN_ACCOUNT_FK_LANGUAGE = "FK_language_account";

        private static readonly string PARAM_ACCOUNT_ID = $"@{COLUMN_ACCOUNT_ID}";

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Equipo FindById(int Id)
        {
            Equipo equipo = new Equipo();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_EQUIPO_ID}, {COLUMN_EQUIPO_NAME}, {COLUMN_EQUIPO_VALUE}" +
                                $" FROM {TABLE_EQUIPO}" +
                                $" WHERE {COLUMN_EQUIPO_ID} = {Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            equipo = new Equipo(new object[] { sqlReader[0], sqlReader[1], sqlReader[2] });
                        }
                    }
                }
            }

            return equipo;
        }

        public Equipo FindByName(string name)
        {
            Equipo equipo = new Equipo();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_EQUIPO_ID}, {COLUMN_EQUIPO_NAME}, {COLUMN_EQUIPO_VALUE}" +
                                $" FROM {TABLE_EQUIPO}" +
                                $" WHERE {COLUMN_EQUIPO_NAME} = '{name}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            equipo = new Equipo(new object[] { sqlReader[0], sqlReader[1], sqlReader[2] });
                        }
                    }
                }
            }

            return equipo;
        }

        public int GetId(string name)
        {
            Equipo equipo = new Equipo();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_EQUIPO_ID}, {COLUMN_EQUIPO_NAME}, {COLUMN_EQUIPO_VALUE}" +
                                $" FROM {TABLE_EQUIPO}" +
                                $" WHERE {COLUMN_EQUIPO_NAME} = '{name}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            equipo = new Equipo(new object[] { sqlReader[0], sqlReader[1], sqlReader[2] });
                        }
                    }
                }
            }
            return equipo.Id;
        }

        public bool ifExists(string name)
        {
            Equipo equipo = new Equipo();
            bool result = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_EQUIPO_ID}, {COLUMN_EQUIPO_NAME}, {COLUMN_EQUIPO_VALUE}" +
                                $" FROM {TABLE_EQUIPO}" +
                                $" WHERE {COLUMN_EQUIPO_NAME} = '{name}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
        public IList<Equipo> GetAll()
        {

            List<Equipo> equipos = new List<Equipo>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_EQUIPO_ID}, {COLUMN_EQUIPO_NAME}, {COLUMN_EQUIPO_VALUE}" +
                                $" FROM {TABLE_EQUIPO}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            equipos.Add(new Equipo(new object[] { sqlReader[0], sqlReader[1], sqlReader[2] }));
                        }
                    }
                }
            }

            return equipos;
        }

        public Equipo Save(Equipo Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_EQUIPO} ({COLUMN_EQUIPO_NAME}, {COLUMN_EQUIPO_VALUE})" +
                                $" VALUES ({PARAM_EQUIPO_NAME}, {PARAM_EQUIPO_VALUE})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_EQUIPO_NAME, Entity.Name);
                    sqlCommand.Parameters.AddWithValue(PARAM_EQUIPO_VALUE, Entity.Value);
                    sqlCommand.ExecuteNonQuery();
                }

                foreach (KeyValuePair<IProfile, IUser> puesto in Entity.puestos)
                {
                    if (puesto.Value != null)
                    {
                        addPosition(puesto.Value, GetId(Entity.Name));
                    }
                }

                return Entity;
            }
        }

        public Equipo Update(Equipo Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"UPDATE {TABLE_EQUIPO}" +
                                $" SET {COLUMN_EQUIPO_NAME} = {PARAM_EQUIPO_NAME}, {COLUMN_EQUIPO_VALUE} = {PARAM_EQUIPO_VALUE}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_EQUIPO_NAME, Entity.Name);
                    sqlCommand.Parameters.AddWithValue(PARAM_EQUIPO_VALUE, Entity.Value);
                    sqlCommand.ExecuteNonQuery();
                }
                deletePositions(Entity.Id);

                foreach (KeyValuePair<IProfile, IUser> puesto in Entity.puestos)
                {
                    if (puesto.Value != null)
                    {
                        addPosition(puesto.Value, Entity.Id);
                    }
                }
                return Entity;
            }
        }

        public void addPosition(IUser User, int teamId )
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO account_team (id_account, id_team)" +
                                $" VALUES (@idacc, @idteam)";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@idacc", User.Id);
                    sqlCommand.Parameters.AddWithValue("@idteam", teamId);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void deletePositions(int equipoId)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE" +
                                $" FROM account_team" +
                                 $" WHERE id_team = {PARAM_EQUIPO_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_EQUIPO_ID, equipoId);
                    sqlReader = sqlCommand.ExecuteReader();
                }
            }
        }
    }
}
