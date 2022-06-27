using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.BE
{
    public class Reconocimiento : IInterface
    {
        public Reconocimiento(object[] itemArray)
        {
            this.Id = (int)itemArray[0];
            this.Description = (string)itemArray[1];
            this.Date = (DateTime)itemArray[2];
            this.Value = (int)itemArray[3];
        }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public IUser Sender { get; set; }
        public IUser Receiver { get; set; }
    }
}