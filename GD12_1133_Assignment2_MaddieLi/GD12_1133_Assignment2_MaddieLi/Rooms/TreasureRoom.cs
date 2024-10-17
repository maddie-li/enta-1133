using GD12_1133_Assignment2_MaddieLi.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    internal class TreasureRoom : Room // TreasureRoom can be searched to show that there is an item in the room
    {
        public void CreateTreasure(bool itemFound)
        {

        }

        public TreasureRoom(int x, int y, string name, string glance, string look)
        : base(x, y, name, glance, look) { }

    }
}
