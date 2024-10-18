using System;
using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class BaseItem : IInfo // item is a thing that can be picked up or used
    {
        // INFO
        public abstract string Name { get; set; } // name
        public abstract string Glance { get; set; } // short description (known room description, object in inventory or location)
        public abstract string Look { get; set; } // long description (new room description, examining object

        // PROPERTIES
        public abstract BaseRoom CurrentRoom { get; set; } // name

        // CONSTRUCTOR
        public BaseItem(string Name, string Glance, string Look, BaseRoom CurrentRoom)
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.CurrentRoom = CurrentRoom;

        }
    }
}
