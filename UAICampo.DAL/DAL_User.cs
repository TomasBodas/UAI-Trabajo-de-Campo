using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.Services;

namespace UAICampo.DAL
{
    public class DAL_User : DAL_IDAL<User>
    {
        private DataSet userDataSet;
        private DataTable userDataTable;

        public DAL_User()
        {
            userDataSet = new DataSet();
            userDataTable = new DataTable();

            userDataTable.Columns.Add("userName", typeof(string));
            userDataTable.Columns.Add("email", typeof(string));
            userDataTable.Columns.Add("isBlocked", typeof(bool));
            userDataTable.Columns.Add("guid", typeof(string));

            userDataSet.Tables.Add(userDataTable);
        }


        #region CRUD Operations
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

        public User Save(User Entity)
        {
            DataRow newRow = userDataTable.NewRow();
            newRow["guid"] = Entity.Id;
            newRow["email"] = Entity.Email;
            newRow["userName"] = Entity.Username;
            newRow["isBlocked"] = Entity.IsBlocked;
            saveToXml(userDataTable);
            return Entity;
        }
        #endregion

         public IUser findByUsername(string pUsername)
         {
            IUser user = null;
            foreach (DataRow row in userDataTable.Rows )
            {
                if(row["userName"].ToString() == pUsername)
                {
                   user = new User(row.ItemArray); 
                }
            }
            return user;
        }

        public bool userPasswordMatcher(int pId, string inputPassword)
        {
            bool matches = false;
            string storesPass = "";

            Encrypt serviceEncryption = new Encrypt();

            if (serviceEncryption.HashComparer(inputPassword, storesPass))
            {
                matches = true;   
            }
            return matches;
        }

        private void saveToXml(DataTable pDataTable)
        {
            pDataTable.WriteXml("UserDataTable", XmlWriteMode.WriteSchema);
        }
    }
}
