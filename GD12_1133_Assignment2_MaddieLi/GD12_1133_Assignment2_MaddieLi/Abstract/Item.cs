using System;
using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Item : Thing // item is a thing that can be picked up or used
    {
        // properties from Object
        public override string Name { get; set; } // name
        public override string Glance { get; set; } // short description (known room description, object in inventory or location)
        public override string Look { get; set; } // long description (new room description, examining object)

        // properties from Thing
        public override Room Location { get; set; } // object location

        // new properties
        public abstract bool IsPortable { get; set; }

        // functions
        public abstract void Use();
        public abstract void Use(Thing target);
    }

    public abstract class ContainerItem : Item, I_Container<Thing> // item is a thing that can be picked up or used
    {
        // properties from Object
        public override string Name { get; set; } // name
        public override string Glance { get; set; } // short description (known room description, object in inventory or location)
        public override string Look { get; set; } // long description (new room description, examining object)

        // properties from Thing
        public override Room Location { get; set; } // object location

        // properties from Item
        public override bool IsPortable { get; set; }

        // properties from I_Container
        public abstract List<Thing>? Contents { get; set; } // container contents
    }
}
