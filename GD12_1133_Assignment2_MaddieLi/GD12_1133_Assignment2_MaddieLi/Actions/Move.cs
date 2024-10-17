using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Directions;
using GD12_1133_Assignment2_MaddieLi.Nav;
using GD12_1133_Assignment2_MaddieLi.Rooms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Actions
{
    internal class Move
    {
        GameMap gameMap = new GameMap();

        public void Direction(Directions.Dir.Direction dir, BaseCharacter _targetChar)
        {
            // Console.WriteLine((int)dir);
            Room _currentRoom = _targetChar.CurrentRoom;
            Room _newRoom = null; ; 

            int _currentRoomX = _currentRoom.XPos;
            int _currentRoomY = _currentRoom.YPos;

            switch (dir)
            {
                case Directions.Dir.Direction.n:
                    if (_currentRoom.IsDirectionAllowed(Dir.Direction.n))
                    {
                        _newRoom = _currentRoom.North;
                    }
                    break;
                case Directions.Dir.Direction.e:
                    if (_currentRoom.IsDirectionAllowed(Dir.Direction.e))
                    {
                        _newRoom = _currentRoom.East;
                    }
                    break;
                case Directions.Dir.Direction.s:
                    if (_currentRoom.IsDirectionAllowed(Dir.Direction.s))
                    {
                        _newRoom = _currentRoom.South;
                    }
                    break;
                case Directions.Dir.Direction.w:
                    if (_currentRoom.IsDirectionAllowed(Dir.Direction.w))
                    {
                        _newRoom = _currentRoom.West;
                    }
                    break;
            }

            if (_newRoom != null) { 
            
                _targetChar.CurrentRoom = _newRoom;
                // Console.WriteLine($"Moving from {_currentRoom.Name} to {_newRoom.Name}!");
            }
            else
            {
                Console.WriteLine("You can't go that way.");
            }

            
        }
    }
}
