using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.DAL;
using UAICampo.Services;

namespace UAICampo.BLL
{
    public class BLL_SessionManager
    {
        public void Login(String userName, string password )
        {
            IUser user = 
            DAL_User dalUser = new DAL_User();
            IUser user = null;

            user = dalUser.findByUsername(userName);

            if (user != null)
            {
                SessionManager sm = new SessionManager();
                if (encrypt(user.pass, password))
                {
                    var userInstance = UserInstance.getInstance();
                    if (userInstance.userIsLoggedIn())
                    {
                        userInstance.user = user;
                    }
                    
                }
                else
                {
                    //la cont es incorrecta, volve a intentarlo
                }
                
            }
            else
            {
               //error
            }
        }
    }
}
