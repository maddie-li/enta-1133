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
        public List<Thing>? contents { get; set; } = new List<Thing>(); // holding things

        public void Talk(Character target, string topic)
        {
            // talk to target about topic
        }

        public void GoTo(Room location)
        {
            // simple go to, does not deal with parsing
        }
    }

    public abstract class Combatant : Character // combatant is a character that has stats, can fight
    {
        public int health { get; set; }
        public int armor { get; set; }
    }
}
