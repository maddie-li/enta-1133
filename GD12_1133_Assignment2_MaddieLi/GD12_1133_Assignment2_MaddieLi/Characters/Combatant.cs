using System;
using System.Collections.Generic;
using GD12_1133_Assignment2_MaddieLi.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Characters
{
    public class Combatant : BaseCharacter
    {
        // INFO
        public override string Name { get; set; }
        public override string Glance { get; set; } = "";
        public override string Look { get; set; } = "";

        // CAN HOLD
        public override List<BaseItem>? Contents { get; set; } = null!;
        public override BaseRoom CurrentRoom { get; set; } = null!;

        // PROPERTIES
        public override int Health { get; set; } // health

        public Combatant(string name, int health)
         : base(name, "", "", health, null!, null!)
        {
            this.Name = name;
            this.Health = health;
        }

    }
}
