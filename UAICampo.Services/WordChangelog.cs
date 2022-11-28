using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services
{
    public class WordChangelog
    {
        public WordChangelog()
        {

        }

        public WordChangelog(object[] itemArray)
        {
            this.Id = (int)itemArray[0];
            this.Tag = (string)itemArray[1];
            this.Word = (string)itemArray[2];
            this.FK_Language_Words = (int)itemArray[3];
            this.Date = (DateTime)itemArray[4];
            this.Change = (string)itemArray[5];
            this.User = (int?)itemArray[6];
            this.WordId = (int)itemArray[7];
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Tag { get; set; }
        public string Word { get; set; }
        public int FK_Language_Words { get; set; }
        public string Change { get; set; }
        public int? User { get; set; }
        public int WordId { get; set; }
    }
}
