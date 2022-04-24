using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Services
{
    public class User
    {
        public User()
        {

        }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
    }
}
