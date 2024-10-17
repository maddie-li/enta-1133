using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Actions
{
    internal class Take
    {
        public void Get(Item item, Character character)
        {
            item.CurrentRoom.Contents.Remove(item);
            item.CurrentRoom = null;

            character.Contents.Add(item);

            Console.WriteLine($"Picked up { item.Name.ToLower()}!");

        }

        public void Drop(Item item, Character character)
        {
            character.Contents.Remove(item);
            item.CurrentRoom = character.CurrentRoom;

            character.CurrentRoom.Contents.Add(item);

            Console.WriteLine($"Dropped {item.Name.ToLower()}!");
        }
    }
}
