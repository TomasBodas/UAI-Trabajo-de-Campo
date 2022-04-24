using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.DAL
{
    public class DAL_User : ICrud<IUser>
    {
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IUser FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<IUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public IUser Save(IUser Entity)
        {
            throw new NotImplementedException();
        }
    }
}
