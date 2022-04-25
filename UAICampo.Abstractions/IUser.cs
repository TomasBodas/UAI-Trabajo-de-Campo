using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Abstractions
{
    public abstract class IUser : IEntity
    {
        public Guid Id { get; set; }
    }
}
