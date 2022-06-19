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
    }
}
