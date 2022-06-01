using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Services.Composite;

namespace UAICampo.DAL
{
    public class DAL_Licences_SQL : DAL_Abstract
    {
        private static readonly string CONNECTION_STRING = "Data Source=.;Initial Catalog=Campo;Integrated Security=True";

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;


        private const string TABLE_LICENCES = "Licences";
        private const string TABLE_PROFILE_LICENCES = "Profile_Licences";
        private const string TABLE_FAMILIES_LICENCES = "Families_Licences";

        private const string COLUMN_LICENCES_ID = "Id";
        private const string COLUMN_LICENCES_CODE = "Code";
        private const string COLUMN_LICENCES_NAME = "Name";
        private const string COLUMN_LICENCES_DESCRIPTION = "Description";

        private const string COLUMN_FAMILIES_LICENCES_MASTER = "Master";
        private const string COLUMN_FAMILIES_LICENCES_SLAVE = "Slave";

        public void getLicences(int profileId)
        {
            //First retrieve the top level licence for this user-------------------------------------------
            Component TopLevelComponent;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_LICENCES_ID}, {COLUMN_LICENCES_CODE}, {COLUMN_LICENCES_NAME}, {COLUMN_LICENCES_DESCRIPTION}" +
                                $" FROM {TABLE_LICENCES}" +
                                $" INNER JOIN {TABLE_FAMILIES_LICENCES}" +
                                $" ON {TABLE_LICENCES}.{COLUMN_LICENCES_ID} = {TABLE_FAMILIES_LICENCES}.{COLUMN_FAMILIES_LICENCES_MASTER}" +
                                $" WHERE {TABLE_FAMILIES_LICENCES}.{COLU}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            
                        }
                    }

                    sqlReader.Close();
                }
            }
            

        }

        //Parametro = ProfileId
        //SELECT * FROM LICENCES
        //INNER JOIN Profile_LICENCES ON Profile_LICENCES.ID = userId
        //WHERE USER_LICENES.ID = ID
        //Una licencia


        //WHILE(LIST != 0)
        //LIST<Licences>
        //FOREACHJ(Licence)
        //{
        //SELECT * FROM Licences
        //INNER JOIN FAMILIES_LICENCES ON MASTAer = LicenciaID
        //WHERE Licences.id = FAMILIES_LIcences.Slave
        //List<Licences>

        //Liincese.addChild(Licence)
        //}

        // retornar a la bll LIST<Licences>

    }
}
