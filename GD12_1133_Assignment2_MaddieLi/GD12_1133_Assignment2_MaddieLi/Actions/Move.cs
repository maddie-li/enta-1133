using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Directions;
using GD12_1133_Assignment2_MaddieLi.Nav;
using GD12_1133_Assignment2_MaddieLi.Characters;
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

        public void Direction(Directions.Dir.Direction dir, Player _targetChar)
        {
            BaseRoom _currentRoom = _targetChar.CurrentRoom;
            BaseRoom _newRoom = null!; 

            int _currentRoomX = _currentRoom.XPos;
            int _currentRoomY = _currentRoom.YPos;

            switch (dir)
            {
                case Directions.Dir.Direction.n:
                    if (_currentRoom.IsDirectionAllowed(Dir.Direction.n))
                    {
                        _newRoom = _currentRoom.NorthExit;
                    }
                    break;
                case Directions.Dir.Direction.e:
                    if (_currentRoom.IsDirectionAllowed(Dir.Direction.e))
                    {
                        _newRoom = _currentRoom.EastExit;
                    }
                    break;
                case Directions.Dir.Direction.s:
                    if (_currentRoom.IsDirectionAllowed(Dir.Direction.s))
                    {
                        _newRoom = _currentRoom.SouthExit;
                    }
                    break;
                case Directions.Dir.Direction.w:
                    if (_currentRoom.IsDirectionAllowed(Dir.Direction.w))
                    {
                        _newRoom = _currentRoom.WestExit;
                    }
                    break;
            }

            if (_newRoom != null) { 
            
                _targetChar.CurrentRoom = _newRoom;
            }
            else
            {
                Console.WriteLine("You can't go that way.");
            }

            
        }
    }
}
