using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services.Composite
{
    public abstract class Component : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract IList<Component> GetAllChildren();
        public abstract void AddChild(Component c);
        public abstract void EmptyChild();
        public override string ToString()
        {
            return Name;
        }
    }
}
