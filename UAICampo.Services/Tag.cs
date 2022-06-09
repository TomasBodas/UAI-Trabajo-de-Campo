using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Services
{
    public class Tag
    {
        public Tag() {}
        public Tag(string Word) : base()
        {
            this.Word = Word;
        }
        public Tag(int License, string Word) : base()
        {
            this.LicenseId = License;
            this.Word = Word;
        }
        public int LicenseId { get; set; }
        public string Word { get; set; }
    }
}
