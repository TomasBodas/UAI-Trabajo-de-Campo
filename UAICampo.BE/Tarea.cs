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
        public Tarea()
        {

        }
        public Tarea(string title, string description,DateTime datecreated, DateTime datefinished, DateTime datedeadline,StateType state,bool archived, IEquipo equipo, IUser user, int epica)
        {
            Title = title;
            Description = description;
            DateCreated = datecreated;
            DateFinished = datefinished;
            DateDeadline = datedeadline;
            State = state;
            Archived = archived;
            EpicaId = epica;
            User = user;
            Equipo = equipo;
        }
        public Tarea(object[] itemArray)
        {
            this.Id = (int)itemArray[0];
            this.Title = (string)itemArray[1];
            this.Description = (string)itemArray[2];
            this.DateCreated = (DateTime?)itemArray[3];
            this.DateDeadline = (DateTime?)itemArray[4];
            if (itemArray[5] == DBNull.Value)
            {
                this.DateFinished = null;
            }
            else
            {
                this.DateFinished = (DateTime?)itemArray[5];
            }
            this.Value = (int)itemArray[6];
            this.State = (StateType)Convert.ToInt32(itemArray[7]);
            this.Archived = (bool)itemArray[8];
            //this.EpicaId = (int)itemArray[9];
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateDeadline { get; set; }
        public DateTime? DateFinished{ get; set; }
        public int Value { get; set; }
        public StateType State { get; set; }
        public bool Archived { get; set; }

        public int EpicaId { get; set; }
        public IEquipo Equipo { get; set; }
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
