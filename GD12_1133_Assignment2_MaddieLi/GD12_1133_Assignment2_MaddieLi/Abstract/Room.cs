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
        public virtual List<Item>? Contents { get; set; } = new List<Item>(); // list of items

        // PROPERTIES
        public abstract bool HasBeenEntered { get; set; }

        public bool[] _allowedDirections = new bool[4]; // existing directions
        public List<BaseCharacter> Inhabitants { get; set; } = new List<BaseCharacter>(); // list of characters 

        public int XPos { get; set; } // positions in grid
        public int YPos { get; set; }

        public Room North { get; set; } // directional linked rooms
        public Room East { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }

        public abstract void OnRoomEnter(); // when entering room for first time


        public void CanExit(Dir.Direction direction) // changes allowed direction to true
        {
            _allowedDirections[(int)direction] = true;
        }

        public void CannotExit(Dir.Direction direction) // changes allowed direction to true
        {
            _allowedDirections[(int)direction] = false;
        }

        public bool IsDirectionAllowed(Dir.Direction direction) // returns if diretion is allowed
        {
            return _allowedDirections[(int)direction];
        }

        public virtual Room CheckIsInRoom(BaseCharacter character) // check if character is in room
        {
            if (character.CurrentRoom == this)
            {
                return this;
            }

            return null;
        }

        public void SetRooms(Room north, Room east, Room south, Room west) // creates rooms
        {
            North = north;
            East = east;
            South = south;
            West = west;
        }

        // CONSTRUCTOR
        public Room(int x, int y, string Name, string Glance, string Look)
        {
            this.XPos = x;
            this.YPos = y;
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;

        }
    }
}
