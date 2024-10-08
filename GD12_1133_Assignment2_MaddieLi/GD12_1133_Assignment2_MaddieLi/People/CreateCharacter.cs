using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GD12_1133_Assignment2_MaddieLi.People
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;

    internal class CreateCharacter : Character
    {
        // creating private fields
        private string _name;
        private string _glance;
        private string _look;
        private List<Thing>? _contents;

        // contents
        public override List<Thing>? Contents
        {
            get { return _contents; }

            set { _contents = value; }
        }

        public void Talk(Character target, string topic)
        {
            // talk to target about topic
        }

        public void GoTo(Room location)
        {
            // simple go to, does not deal with parsing
        }

        public CreateCharacter(string Name, string Glance, string Look, List<Thing> Contents)
        {
            _name = Name;
            _glance = Glance;
            _look = Look;
            _contents = Contents;

            Library.AddThing(this);

        }

    }


}
