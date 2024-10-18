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
        public override string Name { get; set; }

        // CAN HOLD
        public override List<BaseItem>? Contents { get; set; }

        // PROPERTIES
        public override int Health { get; set; } //health

        public CombatantCPU(string name, int health)
         : base(name, health)
        {
            this.Name = name;
            this.Health = health;
        }

    }
}
