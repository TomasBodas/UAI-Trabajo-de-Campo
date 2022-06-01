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
    public class DAL_Licences_SQL : DAL_Abstract
    {
        private static readonly string CONNECTION_STRING = "Data Source=.;Initial Catalog=Campo;Integrated Security=True";

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;


        private const string TABLE_LICENCES = "Licenses";
        private const string TABLE_PROFILE_LICENSES = "Profile_License";
        private const string TABLE_FAMILIES_LICENCES = "Family_License";

        private const string COLUMN_LICENCES_ID = "Id";
        private const string COLUMN_LICENCES_NAME = "Name";
        private const string COLUMN_LICENCES_DESCRIPTION = "Description";

        private const string COLUMN_PROFILE_LICENSES_ID_PROFILE = "IdProfile";
        private const string COLUMN_PROFILE_LICENSES_ID_LICENSE = "IdLicense";

        private const string COLUMN_FAMILIES_LICENCES_MASTER = "IdFamily";
        private const string COLUMN_FAMILIES_LICENCES_SLAVE = "IdLicense";

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

                string query = $" SELECT TOP 1 {COLUMN_LICENCES_ID}, {COLUMN_LICENCES_NAME}, {COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" INNER JOIN {TABLE_FAMILIES_LICENCES}" +
                                $" ON {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_MASTER} = {TABLE_LICENCES}.{COLUMN_LICENCES_ID}" +
                                $" INNER JOIN {TABLE_FAMILIES_LICENCES}" +
                                $" ON {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_SLAVE} = {TABLE_LICENCES}.{COLUMN_LICENCES_ID}" +
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

        public List<Component> getAllLicenses(Component component)
        {
            List<Component> foundLicenses = new List<Component>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $" SELECT {COLUMN_LICENCES_ID}, {COLUMN_LICENCES_NAME}, {COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" INNER JOIN {TABLE_FAMILIES_LICENCES}" +
                                $" ON {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_MASTER} = {TABLE_LICENCES}.{COLUMN_LICENCES_ID}" +
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
                            foundLicenses.Add(new Composite((int)sqlReader[0], sqlReader[1] as string, sqlReader[2] as string));
                        }
                    }
                }
            }

            return foundLicenses;
        }

    }
}
