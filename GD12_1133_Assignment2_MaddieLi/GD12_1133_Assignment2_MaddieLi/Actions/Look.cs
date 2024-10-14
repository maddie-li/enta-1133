using GD12_1133_Assignment2_MaddieLi.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Actions
{
    internal class Look
    {
        public void Describe(Room _targetRoom)
        {
            Console.WriteLine($"{_targetRoom.Name}\n{_targetRoom.Look}");

            _describeContents( _targetRoom );
            
        }

        public void Describe(Room _targetRoom, bool HasBeenEntered)
        {
            if (_targetRoom.HasBeenEntered)
            {
                Console.WriteLine($"{_targetRoom.Name.ToUpper()}\n{_targetRoom.Glance}");
            }
            else
            {
                Console.WriteLine($"{_targetRoom.Name}\n{_targetRoom.Look}");
                _targetRoom.HasBeenEntered = true;
            }

            _describeContents(_targetRoom);
        }

        private void _describeContents(Room _targetRoom)
        {
            if (_targetRoom.Contents!.Count == 0)
            {
                Console.WriteLine("There is nothing in the room.");
            }
            else
            {
                Console.WriteLine("In this room there is:");

                foreach (Item i in _targetRoom.Contents)
                {
                    Console.WriteLine(i.Glance);
                }
            }

            if (_targetRoom.Inhabitants == null)
            {
                Console.WriteLine("There are no people here.");
            }
            else if (_targetRoom.Inhabitants!.Count == 0)
            {
                Console.WriteLine("There are no people here.");
            }
            else
            {
                Console.WriteLine("In this room there is:");

                foreach (Character i in _targetRoom.Inhabitants)
                {
                    Console.WriteLine(i.Glance);
                }
            }
        }
    }
}
