using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services
{
    public class User : IUser
    {
        public User(){}
        public User(object[] itemArray) : base()
        {
            this.Id = (int)itemArray[0];
            this.Username = (string)itemArray[1];
            this.Email = (string)itemArray[2];
            this.IsBlocked = (bool)itemArray[3];
        }
        public User(int id, string pUsername, string pEmail, bool pIsBlocked) : base()
        {
            this.Id = id;
            this.Username = pUsername;
            this.Email = pEmail;
            this.IsBlocked = pIsBlocked;
        }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
    }
}
