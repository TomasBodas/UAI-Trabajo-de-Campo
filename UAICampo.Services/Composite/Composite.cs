using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Services.Composite
{
    public class Composite : Component
    {
        private IList<Component> child;
        public Composite()
        {
            child = new List<Component>();
        }

        public override IList<Component> GetAllChildren()
        {
                foreach (var item in child)
                {
                    child.Concat(item.GetAllChildren().ToList());
                }
                return child.ToArray();
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
