using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Abstractions
{
    public interface ICrud<T>
    {
        T Save(T Entity);
        IList<T> GetAll();
        T FindById(int Id);
        void Delete(int Id);
    }
}
