using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Services.Composite
{
    public class Composite : Component
    {
        private List<Component> child;
        public Composite(int Id, string Name, string Description) : base(Id, Name, Description)
        {
            child = new List<Component>();
        }

        public override IList<Component> GetAllChildren()
        {
            if (child.Count > 0)
            {
                List<Component> licensesList = new List<Component>();
                foreach (Component component in child)
                {
                    licensesList.AddRange(component.GetAllChildren());
                }
                child.AddRange(licensesList);
            }
            return child;
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
