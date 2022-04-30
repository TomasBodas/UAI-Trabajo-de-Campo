using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.DAL;
using UAICampo.Services;
using Microsoft.VisualBasic;

namespace UAICampo.BLL
{
    public class BLL_UserManager
    {
        public IUser createUser(string username, string password, string email)
        {
            //Instantiate new user to be saved
            User user = new User(username, password, email);
            DAL_User dal = new DAL_User();

            if (dal.findByUsername(username) == null)
            {
                //if user is successfully created, it will return an instance of the user
                user = dal.Save(user);
            }
            else
            {
                //if user is not created it will return a null user
                user = null;
            }

            return user;
        }
    }
}
