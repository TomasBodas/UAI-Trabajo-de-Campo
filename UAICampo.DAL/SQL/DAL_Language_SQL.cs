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
            throw new NotImplementedException();
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
