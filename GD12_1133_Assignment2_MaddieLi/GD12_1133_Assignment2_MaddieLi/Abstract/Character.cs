using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Character : Thing, I_Container<Thing> // character is a thing can hold things, talk, and move
    {
        // properties from Object
        public override string Name { get; set; } // name
        public override string Glance { get; set; } // short description (known room description, object in inventory or location)
        public override string Look { get; set; } // long description (new room description, examining object)

        // properties from Thing
        public override Room Location { get; set; } // object location

        // properties from I_Container
        public abstract List<Thing>? Contents { get; set; } // holding things

        // new properties
        public void Talk(Character target, string topic)
        {
            // talk to target about topic
        }

        public void GoTo(Room location)
        {
            // simple go to, does not deal with parsing
        }
    }
}
