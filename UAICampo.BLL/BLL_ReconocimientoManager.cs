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
    public static class BLL_ReconocimientoManager
    {
        static DAL_Reconocimiento_SQL dalReconocimiento = new DAL_Reconocimiento_SQL();
        public static List<Reconocimiento> getReceived(User us, int limit = 0)
        {
            return dalReconocimiento.getReceived(us, limit);
        }

        public static List<Reconocimiento> getReceivedSuperiors(User us)
        {
            return dalReconocimiento.getReceivedSuperiors(us);
        }

        public static List<Reconocimiento> getLastReceived(User us)
        {
            return dalReconocimiento.getLastReceived(us);
        }

        public static void Send(int senderId, int receivedId, string achievementName, int achievementValue, DateTime date)
        {
           dalReconocimiento.Send(senderId, receivedId, achievementName, achievementValue, date);
        }
    }
}
