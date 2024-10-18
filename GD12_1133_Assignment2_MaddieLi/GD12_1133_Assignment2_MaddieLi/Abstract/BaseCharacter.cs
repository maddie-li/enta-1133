using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class BaseCharacter : IInfo, ICanHold<BaseItem>
    {
        // INFO
        public abstract string Name { get; set; } // name
        public abstract string Glance { get; set; } // short description (known room description, object in inventory or location)
        public abstract string Look { get; set; } // long description (new room description, examining object)

        // CAN HOLD
        public virtual List<BaseItem>? Contents { get; set; } = new List<BaseItem>(); // list of items

        // PROPERTIES
        public abstract BaseRoom CurrentRoom { get; set; } // name
        public abstract int Health { get; set; }   // health

        // CONSTRUCTOR
        public BaseCharacter(string Name, string Glance, string Look, int Health, BaseRoom CurrentRoom, List<BaseItem> Contents) : base()
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.Health = Health;
            this.CurrentRoom = CurrentRoom;
            this.Contents = Contents;

        }
    }

}
