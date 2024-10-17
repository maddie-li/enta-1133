using System;
using System.Collections.Generic;
using GD12_1133_Assignment2_MaddieLi.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Characters
{
    public class CombatantCPU : Combatant
    {
        // INFO
        public override string Name { get; set; } = "Enemy";

        // CAN HOLD
        public override List<BaseItem>? Contents { get; set; }

        // PROPERTIES
        public override int Health { get; set; } = 75; //health

        public CombatantCPU(List<BaseItem> contents)
         : base("Enemy", 75, contents)
        {
            this.Contents = contents;
        }

    }
}
