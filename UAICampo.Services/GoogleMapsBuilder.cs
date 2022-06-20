using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Services
{
    public static class GoogleMapsBuilder
    {
        public static string addressBuilder(string addres1, string addres2, int addressNumber, string City)
        {
            string BaseGoogleMapsURL = "http://google.com/maps?q=";

            StringBuilder addressLink = new StringBuilder();
            addressLink.Append(BaseGoogleMapsURL);

            if (addres1 != "")
            {
                addressLink.Append(addres1 + ",+");
            }
            if (addressNumber != 0)
            {
                addressLink.Append(addressNumber + ",+");
            }
            if (City != "")
            {
                addressLink.Append(City + ",+");
            }

            return addressLink.ToString();
        }
        public static string pathDistanceBuilder(string addressA1, string addresA2, int addressNumberA, string CityA, string addressB1, string addressB2, int addressNumberB, string CityB)
        {
            string BaseGoogleMapsURL = "http://google.com/maps/dir/";

            StringBuilder addressLink = new StringBuilder();
            addressLink.Append(BaseGoogleMapsURL);

            if (addressA1 != "")
            {
                addressLink.Append(addressA1 + ",+");
            }
            if (addressNumberA != 0)
            {
                addressLink.Append(addressNumberA + ",+");
            }
            if (CityA != "")
            {
                addressLink.Append(CityA + "/");
            }
            if (addressB1 != "")
            {
                addressLink.Append(addressB1 + ",+");
            }
            if (addressNumberB != 0)
            {
                addressLink.Append(addressNumberB + ",+");
            }
            if (CityB != "")
            {
                addressLink.Append(CityB + ",+");
            }

            return addressLink.ToString();
        }
    }
}
