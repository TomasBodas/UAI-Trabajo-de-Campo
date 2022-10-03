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
		public Language createLanguage (string name)
		{
            Language lang = new Language();
            lang.Name = name;

            return languageDal.Save(lang);
		}

        public void deleteLanguage(Language language)
        {
            languageDal.deleteLanguageWords(language.Id);
            languageDal.Delete(language.Id);
        }

        public static Language getUserLanguage(User user)
        {
            return languageDal.getUserLanguage(user);
        }

        public void loadLanguageWords(Language language)
        {
            language.words = languageDal.getWords(language.Id);
        }

        public Dictionary<string, string> loadWordsDictionary(Language language)
        {
            return languageDal.getWords(language.Id);
        }

        public void addWord(string tag, string word, int languageId)
        {
            languageDal.addWord(tag, word, languageId);
        }

        public void updateWord(string tag, string word, int languageId)
        {
          languageDal.updateWord(tag, word, languageId);
        }

        public void deleteWord(string tag, int languageId)
        { 
            languageDal.deleteWord(tag, languageId);
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
