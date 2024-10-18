using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Actions
{
    internal class Look
    {
        public void Inventory(Character character)
        {
            List<String> _inventory = new List<String>(); // temporary list of strings for inventory

            foreach (BaseItem i in character.Contents) // for each item the character is holding
            {
                _inventory.Add(i.Glance.ToString()); // add it to the temporary list

            }

            if (_inventory!.Count == 0) // if holding no items
            {
                Console.WriteLine("You aren't holding anything.");
            }
            else // print each item
            {
                Console.WriteLine("You are holding: ");

                foreach (String i in _inventory)
                {
                    Console.WriteLine(i.ToLower());
                }
            }
        }

        public void Examine(BaseItem item)
        {
            Console.WriteLine(item.Look);
        }

        public void Examine(BaseCharacter character)
        {
            Console.WriteLine(character.Look);
        }

        public void Examine(BaseRoom room)
        {
            Describe(room);
        }

        public void Describe(BaseRoom _targetRoom)
        {
            Console.WriteLine($"{_targetRoom.Name.ToUpper()}\n{_targetRoom.Look}\n{_targetRoom.Glance}");

            _describeContents( _targetRoom );
            
        }

        public void Describe(BaseRoom _targetRoom, bool HasBeenEntered)
        {
            if (_targetRoom.HasBeenEntered)
            {
                Console.WriteLine($"{_targetRoom.Name.ToUpper()}\n{_targetRoom.Glance}");
            }
            else
            {
                Console.WriteLine($"{_targetRoom.Name.ToUpper()}\n{_targetRoom.Look}\n{_targetRoom.Glance}");
                _targetRoom.HasBeenEntered = true;
            }

            _describeContents(_targetRoom);
        }

        private void _describeContents(BaseRoom _targetRoom)
        {
            List<String> _roomContents = new List<String>(); // temporary list of strings
            
            foreach (BaseItem i in _targetRoom.Contents)
            {
                _roomContents.Add(i.Glance.ToString()); // add item to list

            }

            // prints each item in room contents
            if (_roomContents != null && _roomContents!.Count != 0)
            {
                Console.Write("\nIn this room you can see ");

                foreach (String i in _roomContents)
                {
                    Console.Write(i.ToLower());
                }

                Console.WriteLine("."); // make this write better?

            }
        }
    }
}
