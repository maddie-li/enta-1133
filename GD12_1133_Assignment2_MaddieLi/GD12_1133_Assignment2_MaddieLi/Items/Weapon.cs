using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Items
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using System.Xml.Linq;

    public class Weapon : BasicItem
    {
        private string v1;
        private string v2;
        private string v3;
        private Room boat;

        public override string Name { get; set; } // name
        public override string Glance { get; set; } // short description (known room description, object in inventory or location)
        public override string Look { get; set; } // long description (new room description, examining object)

        public override Room CurrentRoom {  get; set; }  

        public override void Use(Item? target = null)
        {

        }

        // PROPERTIES
        public int Damage { get; set; }

        // CONSTRUCTOR
        public Weapon(string name, string glance, string look, int damage, Room currentRoom)
       : base(name, glance, look, currentRoom) 
        {
            Look = look;
            Damage = damage;
        }
    }

}
