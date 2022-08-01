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

        public static List<Tarea> getTasksByTeam(Equipo eq)
        {
            return dalTareas.getTasksByTeam(eq);
        }
        public static List<Tarea> getTasksByUser(Equipo eq, User user)
        {
            return dalTareas.getTasksByUser(eq, user);
        }

        public static Tarea Save(Tarea tarea)
        {
            return dalTareas.Save(tarea);
        }

        public static bool archive(Tarea tarea)
        {
            return dalTareas.archive(tarea);
        }

        public static Epica SaveEpic(Epica e)
        {
            return dalTareas.SaveEpic(e);
        }
        public static Tarea FindById(int id)
        {
            return dalTareas.FindById(id);
        }
        public static List<Epica> getAllEpics()
        {
            return dalTareas.getAllEpics();
        }

        public static bool assignMember(Tarea tarea, int userId)
        {
            IUser user = getUserTask(tarea);
            if (user.Id != 0)
            {
                return false;
            }

            bool result = dalTareas.assignMember(tarea.Title, userId);

            if (result)
            {
                tarea.User = new User
                {
                    Id = userId
                };
            }
            return result;
        }

        public static IUser getUserTask(Tarea tar)
        {
            if (tar.User == null)
            {
                tar.User = dalTareas.getUserTask(tar);
            }

            return tar.User;
        }
        public static List<Tarea> getUnfinished(User us)
        {
            return dalTareas.getUnfinished(us);
        }
    }
}
