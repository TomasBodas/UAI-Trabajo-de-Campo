using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.DAL;
using UAICampo.Services;

namespace UAICampo.BLL
{
     public class BLL_LogManager
    {
		static DAL_Log dalLog = new DAL_Log();

		public static Log addMessage(Log message)
		{
			return dalLog.Save(message);
		}
		public static IList<Log> getAll()
		{
			return dalLog.GetAll();
		}
	}
}
