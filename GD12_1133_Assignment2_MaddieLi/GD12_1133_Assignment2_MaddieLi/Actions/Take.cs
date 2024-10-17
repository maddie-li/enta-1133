using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Actions
{
    internal class Take
    {
        public void Get(BaseItem item, Character player)
        {
            if (item == null)
            {
                Console.WriteLine("You don't see any such thing here.");
            }
            else
            {
                item.CurrentRoom.Contents.Remove(item);
                item.CurrentRoom = null!;

                player.Contents.Add(item);

                Console.WriteLine($"Picked up {item.Name.ToLower()}!");

            }
            

        }
    }
}
