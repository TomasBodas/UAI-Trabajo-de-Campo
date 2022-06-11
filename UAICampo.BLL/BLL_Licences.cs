using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.DAL;
using UAICampo.Services.Composite;
using UAICampo.Services;

namespace UAICampo.BLL
{
    public class BLL_Licences
    {
        static DAL_Licences_SQL dal = new DAL_Licences_SQL();

        public void getProfileLicences(Profile profile)
        {
            dal.getProfileLicences(profile);

            foreach (Component userLicence in profile.Licences)
            {
                getAllLicences(userLicence);
            }
        }

        public void getAllLicences(Component component)
        {
            if (dal.hasChild(component))
            {
                List<Component> foundLicenses = new List<Component>();

                foundLicenses = dal.getAllLicenses(component);

                foreach (var License in foundLicenses)
                {
                    component.AddChild(License);
                }

                foreach (var item in component.GetAllChildren())
                {
                    getAllLicences(item);
                }
            }
        }
        public Component getLicensePersistanceTree()
        {
            Component Level0License = dal.getLicenseTree();
            getAllLicences(Level0License);
            return Level0License;
        }

        public List<Component> getOrphanLicensePool()
        {
            List<Component> Licenses = dal.getOrphanLicensesPool();
            return Licenses;
        }

        public Component SearchLicenseById(int Id)
        {
            return dal.findLIcenseById(Id);
        }
    }
}
