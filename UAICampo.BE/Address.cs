using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.BE
{
    public class Address : IEntity
    {
        public Address()
        {

        }
        public Address(int pId, string pAddress1, string pAddress2, int pAddressNumber) : base()
        {
            this.Id = pId;
            this.Address1 = pAddress1;
            this.Address2 = pAddress2;
            this.AddressNumber = pAddressNumber;
        }
        public Address(int pId, string pAddress1, string pAddress2, int pAddressNumber, string pCity):base()
        {
            this.Id = pId;
            this.Address1 = pAddress1;
            this.Address2 = pAddress2;
            this.AddressNumber = pAddressNumber;
            this.City = pCity;
        }
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int AddressNumber { get; set; }
        public string City { get; set; }
        public Province Province { get; set; }
    }
}
