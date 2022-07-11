using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.BE
{
    public class Equipo : IEquipo
    {
        public Equipo()
        {

        }
        public Equipo(object[] itemArray)
        {
            this.Id = (int)itemArray[0];
            this.Name = (string)itemArray[1];
            this.Value = (int)itemArray[2];
        }
        
        public int Value = 1;

        public List<KeyValuePair<IProfile, IUser>> puestos = new List<KeyValuePair<IProfile, IUser>>();
    }
}
