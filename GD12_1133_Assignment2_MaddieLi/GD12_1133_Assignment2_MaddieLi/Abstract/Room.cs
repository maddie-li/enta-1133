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
        public virtual void OnRoomIntro()
        {
            if (HasBeenEntered)
            {
                Console.WriteLine($"{Name}\n{Glance}");
            }
            else
            {
                Console.WriteLine($"{Name}\n{Look}");
                HasBeenEntered = true;
            }

            if (Contents!.Count == 0)
            {
                Console.WriteLine("There is nothing in the room.");
            }
            else
            {
                Console.WriteLine("In this room there is:");

                foreach (Item i in Contents)
                {
                    Console.WriteLine(i.Glance);
                }
            }

            if (Inhabitants!.Count == 0)
            {
                Console.WriteLine("There are no people here.");
            }
            else
            {
                Console.WriteLine("In this room there is:");

                foreach (Character i in Inhabitants)
                {
                    Console.WriteLine(i.Glance);
                }
            }
        }
        public void AddItem(Item item)
        {
            Contents!.Add(item);
        }
    }
}
