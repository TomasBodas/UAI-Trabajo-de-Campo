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
    public class BLL_UserManager
    {

        public void createUser(string username, string password, string email)
        {
            User user = new User(username, password, email);
            DAL_User dal = new DAL_User();
            if (dal.findByUsername(username) != null)
            {
                dal.Save(user);
                //actualiza la DV

                //bitacora: Usuario creado
            }
            else
            {
                //ya existe
            }
        }
    }
}
