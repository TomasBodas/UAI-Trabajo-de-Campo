using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.DAL
{
    public interface DAL_Abstract<T> : ICrud<T> where T:IEntity
    {
    }
}
