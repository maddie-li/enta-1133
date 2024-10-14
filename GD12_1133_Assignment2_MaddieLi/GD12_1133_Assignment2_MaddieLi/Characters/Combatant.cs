using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GD12_1133_Assignment2_MaddieLi.People
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;

    public class Combatant : Character, IInfo, ICanHold<Item>
    {
        // INFO
        public override string Name { get; set; }
        public override string Glance { get; set; }
        public override string Look { get; set; }

        // CAN HOLD
        public List<Item>? Contents { get; set; }
        public override Room CurrentRoom { get; set; }

        // FUNCTIONS
        public override void TalkTo() // talk to character
        {

        }

        // CONSTRUCTOR
        public Combatant(string Name, string Glance, string Look, Room CurrentRoom, List<Item> Contents) : base()
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.CurrentRoom = CurrentRoom;
            this.Contents = Contents;

        }
    }


}
