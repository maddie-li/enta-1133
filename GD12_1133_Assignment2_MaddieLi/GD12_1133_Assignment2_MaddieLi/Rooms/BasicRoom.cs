using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using GD12_1133_Assignment2_MaddieLi.Items;
    using GD12_1133_Assignment2_MaddieLi.People;
    using Microsoft.VisualBasic;
    public class BasicRoom : Room
    {
        // INFO
        public override string Name { get; set; } // name
        public override string Glance { get; set; } // short description (known room description, object in inventory or location)
        public override string Look { get; set; } // long description (new room description, examining object)

        // ROOM
        public override bool HasBeenEntered { get; set; }

        // FUNCTION
        public override void OnRoomEnter()
        {

        }

        // CONSTRUCTOR
        public BasicRoom(string Name, string Glance, string Look, List<Item> Contents, List<Character> Inhabitants) : base()
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.Contents = Contents;
            this.Inhabitants = Inhabitants;

        }
    }

}
