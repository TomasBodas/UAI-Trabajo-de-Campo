using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.BE
{
    public class Tarea : IInterface
    {
        DateTime? nulldate = null;
        public Tarea(object[] itemArray)
        {
            this.Id = (int)itemArray[0];
            this.Title = (string)itemArray[1];
            this.Description = (string)itemArray[2];
            this.DateCreated = (DateTime)itemArray[3];
            this.DateDeadline = (DateTime)itemArray[4];
            this.DateFinished = (DateTime)itemArray[5];
            this.Value = (int)itemArray[6];
            this.State = (StateType)itemArray[7];
            this.Archived = (bool)itemArray[8];
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateDeadline { get; set; }
        public DateTime DateFinished{ get; set; }
        public int Value { get; set; }
        public StateType State { get; set; }
        public bool Archived { get; set; }

        public Epica Epica { get; set; }
        public Equipo Equipo { get; set; }
        public IUser User { get; set; }

        public enum StateType
        {
            Open,
            Assigned,
            Closed,
            Canceled
        }
    }
}
