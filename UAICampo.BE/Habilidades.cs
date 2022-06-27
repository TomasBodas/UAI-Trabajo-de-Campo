using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.BE
{
    public class Habilidades : IInterface
    {
        public Habilidades(object[] itemArray)
        {
            this.Id = (int)itemArray[0];
            this.Name = (string)itemArray[1];
            this.Value = (int)itemArray[2];
        }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
