using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Services.Composite;
using UAICampo.Services;

namespace UAICampo.DAL
{
    public class DAL_Licences_SQL : DAL_Abstract<Profile>
    {
        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        private const string LEVEL_0_LICENSE_NAME = "SUper User";

        private const string TABLE_LICENCES = "license";
        private const string TABLE_PROFILE_LICENSES = "profile_license";
        private const string TABLE_FAMILIES_LICENCES = "family_license";

        private const string COLUMN_LICENCES_ID = "id";
        private const string COLUMN_LICENCES_NAME = "name";
        private const string COLUMN_LICENCES_DESCRIPTION = "description";

        private const string COLUMN_PROFILE_LICENSES_ID_PROFILE = "id_profile";
        private const string COLUMN_PROFILE_LICENSES_ID_LICENSE = "id_license";

        private const string COLUMN_FAMILIES_LICENCES_MASTER = "id_family";
        private const string COLUMN_FAMILIES_LICENCES_SLAVE = "id_license";

        private static readonly string PARAM_COLUMN_FAMILIES_LICENSES_MASTER = $"@{COLUMN_FAMILIES_LICENCES_MASTER}";
        private static readonly string PARAM_COLUMN_FAMILIES_LICENSES_SLAVE = $"@{COLUMN_FAMILIES_LICENCES_SLAVE}";

        public void getProfileLicences(Profile profile)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string Query = $"SELECT {COLUMN_LICENCES_ID}, {COLUMN_LICENCES_NAME}, {COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" INNER JOIN {TABLE_PROFILE_LICENSES}" +
                                $" ON {TABLE_PROFILE_LICENSES}.{COLUMN_PROFILE_LICENSES_ID_LICENSE} = {TABLE_LICENCES}.{COLUMN_LICENCES_ID}" +
                                $" WHERE {TABLE_PROFILE_LICENSES}.{COLUMN_PROFILE_LICENSES_ID_PROFILE} = {profile.ProfileId}";

                using (sqlCommand = new SqlCommand(Query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            profile.Licences.Add(new Composite((int)sqlReader[0], sqlReader[1] as string, sqlReader[2] as string));
                        }
                    }
                }
            }
        }

        public bool hasChild(Component component)
        {
            bool hasChild = false;
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $" SELECT TOP 1 {TABLE_LICENCES}.{COLUMN_LICENCES_ID}, {TABLE_LICENCES}.{COLUMN_LICENCES_NAME}, {TABLE_LICENCES}.{COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" INNER JOIN {TABLE_FAMILIES_LICENCES}" +
                                $" ON {TABLE_FAMILIES_LICENCES}.{COLUMN_PROFILE_LICENSES_ID_LICENSE} = {TABLE_LICENCES}.{COLUMN_LICENCES_ID}" +
                                $" WHERE {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_MASTER} = {component.Id}";
                
                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        hasChild = true;
                    }
                }
            }
            return hasChild;
        }

        public Component findLIcenseById(int Id)
        {
            Component foundLicense = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $" SELECT {COLUMN_LICENCES_ID}, {COLUMN_LICENCES_NAME}, {COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" WHERE {TABLE_LICENCES}.{COLUMN_LICENCES_ID} = {Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            foundLicense = (new Composite((int)sqlReader[0], sqlReader[1] as string, sqlReader[2] as string));
                        }
                    }
                }
            }

            return foundLicense;
        }
        public List<Component> getAllLicenses(Component component)
        {
            List<Component> foundLicenses = new List<Component>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $" SELECT {COLUMN_LICENCES_ID}, {COLUMN_LICENCES_NAME}, {COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" INNER JOIN {TABLE_FAMILIES_LICENCES}" +
                                $" ON {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_SLAVE} = {TABLE_LICENCES}.{COLUMN_LICENCES_ID}" +
                                $" WHERE {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_MASTER} = {component.Id}";
                
                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            int id = (int) sqlReader["id"];
                            string name = (string) sqlReader["name"];
                            string description = (string) sqlReader["description"];
                            foundLicenses.Add(new Composite(id, name, description));
                            //foundLicenses.Add(new Composite((int)sqlReader[0], sqlReader[1] as string, sqlReader[2] as string));
                        }
                    }
                }
            }

            return foundLicenses;
        }

        public Component getLicenseTree()
        {
            Component foundLicenses = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $" SELECT {COLUMN_LICENCES_ID}, {COLUMN_LICENCES_NAME}, {COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" WHERE {TABLE_LICENCES}.{COLUMN_LICENCES_NAME} = '{LEVEL_0_LICENSE_NAME}'";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            int id = (int)sqlReader["id"];
                            string name = (string)sqlReader["name"];
                            string description = (string)sqlReader["description"];
                            foundLicenses = new Composite(id, name, description);
                            //foundLicenses = (new Composite((int)sqlReader[0], sqlReader[1] as string, sqlReader[2] as string));
                        }
                    }
                }
            }

            return foundLicenses;
        }

        public List<Component> getOrphanLicensesPool()
        {
            List<Component> licenses = new List<Component>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query =  $" SELECT {TABLE_LICENCES}.{COLUMN_LICENCES_ID}, {TABLE_LICENCES}.{COLUMN_LICENCES_NAME}, {TABLE_LICENCES}.{COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" WHERE" +
                                $"  NOT EXISTS (" +
                                $"      SELECT *" +
                                $"      FROM {TABLE_FAMILIES_LICENCES}" +
                                $"      WHERE {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_MASTER} = {TABLE_LICENCES}.{COLUMN_LICENCES_ID})" +
                                $" AND" +
                                $"  NOT EXISTS(" +
                                $"      SELECT *" +
                                $"      FROM {TABLE_FAMILIES_LICENCES}" +
                                $"      WHERE {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_SLAVE} = {TABLE_LICENCES}.{COLUMN_LICENCES_ID})";
                                

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            licenses.Add(new Composite((int)sqlReader[0], sqlReader[1] as string, sqlReader[2] as string));
                        }
                    }
                }
            }

            return licenses;
        }
        public void addRelationship(int master, int slave)
        {
            //Saving new relation [Master] -> [Slave]
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_FAMILIES_LICENCES} ({COLUMN_FAMILIES_LICENCES_MASTER}, {COLUMN_FAMILIES_LICENCES_SLAVE})" +
                                $" VALUES ({PARAM_COLUMN_FAMILIES_LICENSES_MASTER},{PARAM_COLUMN_FAMILIES_LICENSES_SLAVE})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_COLUMN_FAMILIES_LICENSES_MASTER, master);
                    sqlCommand.Parameters.AddWithValue(PARAM_COLUMN_FAMILIES_LICENSES_SLAVE, slave);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void removeRelationship(int master, int slave)
        {
            //Remove relation [Master] -> [Slave]
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE FROM {TABLE_FAMILIES_LICENCES}" +
                                $" WHERE {COLUMN_FAMILIES_LICENCES_MASTER} = {master} AND {COLUMN_FAMILIES_LICENCES_SLAVE} = {slave}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public Component getMasterLicense(Component license)
        {
            Component foundLicenses = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $" SELECT {COLUMN_LICENCES_ID}, {COLUMN_LICENCES_NAME}, {COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" INNER JOIN {TABLE_FAMILIES_LICENCES}" +
                                $" ON {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_MASTER} = {TABLE_LICENCES}.{COLUMN_LICENCES_ID}" +
                                $" WHERE {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_SLAVE} = {license.Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            foundLicenses = (new Composite((int)sqlReader[0], sqlReader[1] as string, sqlReader[2] as string));
                        }
                    }
                }
            }

            return foundLicenses;
        }

        public bool addNewLicense(Component license)
        {
            //Saving new License
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_LICENCES} ({COLUMN_LICENCES_NAME}, {COLUMN_LICENCES_DESCRIPTION})" +
                                $" VALUES ('{license.Name}','{license.Description}')";

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

        public bool removeLicense(Component license)
        {
            //Deleting existing orphan License
            bool success = false;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE FROM {TABLE_LICENCES}" +
                                $" WHERE {COLUMN_LICENCES_ID} = {license.Id}";

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

        public List<Component> getAllLicenses()
        {
            List<Component> licenses = new List<Component>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $" SELECT {TABLE_LICENCES}.{COLUMN_LICENCES_ID}, {TABLE_LICENCES}.{COLUMN_LICENCES_NAME}, {TABLE_LICENCES}.{COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}";


                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            licenses.Add(new Composite((int)sqlReader[0], sqlReader[1] as string, sqlReader[2] as string));
                        }
                    }
                }
            }

            return licenses;
        }

        public Profile Save(Profile Entity)
        {
            throw new NotImplementedException();
        }

        public IList<Profile> GetAll()
        {
            throw new NotImplementedException();
        }

        public Profile FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
