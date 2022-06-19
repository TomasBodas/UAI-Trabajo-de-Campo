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
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int AddressNumber { get; set; }
        public string City { get; set; }
        public Province Province { get; set; }
    }
}
