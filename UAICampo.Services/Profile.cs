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
        public List<Component> Licences;

        public Profile(object[] itemArray)
        {
            this.ProfileId = (int)itemArray[0];
            this.ProfileName = (string)itemArray[1];
            this.Desc = (string)itemArray[2];
            Licences = new List<Component>();
        }

        public List<Component> getAllLicenses()
        {
            List<Component> LicensesList = new List<Component>();

            foreach (Component component in Licences)
            {
                LicensesList.AddRange(component.GetAllChildren());
            }
            LicensesList.AddRange(Licences);
            return LicensesList;
        }
    }
}
