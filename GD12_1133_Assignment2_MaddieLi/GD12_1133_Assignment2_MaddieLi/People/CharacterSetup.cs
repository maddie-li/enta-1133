using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GD12_1133_Assignment2_MaddieLi.People
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;

    internal class CharacterSetup : Character
    {
        // PROPERTIES 

        // private fields from Object
        private string _name;
        private string _glance;
        private string _look;

        // private fields from Thing
        private Room _location;

        // private fields from I_Container
        private List<Thing>? _contents;

        // getters and setters from Object
        public override string Name
        {
            get { return _name; }

            set { _name = value; }
        }
        public override string Glance
        {
            get { return _glance; }

            set { _glance = value; }
        }
        public override string Look
        {
            get { return _look; }

            set { _look = value; }
        }

        // getters and setters from Thing
        public override Room Location
        {
            get { return _location; }

            set { _location = value; }
        }

        // getters and setters from I_Container
        public override List<Thing>? Contents
        {
            get { return _contents; }

            set { _contents = value; }
        }

        // FUNCTIONS
        public void Talk(Character target, string topic)
        {
            // talk to target about topic
        }

        public void GoTo(Room location)
        {
            // simple go to, does not deal with parsing
        }

        // CONSTRUCTOR
        public CharacterSetup(string Name, string Glance, string Look, Room Location, List<Thing> Contents) : base()
        {
            _name = Name;
            _glance = Glance;
            _look = Look;
            _location = Location;
            _contents = Contents;

        }

    }


}
