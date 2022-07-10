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
    public class DAL_Address_SQL
    {
        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        private const string TABLE_userStatus = "accountStatus";
        private const string TABLE_address = "UserAdress";
        private const string TABLE_provinces = "Provinces";

        //user address table columns
        private const string COLUMN_ADDRESS_ADDRESS1 = "Address1";
        private const string COLUMN_ADDRESS_ADDRESS2 = "Address2";
        private const string COLUMN_ADDRESS_ADDRESSNumber = "AddressNumber";
        private const string COLUMN_ADDRESS_FK_City = "FK_City";
        private const string COLUMN_ADDRESS_FK_Province = "FK_Province";
        private const string COLUMN_ADDRESS_FK_Account = "FK_Account";
        private static readonly string PARAM_ADDRESS_ADDRESS1 = $"@{COLUMN_ADDRESS_ADDRESS1}";
        private static readonly string PARAM_ADDRESS_ADDRESS2 = $"@{COLUMN_ADDRESS_ADDRESS2}";
        private static readonly string PARAM_ADDRESS_ADDRESSNumber = $"@{COLUMN_ADDRESS_ADDRESSNumber}";
        private static readonly string PARAM_ADDRESS_FK_City = $"@{COLUMN_ADDRESS_FK_City}";
        private static readonly string PARAM_ADDRESS_FK_Province = $"@{COLUMN_ADDRESS_FK_Province}";
        private static readonly string PARAM_ADDRESS_FK_ACCOUNT = $"@{COLUMN_ADDRESS_FK_Account}";

        //Provinces table columns
        private const string COLUMN_PROVINCES_ID = "Id";
        private const string COLUMN_PROVINCES_NAME = "name";
        private static readonly string PARAM_PROVINCES_ID = $"@{COLUMN_PROVINCES_ID}";
        private static readonly string PARAM_PROVINCES_NAME = $"@{COLUMN_PROVINCES_NAME}";

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        public List<Province> getProvincesList()
        {
            List<Province> provinces = new List<Province>();

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_provinces}.{COLUMN_PROVINCES_ID}, {TABLE_provinces}.{COLUMN_PROVINCES_NAME}" +
                                $" FROM {TABLE_provinces}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            int id = (int)sqlReader["Id"];
                            string name = (string)sqlReader["name"];
                            provinces.Add(new Province(id, name));
                        }
                    }
                    sqlReader.Close();
                }
            }

            return provinces;
        }
        
    }
}
