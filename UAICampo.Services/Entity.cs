using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services
{
    public abstract class Entity : IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
    }
}
