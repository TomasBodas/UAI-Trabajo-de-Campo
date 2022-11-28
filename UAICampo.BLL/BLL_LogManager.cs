using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.DAL;
using UAICampo.DAL.SQL;
using UAICampo.Services;

namespace UAICampo.BLL
{
     public class BLL_LogManager
    {
		static DAL_Log dalLog = new DAL_Log();
		static DAL_Language_SQL dalLanguage = new DAL_Language_SQL();

		public static Log addMessage(Log message)
		{
			return dalLog.Save(message);
		}
		public IList<Log> getAll(DateTime from, DateTime to, string type = null)
		{
			return dalLog.GetAll(from, to, type);
		}
		public List<WordChangelog> getAllChangelog(DateTime from, DateTime to, string type = null)
		{
			return dalLog.GetAllChangelog(from, to, type);
		}

		public void RestoreWord(WordChangelog row)
        {
			dalLog.RestoreWord(row);
			dalLanguage.wordChange(row.Tag, row.Word, row.FK_Language_Words, "Restored", row.WordId);
		}
	}
}
