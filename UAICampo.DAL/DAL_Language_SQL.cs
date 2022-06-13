using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.DAL.SQL
{
    public class DAL_Language_SQL : DAL_Abstract<Language>
    {

        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        //table names
        private const string TABLE_language = "language";
        private const string TABLE_words = "words";
        private const string TABLE_account = "account";

        //TABLE_LANGUAGE Columns
        private const string COLUMN_LANGUAGE_ID = "id";
        private const string COLUMN_LANGUAGE_NAME = "name";

        private static readonly string PARAM_LANGUAGE_ID = $"@{COLUMN_LANGUAGE_ID}";
        private static readonly string PARAM_LANGUAGE_NAME = $"@{COLUMN_LANGUAGE_NAME}";

        //TABLE_WORDS Columns
        private const string COLUMN_WORDS_ID = "id";
        private const string COLUMN_WORDS_TAG = "tag";
        private const string COLUMN_WORDS_WORD = "word";
        private const string COLUMN_WORDS_LANGUAGE = "FK_language_words";

        private static readonly string PARAM_WORDS_ID = $"@{COLUMN_WORDS_ID}";
        private static readonly string PARAM_WORDS_TAG = $"@{COLUMN_WORDS_TAG}";
        private static readonly string PARAM_WORDS_WORD = $"@{COLUMN_WORDS_WORD}";
        private static readonly string PARAM_WORDS_LANGUAGE = $"@{COLUMN_WORDS_LANGUAGE}";

        //TABLE_accounts Columns
        private const string COLUMN_ACCOUNT_ID = "id";
        private const string COLUMN_ACCOUNT_FK_LANGUAGE = "FK_language_account";

        private static readonly string PARAM_ACCOUNT_ID = $"@{COLUMN_ACCOUNT_ID}";

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        public void Delete(int Id)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE" +
                                $" FROM {TABLE_language}" +
                                $" WHERE {COLUMN_LANGUAGE_ID} = {PARAM_LANGUAGE_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_LANGUAGE_ID, Id);
                    sqlReader = sqlCommand.ExecuteReader();
                }
            }
        }

        public Language FindById(int Id)
        {
            Language language = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_LANGUAGE_ID}, {COLUMN_LANGUAGE_NAME}" +
                                $" FROM {TABLE_language}" +
                                $" WHERE {COLUMN_LANGUAGE_ID} = {PARAM_LANGUAGE_ID}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_LANGUAGE_ID, Id);
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            language = new Language(new object[] {sqlReader[0], sqlReader[1]});
                        }
                    }
                }
            }

            return language;
        }
        public Language getUserLanguage(User user)
        {
            Language userLanguage = null;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {TABLE_language}.{COLUMN_LANGUAGE_ID}, {TABLE_language}.{COLUMN_LANGUAGE_NAME}" +
                                $" FROM {TABLE_language}" +
                                $" INNER JOIN {TABLE_account}" +
                                $" ON {TABLE_account}.{COLUMN_ACCOUNT_FK_LANGUAGE} = {TABLE_language}.{COLUMN_LANGUAGE_ID}" +
                                $" WHERE {TABLE_account}.{COLUMN_ACCOUNT_ID} = {user.Id}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            userLanguage = new Language(new object[] { sqlReader[0], sqlReader[1] });
                        }
                    }
                }
            }

            return userLanguage;
        }
        public IList<Language> GetAll()
        {
            List<Language> languages = new List<Language>() ;

            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"SELECT {COLUMN_LANGUAGE_ID}, {COLUMN_LANGUAGE_NAME}" +
                                $" FROM {TABLE_language}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            languages.Add(new Language(new object[] { sqlReader[0], sqlReader[1] }));
                        }
                    }
                }
            }

            return languages;
        }

        public Language Save(Language Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_language} ({COLUMN_LANGUAGE_NAME})" +
                                $" VALUES ({PARAM_LANGUAGE_NAME}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_LANGUAGE_NAME, Entity.Name);

                    sqlCommand.ExecuteNonQuery();
                }

                return Entity;
            }
        }

        public Dictionary<string, string> getWords(int Id)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand query = new SqlCommand("SELECT w.tag, w.word FROM words w JOIN language l ON l.id = w.FK_language_words WHERE l.id = @idLanguage", sqlConnection);
                query.Parameters.AddWithValue("@idLanguage", Id);
                sqlConnection.Open();
                SqlDataReader data = query.ExecuteReader();

                Dictionary<string, string> result = new Dictionary<string, string>();

                while (data.Read())
                {
                    result.Add(data["tag"].ToString(), data["word"].ToString());
                }

                sqlConnection.Close();

                return result;
            }
        }

        public void addWord(string tag, string word, int languageId)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_words} ({COLUMN_WORDS_TAG}, {COLUMN_WORDS_WORD}, {COLUMN_WORDS_LANGUAGE})" +
                                $" VALUES ({PARAM_WORDS_TAG},{PARAM_WORDS_WORD},{PARAM_WORDS_LANGUAGE})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_WORDS_TAG, tag);
                    sqlCommand.Parameters.AddWithValue(PARAM_WORDS_WORD, word);
                    sqlCommand.Parameters.AddWithValue(PARAM_WORDS_LANGUAGE, languageId);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void addWordBulk(Dictionary<string, string> template, int languageId)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"INSERT INTO {TABLE_words} ({COLUMN_WORDS_TAG}, {COLUMN_WORDS_WORD}, {COLUMN_WORDS_LANGUAGE})" +
                                $" VALUES ({PARAM_WORDS_TAG},{PARAM_WORDS_WORD},{PARAM_WORDS_LANGUAGE})";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    foreach (KeyValuePair<string, string> word in template)
                    {
                        sqlCommand.Parameters.AddWithValue(PARAM_WORDS_TAG, word.Key);
                        sqlCommand.Parameters.AddWithValue(PARAM_WORDS_WORD, word.Value);
                        sqlCommand.Parameters.AddWithValue(PARAM_WORDS_LANGUAGE, languageId);
                        
                        sqlCommand.ExecuteNonQuery();
                    }
                }

                sqlConnection.Close();
            }
        }

        public void updateWord(string tag, string word, int languageId)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"UPDATE{TABLE_words}" +
                                $"SET {COLUMN_WORDS_WORD} = {PARAM_WORDS_WORD}" +
                                $" WHERE {COLUMN_WORDS_TAG} = {PARAM_WORDS_TAG} AND {COLUMN_WORDS_LANGUAGE} = {PARAM_WORDS_LANGUAGE}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_WORDS_TAG, tag);
                    sqlCommand.Parameters.AddWithValue(PARAM_WORDS_WORD, word);
                    sqlCommand.Parameters.AddWithValue(PARAM_WORDS_LANGUAGE, languageId);

                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void deleteWord(string tag, string languageId)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE" +
                                $" FROM {TABLE_words}" +
                                 $" WHERE {COLUMN_WORDS_TAG} = {PARAM_WORDS_TAG} AND {COLUMN_WORDS_LANGUAGE} = {PARAM_WORDS_LANGUAGE}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_WORDS_TAG, tag);
                    sqlCommand.Parameters.AddWithValue(PARAM_WORDS_LANGUAGE, languageId);
                    sqlReader = sqlCommand.ExecuteReader();
                }
            }
        }

        //deletes all words in a language
        public void deleteLanguageWords(int languageId)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string query = $"DELETE" +
                                $" FROM {TABLE_words}" +
                                $" WHERE {COLUMN_WORDS_LANGUAGE} = {PARAM_WORDS_LANGUAGE}";

                using (sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue(PARAM_WORDS_LANGUAGE, languageId);
                    sqlReader = sqlCommand.ExecuteReader();
                }
            }
        }
    }
}
