using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.DAL;
using UAICampo.Services;
using Microsoft.VisualBasic;
using UAICampo.DAL.SQL;

namespace UAICampo.BLL
{
    public class BLL_UserManager
    {
        public IUser createUser(string username, string password, string email)
        {
            //Instantiate new user to be saved
            User user = new User(username, password, email);

            //XML Dal Connection
            //DAL_User dal = new DAL_User();

            //SQL Connection
            DAL_User_SQL dal = new DAL_User_SQL();

            if (dal.findByUsername(username) == null)
            {
                //if user is successfully created, it will return an instance of the user
                user = dal.Save(user);

                BLL_LogManager.addMessage(new Log
                {
                    Date = DateTime.Now,
                    Code = "USER_CREATED",
                    Description = String.Format("Account {0} created successfully", user.Username),
                    Type = LogType.Control,
                    User = user
                });
            }
            else
            {
                //if user is not created it will return a null user
                user = null;
                Interaction.MsgBox("Username already exists");
                BLL_LogManager.addMessage(new Log
                {
                    Date = DateTime.Now,
                    Code = "USERNAME_ERROR",
                    Description = String.Format("Username already exists"),
                    Type = LogType.Warning,
                    User = user
                });
            }

            return user;
        }
    }
}
