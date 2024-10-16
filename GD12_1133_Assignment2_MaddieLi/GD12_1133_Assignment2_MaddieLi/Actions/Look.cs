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
            Console.WriteLine($"{_targetRoom.Name}\n{_targetRoom.Look}\n{_targetRoom.Glance}");

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
            string _typestring = _targetRoom.GetType().ToString();
            Console.WriteLine(_typestring);

            // ITEMS IN ROOM
            if (_targetRoom.Contents!.Count == 0)
            {
               // Console.WriteLine("There is nothing in the room.");
            }
            else
            {
                Console.WriteLine("In this room there is:");

                foreach (Item i in _targetRoom.Contents)
                {
                    Console.WriteLine(i.Glance);
                }
            }

            // CHARACTERS IN ROOM
            if (_targetRoom.Inhabitants == null)
            {
                // Console.WriteLine("There are no people here.");
            }
            else if (_targetRoom.Inhabitants!.Count == 0)
            {
                // Console.WriteLine("There are no people here.");
            }
            else
            {
                Console.WriteLine("In this room there is:");

                foreach (Character i in _targetRoom.Inhabitants)
                {
                    Console.WriteLine(i.Glance);
                }
            }

            /*// AVAILABLE EXITS
            List<bool> _directionsList = new List<bool>();

            foreach (var item in _targetRoom._allowedDirections)
            {
                _directionsList.Add(item);
            }

            List<string> _directionsListWrite = new List<string>();



            if (_directionsList[(int)Directions.Dir.Direction.n]) {
                _directionsListWrite.Add("north");
            }
            else if (_directionsList[(int)Directions.Dir.Direction.e])
            {
                _directionsListWrite.Add("east");
            }
            else if (_directionsList[(int)Directions.Dir.Direction.s])
            {
                _directionsListWrite.Add("south");
            }
            else if (_directionsList[(int)Directions.Dir.Direction.w])
            {
                _directionsListWrite.Add("west");
            }


            Console.WriteLine($"Exits: { String.Join(" ", _directionsListWrite)}");*/
        }
    }
}
