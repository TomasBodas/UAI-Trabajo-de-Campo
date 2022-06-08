using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions.Observer;
using UAICampo.DAL.SQL;
using UAICampo.Services.Observer;
using UAICampo.Services;
using UAICampo.Abstractions;

namespace UAICampo.BLL
{
    public class BLL_LanguageManager 
    {
        static DAL_Language_SQL languageDal = new DAL_Language_SQL();
        static DAL_User_SQL userDal = new DAL_User_SQL();

        //set language and get all its words to the instance.
		public static void setLanguage (Language sessionLanguage)
		{


            //Language.getInstance().Name = sessionLanguage.Name;
            //Language.getInstance().words = dal.getWords(Language.getInstance().Id);
		}

        public static Language getUserLanguage(User user)
        {
            return languageDal.getUserLanguage(user);
        }

        public void loadDefaultLanguage()
        {
            //Language.getInstance().words = dal.getWords(2);

        }

        public void loadLanguageWords(Language language)
        {
            language.words = languageDal.getWords(language.Id);
        }
        public IList<Language> getAll()
        {
            return new DAL_Language_SQL().GetAll();
        }
        public Language getLanguage(int id)
        {
            return new DAL_Language_SQL().FindById(id);
        }
        public void UpdateUserLanguage()
        {
            userDal.UpdateLanguage(UserInstance.getInstance().user, UserInstance.getInstance().user.language);
        }
    }
}
