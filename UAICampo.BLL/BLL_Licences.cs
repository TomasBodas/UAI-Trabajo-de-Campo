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

        //Retrieve all master licenses asociated with a specific profile from DB
        public void getProfileLicences(Profile profile)
        {
            dal.getProfileLicences(profile);

            foreach (Component userLicence in profile.Licences)
            {
                getAllLicences(userLicence);
            }
        }

        //Recursive method to retrieve all child licenses recursively from DB
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

        //Used to create a new Master -> Slave relation to be persisted
        public void updateRelationships(int master, int slave)
        {
            dal.addRelationship(master, slave);   
        }

        public void removeRelationship(Component slaveLicense)
        {
            //First retrieve license master from DB.
            Composite MasterLicense = (Composite)dal.getMasterLicense(slaveLicense);
            getAllLicences(MasterLicense);

            //Then, recursively delete all master-Slave relations
            foreach (Composite childLicense in MasterLicense.child)
            {
                dal.removeRelationship(MasterLicense.Id, slaveLicense.Id);

                if (childLicense.child.Count > 0)
                {
                    foreach (Composite childChildLicense in childLicense.child)
                    {
                        removeRelationship(childChildLicense);
                    }
                }
            }
        }

        public bool addNewLicense(Component license)
        {
            return dal.addNewLicense(license);
        }

        public bool removeLicense(Component license)
        {
            return dal.removeLicense(license);
        }

        //Used to delete Master -> Slave Relation recursively
        public Component getLicensePersistanceTree()
        {
            Component Level0License = dal.getLicenseTree();
            getAllLicences(Level0License);
            return Level0License;
        }

        //Retrieve all orphan licenses
        public List<Component> getOrphanLicensePool()
        {
            List<Component> Licenses = dal.getOrphanLicensesPool();
            return Licenses;
        }

        //Search License by ID
        public Component SearchLicenseById(int Id)
        {
            return dal.findLIcenseById(Id);
        }
    }
}
