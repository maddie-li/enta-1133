using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
    using GD12_1133_Assignment2_MaddieLi.Items;
    using GD12_1133_Assignment2_MaddieLi.People;
    using GD12_1133_Assignment2_MaddieLi.Actions;
    using GD12_1133_Assignment2_MaddieLi.Directions;
    using Microsoft.VisualBasic;
    public class BasicRoom : Room
    {
        // INFO
        public override string Name { get; set; } // name
        public override string Glance { get; set; } // short description (known room description, object in inventory or location)
        public override string Look { get; set; } // long description (new room description, examining object)

        // ROOM
        public override bool HasBeenEntered { get; set; }

        // PROPERTIES
        public virtual List<BaseCharacter>? Inhabitants { get; set; } // list of items

        Look LookAt = new Look();

        public override void OnRoomEnter()
        {
            LookAt.Describe(this, HasBeenEntered);
        }


        public BasicRoom(int x, int y, string name, string glance, string look)
        : base(x, y, name, glance, look) { }

    }

}
