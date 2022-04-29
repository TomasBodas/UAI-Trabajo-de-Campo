using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.DAL
{
    public abstract class DAL_Abstract<T> : ICrud<T> where T:IEntity
    {
        protected IList<T> dataContext;
        public DAL_Abstract()
        {
            dataContext = new List<T>();
        }

        public void Delete(T entity)
        {
            this.dataContext.Remove(entity);
        }

        public IList<T> GetAll()
        {
            return dataContext;
        }

        public T FindById(int id)
        {
            return dataContext.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public void Save(T entity)
        {
            if (dataContext.Contains(entity))
            {
                //si no fuesen objetos, habria que invocar la forma de actualizar el dato en el entorno de persistencia
            }
            else
            {
                dataContext.Add(entity);
            }

        }
    }
}
