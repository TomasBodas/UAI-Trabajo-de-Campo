using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAICampo.Services.Composite
{
    public class Leaf : Component
    {
        public override IList<Component> GetAllChildren()
        {
            return null;
        }
    
        public override void AddChild(Component c)
        {
           
        }

        public override void EmptyChild()
        {
            
        }
    }
}
