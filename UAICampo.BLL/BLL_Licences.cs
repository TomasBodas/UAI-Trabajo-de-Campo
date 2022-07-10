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

        private static readonly int LICENSE_ADMIN = 2;
        private static readonly int LICENSE_PRACTITIONER = 16;
        private static readonly int LICENSE_PATIENT = 17;

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
            if (validateLicense(LICENSE_ADMIN))
            {
                dal.addRelationship(master, slave);
            }
        }

        public void removeRelationship(Component slaveLicense)
        {
            if (validateLicense(LICENSE_ADMIN))
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
        }

        public bool addNewLicense(Component license)
        {
            if (validateLicense(LICENSE_ADMIN))
            {
                return dal.addNewLicense(license);
            }
            else { return false; }
        }

        public bool removeLicense(Component license)
        {
            if (validateLicense(LICENSE_ADMIN))
            {
                return dal.removeLicense(license);
            }
            else { return false; }
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
        public List<Component> getAll()
        {
            return dal.getAllLicenses();
        }
        private bool validateLicense(int requiredLicenseId)
        {
            List<Component> licenseList = new List<Component>();
            bool access = false;

            foreach (Profile profile in UserInstance.getInstance().user.profileList)
            {
                licenseList.AddRange(profile.getAllLicenses());
            }

            if (licenseList.Any(x => x.Id == requiredLicenseId))
            {
                access = true;
            }
            return access;
        }
    }
}
