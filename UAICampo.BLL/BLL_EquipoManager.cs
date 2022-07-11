using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.BE;
using UAICampo.DAL;
using UAICampo.Services;

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

        public static List<KeyValuePair<IProfile, IUser>> getTeam(Equipo entity)
        {
            if (entity.puestos == null || entity.puestos.Count == 0)
            {
                entity.puestos = equipoDal.getTeam(entity);
            }
            return entity.puestos;
        }

        public static Equipo FindById(int Id)
        {
            return equipoDal.FindById(Id);
        }
        public void Delete(int id)
        {
            equipoDal.DeleteMembers(id);
            equipoDal.Delete(id);
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

        public static IEquipo getUserTeam(User us)
        {
            if (us.Equipo == null)
            {
                us.Equipo = equipoDal.getUserTeam(us.Id);
            }
            return us.Equipo;
        }

        public List<User> getMembers(IEquipo eq)
        {
            return equipoDal.getMembers(eq.Id);
        }
    }
}
