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
        public List<Component> Licenses;
        public User()
        {
            profileList = new List<Profile>();
            Licenses = new List<Component>();
        }

        public User( string username, string password, string email) : base()
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            Licenses = new List<Component>();
        }
        public User(object[] itemArray) : base()
        {
            this.Id = (int)itemArray[0];
            this.Username = (string)itemArray[1];
            this.Email = (string)itemArray[2];
            Licenses = new List<Component>();
        }

        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public int Attempts { get; set; }
        public string Password { get; set; }
        public IEquipo Equipo { get; set; }
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

        public List<Component> getAllLicenses()
        {
            List<Component> LicensesList = new List<Component>();
            LicensesList.AddRange(Licenses);

            foreach (Component component in Licenses)
            {
                LicensesList.AddRange(component.GetAllChildren());
            }
            return LicensesList;
        }
    }
}
