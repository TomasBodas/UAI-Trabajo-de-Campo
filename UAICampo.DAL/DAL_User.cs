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
        private DataSet userDataSet;
        private DataTable userDataTable;
        private DataTable passwordDataTable;

        public DAL_User()
        {
            userDataSet = new DataSet();
            userDataTable = new DataTable();
            passwordDataTable = new DataTable();


            //UserDataTable columns
            userDataTable.Columns.Add("id", typeof(int));
            userDataTable.Columns.Add("userName", typeof(string));
            userDataTable.Columns.Add("email", typeof(string));
            userDataTable.Columns.Add("isBlocked", typeof(bool));

            //PasswordDataTable columns
            passwordDataTable.Columns.Add("id", typeof(int));
            passwordDataTable.Columns.Add("passwordHash", typeof(string));

            userDataSet.Tables.Add(userDataTable);
            userDataSet.Tables.Add(passwordDataTable);

            //User testCaseUser = new User("TestUsername", "TestEmail", "7bcf9d89298f1bfae16fa02ed6b61908fd2fa8de45dd8e2153a3c47300765328");
            //testCaseUser.IsBlocked = false;
            //testCaseUser.Id = 1;
            //this.Save(testCaseUser);

            //Load tables from XML Files.
            loadFromXml(userDataTable, "UserDataTable.xml");
            loadFromXml(passwordDataTable, "PasswordDataTable.xml");
        }

        //Implemented and working
        public User findByUsername(string pUsername)
        {
            User user = null;
            foreach (DataRow row in userDataTable.Rows)
            {
                if (row["userName"].ToString() == pUsername)
                {
                    user = new User(row.ItemArray);
                }
            }
            return user;
        }
        public User Save(User Entity)
        {
            DataRow userNewRow = userDataTable.NewRow();
            DataRow passwordNewRow = passwordDataTable.NewRow();

            userNewRow["id"] = Entity.Id;
            userNewRow["email"] = Entity.Email;
            userNewRow["userName"] = Entity.Username;
            userNewRow["isBlocked"] = Entity.IsBlocked;

            passwordNewRow["id"] = Entity.Id;
            passwordNewRow["passwordHash"] = Entity.Password;

            userDataTable.Rows.Add(userNewRow);
            passwordDataTable.Rows.Add(passwordNewRow);

            saveToXml(userDataTable, "UserDataTable.xml");
            saveToXml(passwordDataTable, "PasswordDataTable.xml");

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

            if (serviceEncryption.HashComparer(inputPassword, storesPass))
            {
                matches = true;
            }
            return matches;
        }

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




        //Needs implementation
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public User FindById(int Id)
        {
            User foundUser;

            DataRow userRow = userDataTable.Rows.Find(Id);

            if (userRow.ItemArray != null)
            {
                foundUser =  new User(userRow.ItemArray);
            }
            else
            {
                foundUser =  null;
            }

            return foundUser;
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
