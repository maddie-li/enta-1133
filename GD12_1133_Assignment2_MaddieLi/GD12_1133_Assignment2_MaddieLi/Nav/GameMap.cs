using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Nav
{
    internal class GameMap
    {
        int MapSize = 3;
        public BaseRoom[,] roomArray;

        public void CreateMap() // sets up map and makes empty 
        {
            roomArray = new Room[MapSize, MapSize];

            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    roomArray[x, y] = CreateRoom(x, y);
                }
            }
        }

        private BaseRoom CreateRoom(int x, int y)
        {
            var _combatRoomCoords = new List<(int, int)>
            {
                (0, 1),
                (1, 0),
                (2, 2),
                (1, 1),
                (2, 1),
                (1, 2)
            };

            var _treasureRoomCoords = new List<(int, int)>
            {
                (0, 2),
                (2, 0),
            };

            if (_combatRoomCoords.Contains((x, y)))
            {
                return new CombatRoom(x, y, $" Combat Room at ({x}, {y})",
                                        $"Short description of Combat Room.",
                                        $"Long description of Combat Room.");
            }
            else if (_treasureRoomCoords.Contains((x, y)))
            {
                return new TreasureRoom(x, y, $" Treasue Room at ({x}, {y})",
                                        $"Short description of Treasyure Room.",
                                        $"Long description of Treasure Room.");
            }
            else
            {
                return new Room(x, y, $" Room at ({x}, {y})",
                                        $"Short description of Room.",
                                        $"Long description of Room.");
            }
        }

        public BaseRoom RoomSetup(int x, int y, string name, string glance, string look)
        {
            Room room = (Room)roomArray[x, y];

            room.Name = name;
            room.XPos = x;
            room.YPos = y;
            room.Glance = glance;
            room.Look = look;

            SetConnections();
            return room;
        }

        public void SetConnections()
        {
            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    BaseRoom currentRoom = (BaseRoom)roomArray[x, y];

                    BaseRoom northRoom = FindRoom(x, y, Directions.Dir.Direction.n);
                    BaseRoom eastRoom = FindRoom(x, y, Directions.Dir.Direction.e);
                    BaseRoom southRoom = FindRoom(x, y, Directions.Dir.Direction.s);
                    BaseRoom westRoom = FindRoom(x, y, Directions.Dir.Direction.w);

                    currentRoom.SetRooms(northRoom, eastRoom, southRoom, westRoom);
                }
            }
        }

        public BaseRoom FindRoom(int x, int y, Directions.Dir.Direction dir)
        {
            switch (dir)
            {
                case Directions.Dir.Direction.n:
                    if (x > 0) return roomArray[x - 1, y];
                    break;
                case Directions.Dir.Direction.e:
                    if (y < MapSize - 1) return roomArray[x, y + 1];
                    break;
                case Directions.Dir.Direction.s:
                    if (x < MapSize - 1) return roomArray[x + 1, y];
                    break;
                case Directions.Dir.Direction.w:
                    if (y > 0) return roomArray[x, y - 1];
                    break;
            }
            return null!;
        }

    }
}
