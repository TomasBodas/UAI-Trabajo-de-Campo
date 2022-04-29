using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services
{
    public class Service_Login
    {
        public IUser User;

        public Service_Login( IUser pUser)
        {
            this.User = pUser;
        }

    }
}
