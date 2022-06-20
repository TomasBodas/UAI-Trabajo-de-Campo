using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.BE
{
    public class Appointment : IEntity
    {
        public Appointment()
        {

        }
        public int Id { get; set; }
        public IUser Client { get; set; }
        public int ClientId { get; set; }
        public IUser Practitioner { get; set; }
        public int PractitionerId { get; set; }
        public Address Office { get; set; }
        public int OfficeId { get; set; }
        public Procedure Procedure { get; set; }
        public int ProcedureId { get; set; }
        public DateTime TimeReserved { get; set; }
        public DateTime TimeProcedure { get; set; }
        public bool Confirmed { get; set; }

    }
}
