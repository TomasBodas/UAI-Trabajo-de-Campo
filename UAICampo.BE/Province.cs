using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.BE
{
    public class Province : IEntity
    {
        public Province()
        {

        }
        public Province(int pId, string pName)
        {
            this.id = pId;
            this.name = pName;
        }
        public Province(object[] itemArray)
        {
            this.id = (int)itemArray[0];
            this.name = (string)itemArray[1];
        }
        public int id { get; set; }
        public string name { get; set; }
    }
}
