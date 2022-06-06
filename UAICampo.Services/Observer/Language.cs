using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions.Observer;

namespace UAICampo.Services.Observer
{
   
     public class Language : ILanguage
    {
        public string Name { get; set; }
        public Dictionary<string, string> words = new Dictionary<string, string>();

        #region subjectcommented
        //private List<IObserver> users = new List<IObserver>();
        //public void Add(IObserver user)
        //{
        //    if (users.Contains(user))
        //    {
        //        users.Add(user);
        //    }
        //    else
        //    {
        //        Interaction.MsgBox("");
        //    }
        //}

        //public void Notification()
        //{
        //    foreach (var user in users)
        //    {
        //        user.Update(this);
        //    }

        //    if (users.Count == 0)
        //    {
        //        Interaction.MsgBox("");
        //    }
        //}

        //public void Remove(IObserverUser user)
        //{
        //    if (users.Contains(user))
        //    {
        //        users.Remove(user);
        //    }
        //    else
        //    {
        //        Interaction.MsgBox("");
        //    }
        //}
        #endregion

        private static Language _instance;
        public static Language getInstance()
        {
            if (_instance == null)
            {
                _instance = new Language();
            }

            return _instance;
        }

        public string translate(string key)
        {
            if (this.words.ContainsKey(key))
            {
                string word = this.words[key];

                if (word != "")
                    return this.words[key];
                else
                    return key;
            }
            else
            {
                return key;
            }
        }


    }
}
