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

        // CAN HOLD
        public override List<BaseItem>? Contents { get; set; }

        // PROPERTIES
        public override int Health { get; set; } = 100; //health

        public CombatantPlayer(List<BaseItem> contents)
         : base("Player", 100, contents)
        {
            this.Contents = contents;
        }

    }
}
