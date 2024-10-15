using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
using GD12_1133_Assignment2_MaddieLi.Directions;
using GD12_1133_Assignment2_MaddieLi.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Room : IInfo, ICanHold<Item> // room is an object that has contents and exits
    {
        // from INFO
        public abstract string Name { get; set; } // name
        public abstract string Glance { get; set; } // short description (known room description, object in inventory or location)
        public abstract string Look { get; set; } // long description (new room description, examining object)

        // from CAN HOLD
        public virtual List<Item>? Contents { get; set; } // list of items

        // PROPERTIES
        public abstract bool HasBeenEntered { get; set; }
        public virtual List<Character>? Inhabitants { get; set; } // list of characters in room

        bool[] _allowedDirections = new bool[4]; // existing directions

        public int XPos { get; set; } 
        public int YPos { get; set; }

        public Room North { get; private set; }
        public Room East { get; private set; }
        public Room South { get; private set; }
        public Room West { get; private set; }

        public abstract void OnRoomEnter(); // when entering room for first time

        public void AllowedExits()
        {
            _allowedDirections[0] = false;
            _allowedDirections[1] = false;
            _allowedDirections[2] = false;
            _allowedDirections[3] = false;
        }

        public bool IsDirectionAllowed(Dir.Direction direction)
        {
            return _allowedDirections[(int)direction];
        }

        public virtual Room CheckIsInRoom(Character character) // check if character is in room
        {
            if (character.CurrentRoom == this)
            {
                return this;
            }

            return null;
        }

        public void AddItem(Item item) // add item to room
        {
            Contents!.Add(item);
        }


        public void SetRooms(Room north, Room east, Room south, Room west)
        {
            North = north;
            East = east;
            South = south;
            West = west;
        }

        // CONSTRUCTOR
        public Room(int x, int y, string Name, string Glance, string Look, List<Item> Contents)
        {
            this.XPos = x;
            this.YPos = y;
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.Contents = Contents;

        }
    }
}
