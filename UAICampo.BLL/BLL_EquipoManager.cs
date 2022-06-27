using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.BE;
using UAICampo.DAL;

namespace UAICampo.BLL
{
    public class BLL_EquipoManager
    {
        static DAL_Equipo_SQL equipoDal = new DAL_Equipo_SQL();
        public static Equipo createTeam(Equipo equipo)
        {
            return equipoDal.Save(equipo);
        }
        public static Equipo Update(Equipo entity)
        {
            return equipoDal.Update(entity);
        }

        public static Equipo FindById(int Id)
        {
            return equipoDal.FindById(Id);
        }

        public static Equipo FindByName(string name)
        {
            return equipoDal.FindByName(name);
        }
        public static bool ifExists(string nombre)
        {
            return equipoDal.ifExists(nombre);
        }
        public IList<Equipo> getAll()
        {
            return new DAL_Equipo_SQL().GetAll();
        }
    }
}
