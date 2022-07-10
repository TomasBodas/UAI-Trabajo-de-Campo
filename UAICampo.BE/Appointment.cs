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
        public Appointment(int pId, int pClientId, int pPractitionerId, int pOfficeId, int pProcedureId, DateTime pTimeReserved, DateTime pTimeProcedure, bool pConfirmed):base()
        {
            this.Id = pId;
            this.ClientId = pClientId;
            this.PractitionerId = pPractitionerId;
            this.OfficeId = pOfficeId;
            this.ProcedureId = pProcedureId;
            this.TimeReserved = pTimeReserved;
            this.TimeProcedure = pTimeProcedure;
            this.Confirmed = pConfirmed;
        }
        public int Id { get; set; }
        //-----------------------------------------
        public IUser Client { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        //-----------------------------------------
        public IUser Practitioner { get; set; }
        public int PractitionerId { get; set; }
        public string PractitionerName { get; set; }
        //----------------------------------------
        public Address Office { get; set; }
        public int OfficeId { get; set; }
        public string OfficeDir { get; set; }
        //---------------------------------------
        public Procedure Procedure { get; set; }
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        //---------------------------------------
        public DateTime TimeReserved { get; set; }
        public DateTime TimeProcedure { get; set; }
        public bool Confirmed { get; set; }

    }
}
