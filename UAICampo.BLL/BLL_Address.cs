using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.BE;
using UAICampo.DAL;
using UAICampo.DAL.SQL;
using UAICampo.Services;

namespace UAICampo.BLL
{
    public class BLL_Address
    {
        //SQL Connection
        DAL_User_SQL dal_user = new DAL_User_SQL();
        DAL_Profile_SQL dal_profile = new DAL_Profile_SQL();
        DAL_Language_SQL dal_language = new DAL_Language_SQL();
        DAL_Address_SQL dal_address = new DAL_Address_SQL();

        string DEFAULT_PACIENT_PROFILE_NAME = "Pacient";
        string DEFAULT_PRACTICIONER_PROFILE_NAME = "Practitioner";

        public Address getUserAddress(User user)
        {
            return dal_user.getUserAddress(user);
        }

        public List<Province> getProvincesList()
        {
            return dal_address.getProvincesList();
        }
        public bool addUserAddress(Address address, User user)
        {   
            return dal_user.addUserAddress(address, user);
        }

    }
}
