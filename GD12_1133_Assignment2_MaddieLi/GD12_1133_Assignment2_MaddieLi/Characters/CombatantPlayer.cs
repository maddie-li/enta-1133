using System;
using System.Collections.Generic;
using GD12_1133_Assignment2_MaddieLi.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Characters
{
    public class CombatantPlayer : Combatant
    {
        // INFO
        public override string Name { get; set; } = "Player";

        // PROPERTIES
        public override int Health { get; set; }  //health

        public CombatantPlayer(int health)
         : base("Player", health)
        {
            this.Health = health;
        }

    }
}
