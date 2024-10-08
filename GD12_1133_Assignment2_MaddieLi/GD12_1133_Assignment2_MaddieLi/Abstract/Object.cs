using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Object // object is anything that exists in the game
    {
        public string Name { get; set; } // name
        public string Glance { get; set; } // short description (known room description, object in inventory or location)
        public string Look { get; set; } // long description (new room description, examining object)
    }

    public abstract class Thing : Object // thing is an object that has a location, includes items and characters
    {
        public Room Location { get; set; } // object location
    }
}
