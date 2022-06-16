using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Services.Composite
{
    public class Composite : Component
    {
        public List<Component> child;
        public Composite(string Name, string Description) : base(Name, Description)
        {
            child = new List<Component>();
        }
        public Composite(int Id, string Name, string Description) : base(Id, Name, Description)
        {
            child = new List<Component>();
        }

        public override IList<Component> GetAllChildren()
        {
            List<Component> licensesList = new List<Component>();
            if (child.Count > 0)
            {
                foreach (Component component in child)
                {
                    licensesList.AddRange(component.GetAllChildren());
                }
                licensesList.AddRange(child);
            }
            return licensesList;
        }

        public override void EmptyChild()
        {
            child = new List<Component>();
        }
        public override void AddChild(Component c)
        {
            child.Add(c);
        }
    }
}
