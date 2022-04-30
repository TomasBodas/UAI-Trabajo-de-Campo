using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.Services;

namespace UAICampo.DAL
{
    public class DAL_User : DAL_Abstract<User>
    {
        private static Encrypt ENCRYPTION_SERVICE;

        private DataSet userDataSet;
        private DataTable userDataTable;
        private DataTable passwordDataTable;
        private DataTable userStatusDataTable;

        public DAL_User()
        {
            ENCRYPTION_SERVICE = new Encrypt();
            userDataSet = new DataSet();
            userDataTable = new DataTable();
            passwordDataTable = new DataTable();
            userStatusDataTable = new DataTable();


            //UserDataTable columns
            userDataTable.Columns.Add("id", typeof(int));
            userDataTable.Columns.Add("userName", typeof(string));
            userDataTable.Columns.Add("email", typeof(string));

            //PasswordDataTable columns
            passwordDataTable.Columns.Add("id", typeof(int));
            passwordDataTable.Columns.Add("passwordHash", typeof(string));

            //UserStatus columns
            userStatusDataTable.Columns.Add("id", typeof(int));
            userStatusDataTable.Columns.Add("isBlocked", typeof(bool));
            userStatusDataTable.Columns.Add("attempts", typeof(int));

            //Tables added to dataSet
            userDataSet.Tables.Add(userDataTable);
            userDataSet.Tables.Add(passwordDataTable);
            userDataSet.Tables.Add(userStatusDataTable);

            //Load tables from XML Files.
            loadFromXml(userDataTable, "UserDataTable.xml");
            loadFromXml(passwordDataTable, "PasswordDataTable.xml");
            loadFromXml(userStatusDataTable, "UserStatusDataTable.xml");
        }


        //Implemented and working
        public User findByUsername(string pUsername)
        {
            User user = null;

            //First search user by username --> userDataTable
            foreach (DataRow userRow in userDataTable.Rows)
            {
                if (userRow["userName"].ToString() == pUsername)
                {
                    user = new User(userRow.ItemArray);

                    //Then match id with found user --> userStatusDataTable
                    foreach (DataRow statusRow in userStatusDataTable.Rows)
                    {
                        if ((int)statusRow["id"] == user.Id)
                        {
                            user.IsBlocked = (bool)statusRow["isBlocked"];
                            user.Attempts = (int)statusRow["attempts"];
                        }
                    }
                }
            }

            return user;
        }
        public User Save(User Entity)
        {
            //sets next ID
            Entity.Id = this.getNextUserId();
            Entity.IsBlocked = false;
            Entity.Attempts = 0;
            Entity.Password = ENCRYPTION_SERVICE.hashRetriever(Entity.Password);

            //New rows for each table involved in method
            DataRow userNewRow = userDataTable.NewRow();
            DataRow passwordNewRow = passwordDataTable.NewRow();
            DataRow userStatusNewRow = userStatusDataTable.NewRow();

            //Setting up userDataTable row
            userNewRow["id"] = Entity.Id;
            userNewRow["email"] = Entity.Email;
            userNewRow["userName"] = Entity.Username;

            //Setting up passwordDataTable row
            passwordNewRow["id"] = Entity.Id;
            passwordNewRow["passwordHash"] = Entity.Password;

            //Setting up userStatusDataTable row
            //New accounts are created unblocked and with zero attempts
            userStatusNewRow["id"] = Entity.Id;
            userStatusNewRow["isBlocked"] = Entity.IsBlocked;
            userStatusNewRow["attempts"] = Entity.Attempts;

            userDataTable.Rows.Add(userNewRow);
            passwordDataTable.Rows.Add(passwordNewRow);
            userStatusDataTable.Rows.Add(userStatusNewRow);

            saveToXml(userDataTable, "UserDataTable.xml");
            saveToXml(passwordDataTable, "PasswordDataTable.xml");
            saveToXml(userStatusDataTable, "UserStatusDataTable.xml");

            return Entity;
        }
        public bool userPasswordMatcher(int pId, string inputPassword)
        {
            bool matches = false;
            string storesPass = "";

            foreach (DataRow row in passwordDataTable.Rows)
            {
                if ((int)row["id"] == pId)
                {
                    storesPass = row["passwordHash"].ToString();
                }
            }

            Encrypt serviceEncryption = new Encrypt();

            if (serviceEncryption.hashComparer(inputPassword, storesPass))
            {
                matches = true;
            }
            return matches;
        }
        public void UpdateUserStatus(User Entity)
        {
            //userStatusDataTable update
            foreach (DataRow row in userStatusDataTable.Rows)
            {
                if ((int)row["id"] == Entity.Id)
                {
                    row["isBlocked"] = Entity.IsBlocked;
                    row["attempts"] = Entity.Attempts;
                }
            }
            saveToXml(userStatusDataTable, "UserStatusDataTable.xml");
        }
        private int getNextUserId()
        {
            int id = 0;
            foreach (DataRow row in userDataTable.Rows)
            {
                if ((int)row["id"] > id)
                {
                    id = (int)row["id"];
                }
            }
            return id+1;
        }
        public User FindById(int Id)
        {
            User user = null;

            //First search user by username --> userDataTable
            foreach (DataRow userRow in userDataTable.Rows)
            {
                if ((int)userRow["id"] == Id)
                {
                    user = new User(userRow.ItemArray);

                    //Then match id with found user --> userStatusDataTable
                    foreach (DataRow statusRow in userStatusDataTable.Rows)
                    {
                        if ((int)statusRow["id"] == user.Id)
                        {
                            user.IsBlocked = (bool)statusRow["isBlocked"];
                            user.Attempts = (int)statusRow["attempts"];
                        }
                    }
                }
            }

            return user;
        }

        #region xml persistance
        //Save DataTable to XML
        private void saveToXml(DataTable pDataTable, string fileName)
        {
            pDataTable.WriteXml(fileName, XmlWriteMode.WriteSchema);
        }

        //Load XML into DataTable
        private void loadFromXml(DataTable table, string fileName)
        {
            if (File.Exists(fileName))
            {
                table.ReadXml(fileName);
            }
        }
        #endregion


        //Needs implementation
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public IList<User> GetAll()
        {
            IList<User> userList = new List<User>();

            foreach (DataRow row in userDataTable.Rows)
            {
                User user = new User(row.ItemArray);
                userList.Add(user);
            }
            return userList;
        }
    }
}
