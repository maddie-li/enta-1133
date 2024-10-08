using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GD12_1133_Assignment2_MaddieLi.People
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;

    internal class Player : Combatant
    {
        // from Object
        public string Name { get; set; } // name
        public string Glance { get; set; } // short description (known room description, object in inventory or location)
        public string Look { get; set; } // long description (new room description, examining object)

        // from Thing
        public Room Location { get; set; } // object location

        // from Character
        public List<Thing>? contents { get; set; } = new List<Thing>(); // holding things

        public void Talk(Character target, string topic)
        {
            // talk to target about topic
        }

        public void GoTo(Room location)
        {
            // simple go to, does not deal with parsing
        }

        // from Combatant
        public int health { get; set; }
        public int armor { get; set; }

        /*public Player(Room location)
        {
            location = location;
        }*/
        
    }


}
