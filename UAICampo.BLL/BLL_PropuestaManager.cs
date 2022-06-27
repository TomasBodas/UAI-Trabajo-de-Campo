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
    public static class BLL_PropuestaManager
    {
        static DAL_Propuesta_SQL propuestaDAL = new DAL_Propuesta_SQL();

        public static List<UserPropuesto> GetPropuesta(Equipo equipo, int cant,int level, IProfile profile = null)
        {
            var users = propuestaDAL.GetForPosition();

            foreach (var usuarioPropuesto in users)
            {
                usuarioPropuesto.PorcentajeObjetivosCumplidos = Math.Round(calcularCumplidos(usuarioPropuesto), 2);
                usuarioPropuesto.PromedioReconocimiento = Math.Round(calcularReconocimiento(usuarioPropuesto), 2);
                usuarioPropuesto.PromedioReconocimientoDeSuperiores = Math.Round(calcularReconocimientoSuperiores(usuarioPropuesto), 2);
                usuarioPropuesto.CantidadReconocimientos = calcularCantidadReconocimientos(usuarioPropuesto);
                usuarioPropuesto.CantidadObjetivosNoCumplidos = calcularCantidadNoCumplidos(usuarioPropuesto);

                calculation(usuarioPropuesto, profile);
            }

            ordenarRank(users, cant, level);
            return users;
        }

        public static UserPropuesto GetSpecific(string name, IProfile profile = null)
        {
            var usuarioPropuesto = propuestaDAL.FindByUsername(name);
            usuarioPropuesto.PorcentajeObjetivosCumplidos = Math.Round(calcularCumplidos(usuarioPropuesto), 2);
            usuarioPropuesto.PromedioReconocimiento = Math.Round(calcularReconocimiento(usuarioPropuesto), 2);
            usuarioPropuesto.PromedioReconocimientoDeSuperiores = Math.Round(calcularReconocimientoSuperiores(usuarioPropuesto), 2);
            usuarioPropuesto.CantidadReconocimientos = calcularCantidadReconocimientos(usuarioPropuesto);
            usuarioPropuesto.CantidadObjetivosNoCumplidos = calcularCantidadNoCumplidos(usuarioPropuesto);

                calculation(usuarioPropuesto, profile);

            return usuarioPropuesto;
        }

        static double calcularCumplidos(UserPropuesto us)
        {
            var objetivosFinalizados = BLL_TareasManager.getFinished(us).Count;
            var objetivosCumplidos = BLL_TareasManager.getAccomplished(us).Count;

            return objetivosFinalizados > 0 ? (objetivosCumplidos * 100) / objetivosFinalizados : 0;
        }


        static double calcularCantidadNoCumplidos(User us)
        {
            return BLL_TareasManager.getUnfinished(us).Count;
        }

        static double calcularReconocimiento(UserPropuesto us)
        {
            var reconocimientos = BLL_ReconocimientoManager.getReceived(us);
            var sumNivel = 0;
            foreach (Reconocimiento reconocimiento in reconocimientos)
            {
                sumNivel += reconocimiento.Value;
            }
            return reconocimientos.Count > 0 ? sumNivel / reconocimientos.Count : 0;
        }

        static double calcularReconocimientoSuperiores(UserPropuesto us)
        {
            var reconocimientos = BLL_ReconocimientoManager.getReceivedSuperiors(us);
            var sumNivel = 0;
            foreach (Reconocimiento reconocimiento in reconocimientos)
            {
                sumNivel += reconocimiento.Value;
            }
            return reconocimientos.Count > 0 ? sumNivel / reconocimientos.Count : 0;
        }
        static int calcularCantidadReconocimientos(User us)
        {
            return BLL_ReconocimientoManager.getLastReceived(us).Count;
        }

        static public double calculation(UserPropuesto us, IProfile profile = null)
        {
            double valor = -(us.CantidadObjetivosNoCumplidos * 0.05);
            valor += us.CantidadReconocimientos * 0.1;
            
                valor += us.PromedioReconocimientoDeSuperiores * 0.3;
                valor += us.PorcentajeObjetivosCumplidos * 0.25;
                valor += us.PromedioReconocimiento * 0.05;

            if (profile != null && BLL_UserManager.getUserProfile(us).ProfileId == profile.ProfileId)
            {
                valor += 20;
            }

            us.ValorTotal = System.Math.Round(valor, 2);

            return us.ValorTotal;
        }

        static public void ordenarRank(List<UserPropuesto> us, int cant, int level)
        {
            us.Sort(delegate (UserPropuesto x, UserPropuesto y)
            {
                if (x.ValorTotal == 0 && y.ValorTotal == 0) return 0;
                else if (x.ValorTotal == 0) return 1;
                else if (y.ValorTotal == 0) return -1;
                else return x.ValorTotal > y.ValorTotal ? -1 : 1;
            });
             int first = level == 1 ? 0 : (level - 1) * cant;

            if (cant > us.Count) {
                cant = us.Count;
            }

            if (first + cant > us.Count) {
                first = us.Count - cant;
            }

            var result = us.GetRange(first, cant);
            us.Clear();

            foreach(UserPropuesto up in result) {
                us.Add(up);
			}

            us = result;
        }

        static public void proposeTeam(Equipo eq, int level)
        {
            foreach (KeyValuePair<IProfile, IUser> position in eq.puestos.ToList())
            {
                if (position.Value == null)
                {
                    List<UserPropuesto> newUserList = GetPropuesta(eq, 1,level, position.Key);

                    if (newUserList.Count == 0)
                    {
                        continue;
                    }

                    Profile newPuesto = BLL_UserManager.getProfileById(eq.puestos.FindAll(p => p.Key == position.Key && p.Value == null)[0].Key.ProfileId);

                    eq.puestos.Remove(eq.puestos.FindAll(p => p.Key == position.Key && p.Value == null)[0]);
                    eq.puestos.Add(new KeyValuePair<IProfile, IUser>(newPuesto, newUserList[0]));
                }
            }

            return;
        }
    }
}
