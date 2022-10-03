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
		public IList<Log> getAll(DateTime from, DateTime to, string type = null)
		{
			return dalLog.GetAll(from, to, type);
		}
	}
}
