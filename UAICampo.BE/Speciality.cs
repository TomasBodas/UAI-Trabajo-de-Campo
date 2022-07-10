using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.BE
{
    public class Speciality
    {
        public Speciality()
        {

        }
        public Speciality(int pId, string pName, string pDescription):base()
        {
            this.Id = pId;
            this.Name = pName;
            this.Description = pDescription;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
