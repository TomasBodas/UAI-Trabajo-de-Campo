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

        public User( string username, string email, string password) : base()
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }
        public User(object[] itemArray) : base()
        {
            this.Id = (int)itemArray[0];
            this.Username = (string)itemArray[1];
            this.Email = (string)itemArray[2];
            //this.Password = (string)itemArray[2];
            //this.IsBlocked = (bool)itemArray[4];
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
        public string Password { get; set; }
    }
}
