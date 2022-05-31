using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Abstractions.Observer
{
    public interface ISubjectLanguage
    {
        void Add(IObserverUser user);
        void Remove(IObserverUser user);
        void Notification();
    }
}
