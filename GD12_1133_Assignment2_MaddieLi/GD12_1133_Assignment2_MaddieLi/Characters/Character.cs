
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
    public class Character : BaseCharacter
    {
        // INFO
        public override string Name { get; set; } 
        public override string Glance { get; set; } 
        public override string Look { get; set; } 

        // CAN HOLD
        public override List<BaseItem>? Contents { get; set; }
        public override BaseRoom CurrentRoom { get; set; }

        // PROPERTIES
        public override int Health { get; set; }   // health
        
        public Character(string name, string glance, string look, int health, BaseRoom currentRoom, List<BaseItem>contents)
        : base(name, glance, look, health, currentRoom, contents)
        {
            this.Name = name;
            this.Glance = glance;
            this.Look = look;
            this.Health = health;
            this.CurrentRoom = currentRoom;
            this.Contents = contents;
        }

    }
}
