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
        DAL_Equipo_SQL equipoDal = new DAL_Equipo_SQL();
        public Equipo createTeam(string name)
        {
            Equipo equipo = new Equipo();
            equipo.Name = name;

            return equipoDal.Save(equipo);
        }

        public IList<Equipo> getAll()
        {
            return new DAL_Equipo_SQL().GetAll();
        }
    }
}
