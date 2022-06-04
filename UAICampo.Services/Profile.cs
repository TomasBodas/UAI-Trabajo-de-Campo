using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using UAICampo.Services.Composite;

namespace UAICampo.Services 
{
    public class Profile : IProfile
    {
        public IList<Component> Licences;

        public Profile(object[] itemArray)
        {
            this.ProfileId = (int)itemArray[0];
            this.ProfileName = (string)itemArray[1];
            this.Desc = (string)itemArray[2];
            Licences = new List<Component>();
        }
    }
}
