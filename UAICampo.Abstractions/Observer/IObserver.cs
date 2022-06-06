using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Abstractions.Observer
{
    public interface IObserver
    {
        void Update(ILanguage l);
    }
}
