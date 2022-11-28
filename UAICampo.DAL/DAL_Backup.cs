
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Services;

namespace UAICampo.DAL
{
    public class DAL_Backup
    {
        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        public string getTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMdd");
        }

        public bool Backup(string filename)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    sqlConnection.Open();

                    string query = $"BACKUP DATABASE Campo TO DISK = '{filename}'";

                    using (sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    User user = UserInstance.getInstance().user;
                    SessionManager sm = new SessionManager();
                    DAL_Log dal_log = new DAL_Log();
                    dal_log.Save(new Log
                    {
                        Date = DateTime.Now,
                        Code = "BACKUP_CREATED",
                        Description = String.Format("Backup created"),
                        Type = LogType.Control,
                        User = user.Id
                    });
                    return true;
                }
                catch(Exception e)
                {

                    User user = UserInstance.getInstance().user;
                    SessionManager sm = new SessionManager();
                    DAL_Log dal_log = new DAL_Log();
                    dal_log.Save(new Log
                    {
                        Date = DateTime.Now,
                        Code = "BACKUP_ERROR",
                        Description = String.Format("Backup failed"),
                        Type = LogType.Error,
                        User = user.Id
                    });
                    return false;
                }
            }
        }

        public bool Restore(string filename)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    SqlCommand singleUser = new SqlCommand("ALTER DATABASE Campo SET Single_User WITH Rollback Immediate", sqlConnection);
                    SqlCommand query = new SqlCommand("USE master; RESTORE DATABASE Campo FROM DISK = @bkpPath WITH REPLACE;", sqlConnection);
                    SqlCommand multiUser = new SqlCommand("ALTER DATABASE Campo SET Multi_User", sqlConnection);

                    query.Parameters.AddWithValue("@bkpPath", filename);

                    sqlConnection.Open();
                    singleUser.ExecuteNonQuery();
                    query.ExecuteNonQuery();
                    multiUser.ExecuteNonQuery();
                    sqlConnection.Close();

                    User user = UserInstance.getInstance().user;
                    SessionManager sm = new SessionManager();
                    DAL_Log dal_log = new DAL_Log();
                    dal_log.Save(new Log
                    {
                        Date = DateTime.Now,
                        Code = "RESTORE_DATABASE",
                        Description = String.Format("Database restored"),
                        Type = LogType.Control,
                        User = user.Id
                    });
                    return true;
                }
                catch (Exception e)
                {
                    User user = UserInstance.getInstance().user;
                    SessionManager sm = new SessionManager();
                    DAL_Log dal_log = new DAL_Log();
                    dal_log.Save(new Log
                    {
                        Date = DateTime.Now,
                        Code = "RESTORE_ERROR",
                        Description = String.Format("Restore error"),
                        Type = LogType.Error,
                        User = user.Id
                    });
                    return false;
                }
            }
        }
    }
}
