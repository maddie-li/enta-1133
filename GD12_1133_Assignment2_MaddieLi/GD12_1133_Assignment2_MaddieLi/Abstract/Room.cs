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
                Console.WriteLine(Contents.Count + "items in here");
                Console.WriteLine("In this room there is:");

                foreach (Item i in Contents)
                {
                    Console.WriteLine($"thing {i}, name '{i.Name}', description '{i.Glance}'");
                }
            }
        }
        public void AddItem(Item item)
        {
            Contents.Add(item);
        }
    }
}
