using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.DAL.SQL;
using UAICampo.Services.Observer;

namespace UAICampo.BLL
{
    class BLL_LanguageManager
    {
        static DAL_Language_SQL dal = new DAL_Language_SQL();

		public static void setLanguage (Language sessionLanguage)
		{
			Language language = dal.FindById(sessionLanguage.Id);

			language.words = dal.getWords(sessionLanguage.Id);
		}
	}
}
