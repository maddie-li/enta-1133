
using GD12_1133_Assignment2_MaddieLi.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GD12_1133_Assignment2_MaddieLi.Actions;
using System.Numerics;
using System.Xml.Linq;

namespace GD12_1133_Assignment2_MaddieLi.Characters
{
    public class Player : BaseCharacter
    {
        // INFO
        public override string Name { get; set; } = "Player";
        public override string Glance { get; set; } = "Yourself";
        public override string Look { get; set; } = "It's you, the player.";

        // CAN HOLD
        public override List<BaseItem>? Contents { get; set; }
        public override BaseRoom CurrentRoom { get; set; }

        // PROPERTIES
        public override int Health { get; set; } = 150;   // health
        
        public Player(BaseRoom currentRoom, List<BaseItem>contents)
        : base("Player", "Yourself", "It's you, the player.", 10, currentRoom, contents)
        {
            this.CurrentRoom = currentRoom;
            this.Contents = contents;
        }

    }
}
