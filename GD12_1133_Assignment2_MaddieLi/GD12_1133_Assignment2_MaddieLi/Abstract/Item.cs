using System;
using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Item : IInfo // item is a thing that can be picked up or used
    {
        // INFO
        public abstract string Name { get; set; } // name
        public abstract string Glance { get; set; } // short description (known room description, object in inventory or location)
        public abstract string Look { get; set; } // long description (new room description, examining object)

        // FUNCTIONS
        public abstract void Use(Item? target = null);

        // PROPERTIES
        public abstract Room CurrentRoom { get; set; } // name

        // CONSTRUCTOR
        public Item(string Name, string Glance, string Look, Room CurrentRoom)
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.CurrentRoom = CurrentRoom;

        }
    }
}
