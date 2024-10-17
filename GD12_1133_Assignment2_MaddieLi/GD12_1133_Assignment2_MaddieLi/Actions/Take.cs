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
        public void Get(BaseItem item, Player player)
        {
            item.CurrentRoom.Contents.Remove(item);
            item.CurrentRoom = null!;

            player.Contents.Add(item);

            Console.WriteLine($"Picked up { item.Name.ToLower()}!");

        }

        public void Drop(BaseItem item, Player player)
        {
            player.Contents.Remove(item);
            item.CurrentRoom = player.CurrentRoom;

            player.CurrentRoom.Contents.Add(item);

            Console.WriteLine($"Dropped {item.Name.ToLower()}!");
        }
    }
}
