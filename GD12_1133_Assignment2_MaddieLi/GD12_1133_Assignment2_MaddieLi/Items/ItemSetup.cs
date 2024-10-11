using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Items
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    internal class ItemSetup : Item
    {
        // PROPERTIES

        // private fields from Object
        private string _name;
        private string _glance;
        private string _look;

        // private fields from Thing
        private Room _location;

        // private fields from Item
        private bool _isPortable;

        // properties from Object
        public override string Name { get; set; } // name
        public override string Glance { get; set; } // short description (known room description, object in inventory or location)
        public override string Look { get; set; } // long description (new room description, examining object)

        // properties from Thing
        public override Room Location { get; set; } // object location

        // properties from Item
        public override bool IsPortable { get; set; }

        // FUNCTIONS
        public override void Use()
        {

        }
        public override void Use(Thing target)
        {

        }

        // CONSTRUCTOR
        public ItemSetup(string Name, string Glance, string Look, Room Location, bool IsPortable) : base()
        {
            _name = Name;
            _glance = Glance;
            _look = Look;
            _location = Location;
            _isPortable = IsPortable;

        }
    }
}
