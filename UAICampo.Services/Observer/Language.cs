using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions.Observer;

namespace UAICampo.Services.Observer
{
   
     public class Language : ILanguage , ISubjectLanguage
    {
        public string Name { get; set; }

        private List<IObserverUser> users;
        public void Add(IObserverUser user)
        {
            if (users.Contains(user))
            {
                users.Add(user);
            }
            else
            {
                Interaction.MsgBox("");
            }
        }

        public void Notification()
        {
            foreach (var user in users)
            {
                user.Update(this);
            }

            if (users.Count == 0)
            {
                Interaction.MsgBox("");
            }
        }

        public void Remove(IObserverUser user)
        {
            if (users.Contains(user))
            {
                users.Remove(user);
            }
            else
            {
                Interaction.MsgBox("");
            }
        }
    }
}
