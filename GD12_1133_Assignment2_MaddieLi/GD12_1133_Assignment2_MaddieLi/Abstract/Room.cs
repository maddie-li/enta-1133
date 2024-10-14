using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Room : IInfo, ICanHold<Item> // room is an object that has contents and exits
    {
        // PROPERTIES
        public abstract bool HasBeenEntered { get; set; }
        public virtual List<Character>? Inhabitants { get; set; } // list of characters in room

        // INFO
        public abstract string Name { get; set; } // name
        public abstract string Glance { get; set; } // short description (known room description, object in inventory or location)
        public abstract string Look { get; set; } // long description (new room description, examining object)

        // CAN HOLD
        public virtual List<Item>? Contents { get; set; } // list of items


        // FUNCTIONS
        public abstract void OnRoomEnter();

        public virtual Room CheckIsInRoom(Character character)
        {
            if (character.CurrentRoom == this)
            {
                return this;
            }

            return null;
        }

        public void AddItem(Item item)
        {
            Contents!.Add(item);
        }
    }
}
