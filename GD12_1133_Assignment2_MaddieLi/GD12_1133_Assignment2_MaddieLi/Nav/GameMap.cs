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
        BasicRoom[,] roomArray;

        public void CreateMap() // sets up map and makes empty 
        {
            roomArray = new BasicRoom[MapSize, MapSize];

            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    string name = $"Room at ({x}, {y})";
                    string glance = $"Short description of Room at ({x}, {y}).";
                    string look = $"Long description of Room at ({x}, {y}).";
                    List<Item> contents = new List<Item>();

                    roomArray[x, y] = new BasicRoom(x, y, name, glance, look, contents);
                }
            }
        }

        public Room RoomSetup(int x, int y, string name, string glance, string look, List<Item> contents)
        {
            BasicRoom room = (BasicRoom)roomArray[x, y];

            room.Name = name;
            room.XPos = x;
            room.YPos = y;
            room.Glance = glance;
            room.Look = look;
            room.Contents = contents;

            return room;
        }

        public void SetConnections()
        {
            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    Room currentRoom = (Room)roomArray[x, y];

                    Room northRoom = FindRoom(x, y, Directions.Dir.Direction.n);
                    Room eastRoom = FindRoom(x, y, Directions.Dir.Direction.e);
                    Room southRoom = FindRoom(x, y, Directions.Dir.Direction.s);
                    Room westRoom = FindRoom(x, y, Directions.Dir.Direction.w);

                    currentRoom.SetRooms(northRoom, eastRoom, southRoom, westRoom);
                }
            }
        }

        public Room FindRoom(int x, int y, Directions.Dir.Direction dir)
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
            return null;
        }

    }
}
