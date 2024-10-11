using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.People;
using GD12_1133_Assignment2_MaddieLi.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi
{
    internal class GameManager
    {
        RoomCreate roomSetup = new RoomCreate();
        public void StartGame()
        {
            roomSetup.hallway.OnEnterRoom();

        }
    }
}
