using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.BE;
using UAICampo.DAL;
using UAICampo.Services;

namespace UAICampo.BLL
{
    public static class BLL_TareasManager
    {
       static DAL_Tareas_SQL dalTareas = new DAL_Tareas_SQL();

        public static List<Tarea> getFinished(User us)
        {
            return dalTareas.getFinished(us);

        }

        public static List<Tarea> getAccomplished(User us)
        {
            return dalTareas.getAccomplished(us);
        }

        public static List<Tarea> getUnfinished(User us)
        {
            return dalTareas.getUnfinished(us);
        }
    }
}
