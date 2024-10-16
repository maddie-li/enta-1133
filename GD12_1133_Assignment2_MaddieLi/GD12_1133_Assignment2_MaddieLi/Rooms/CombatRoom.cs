using GD12_1133_Assignment2_MaddieLi.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    internal class CombatRoom : BasicRoom
    {
        public CombatRoom(int x, int y, string name, string glance, string look, List<Item> contents)
        : base(x, y, name, glance, look, contents) { }

    }
}
