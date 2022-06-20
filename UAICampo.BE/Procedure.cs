using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.BE
{
    public class Procedure : IEntity
    {
        public Procedure()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }

    }
}
