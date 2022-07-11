using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.BE;
using UAICampo.DAL.SQL;
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
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE" +
                                $" FROM {TABLE_EQUIPO}" +
                                $" WHERE {COLUMN_EQUIPO_ID} = {PARAM_EQUIPO_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_EQUIPO_ID, Id);
                    sqlReader = sqlCommand.ExecuteReader();
                }
            }
        }

        public void DeleteMembers(int Id)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"delete from account_team where id_team = {PARAM_EQUIPO_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_EQUIPO_ID, Id);
                    sqlReader = sqlCommand.ExecuteReader();
                }
            }
        }

        public bool DeleteTeam(int Id)
        {
            bool success = false;
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE" +
                                $" FROM {TABLE_EQUIPO}" +
                                $" WHERE {COLUMN_EQUIPO_ID} = {PARAM_EQUIPO_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_EQUIPO_ID, Id);

                    int count = sqlCommand.ExecuteNonQuery();
                    if (count == 1)
                    {
                        success = true;
                    }
                }
            }
            return success;
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

        public  List<KeyValuePair<IProfile, IUser>> getTeam(Equipo equipo)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand query = new SqlCommand($"select account.id, (profile.id) 'profile' from account join account_profile on account.id = account_profile.id_account join profile on profile.id = account_profile.id_profile join account_team on account_team.id_account = account.id where id_team = {equipo.Id} ", sqlConnection);
                sqlConnection.Open();
                SqlDataReader data = query.ExecuteReader();
                List<int[]> sectorArrayList = new List<int[]>();

                if (!data.HasRows)
                {
                    sqlConnection.Close();
                    return new List<KeyValuePair<IProfile, IUser>>();
                }

                while (data.Read())
                {
                    sectorArrayList.Add(new int[] {
                        int.Parse(data["profile"].ToString()),
                        data["id"].ToString() == "" ? 0 : int.Parse(data["id"].ToString())
                    });
                }

                sqlConnection.Close();

                DAL_Profile_SQL profileDAL = new DAL_Profile_SQL();
                DAL_User_SQL userDAL = new DAL_User_SQL();
                List<KeyValuePair<IProfile, IUser>> puestos = new List<KeyValuePair<IProfile, IUser>>();

                foreach (int[] sectorArray in sectorArrayList)
                {
                    puestos.Add(new KeyValuePair<IProfile, IUser>(profileDAL.getProfileById(sectorArray[0]), userDAL.FindById(sectorArray[1])));
                }

                return puestos;
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

        public IEquipo getUserTeam(int id)
        {
            Equipo equipo = new Equipo();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select team.id, team.name, team.value from team join account_team on id_team = team.id where id_account = {id}";

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

        public List<User> getMembers(int id)
        {
            List<User> userList = new List<User>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"select account.id, account.username, account.email from account join account_team on id_account = account.id where id_team = {id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {

                            userList.Add(new User(new Object[] { sqlReader[0], sqlReader[1], sqlReader[2] }));
                        }
                    }

                    sqlReader.Close();
                }
            }

            return userList;
        }
    }
}
