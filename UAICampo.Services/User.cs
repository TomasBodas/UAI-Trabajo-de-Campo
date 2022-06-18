using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions.Observer;
using UAICampo.Services.Composite;
using UAICampo.Abstractions;
using UAICampo.Services.Observer;

namespace UAICampo.Services
{
    public class User : IUser, ISubject
    {
        public List<Profile> profileList;
        public User()
        {
            profileList = new List<Profile>();
        }

        public User( string username, string email, string password) : base()
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }
        public User(string username, string password, string email,  string name, string lastName, DateTime birthdate, int dni) : base()
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.Name = name;
            this.LastName = lastName;
            this.Birthdate = birthdate;
            this.Dni = dni;
        }
        public User(object[] itemArray) : base()
        {
            this.Id = (int)itemArray[0];
            this.Username = (string)itemArray[1];
            this.Email = (string)itemArray[2];
            this.Name = (string)itemArray[3];
            this.LastName = (string)itemArray[4];
            this.Birthdate = (DateTime)itemArray[5];
            this.Dni = (int)itemArray[6];
        }
        

        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public int Attempts { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int Dni { get; set; }


        public IList<Component> Licenses { get; set; }
        public Language language { get; set; }

        public List<IObserver> subscribers = new List<IObserver>();

        public void Add(IObserver observer)
        {
            if (!subscribers.Contains(observer))
            {
                subscribers.Add(observer);
            }
        }

        public void Remove(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notification()
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Update();
            }
        }
    }
}
