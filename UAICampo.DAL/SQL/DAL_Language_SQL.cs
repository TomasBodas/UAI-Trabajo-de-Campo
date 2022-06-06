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

        #region tables
        //table names
        private const string TABLE_language = "language";
        private const string TABLE_words = "words";
        #endregion

        #region language columns/params
        //user table columns
        private const string COLUMN_LANGUAGE_ID = "id";
        private const string COLUMN_LANGUAGE_NAME = "name";

        //user params
        private static readonly string PARAM_LANGUAGE_ID = $"@{COLUMN_LANGUAGE_ID}";
        private static readonly string PARAM_LANGUAGE_NAME = $"@{COLUMN_LANGUAGE_NAME}";
        #endregion

        #region words columns/params
        //user table columns
        private const string COLUMN_WORDS_ID = "id";
        private const string COLUMN_WORDS_TAG = "tag";
        private const string COLUMN_WORDS_WORD = "word";
        private const string COLUMN_WORDS_LANGUAGE = "FK_language_words";

        //user params
        private static readonly string PARAM_WORDS_ID = $"@{COLUMN_WORDS_ID}";
        private static readonly string PARAM_WORDS_TAG = $"@{COLUMN_WORDS_TAG}";
        private static readonly string PARAM_WORDS_WORD = $"@{COLUMN_WORDS_WORD}";
        private static readonly string PARAM_WORDS_LANGUAGE = $"@{COLUMN_WORDS_LANGUAGE}";
        #endregion

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Language FindById(int Id)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand query = new SqlCommand("SELECT id, name FROM language WHERE id = @id", sqlConnection);
                query.Parameters.AddWithValue("@id", Id);

                sqlConnection.Open();
                SqlDataReader data = query.ExecuteReader();

                Language result = new Language();
                while (data.Read())
                {
                    result = castDto(data);
                }
                sqlConnection.Close();



                return result;
            }
        }

        public IList<Language> GetAll()
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand query = new SqlCommand("SELECT id, name FROM language", sqlConnection);

                sqlConnection.Open();
                SqlDataReader data = query.ExecuteReader();

                List<Language> result = new List<Language>();
                while (data.Read())
                {
                    result.Add(castDto(data));
                }
                sqlConnection.Close();

                return result;
            }
        }

        public Language Save(Language Entity)
        {
            using (sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand query = new SqlCommand("UPDATE account.FK_language_account FROM account where FK_language_account = @id", sqlConnection);
                query.Parameters.AddWithValue("@id", Entity.Id);

                sqlConnection.Open();
                SqlDataReader data = query.ExecuteReader();

                Language result = new Language();
                while (data.Read())
                {
                    result = castDto(data);
                }
                sqlConnection.Close();

                return result;
            }
        }

        public Language castDto(SqlDataReader data)
        {
            Language result = new Language()
            {
                Id = Convert.ToInt32(data["id"]),
                Name = data["name"].ToString()
            };

            return result;
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
    }
}
