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

        public User( string username, string password, string email) : base()
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
        public User(object[] itemArray) : base()
        {
            this.Id = (int)itemArray[0];
            this.Username = (string)itemArray[1];
            this.Email = (string)itemArray[2];
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public int Attempts { get; set; }
        public string Password { get; set; }
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
