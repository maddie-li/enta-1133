using GD12_1133_Assignment2_MaddieLi;
using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    internal class CombatRoom : Room // CombatRoom has a random chance of spawning enemy to begin combat
    {
        Combat combat = new Combat();
        Roller r = new Roller();

        int _oddsOfCombat = 3;

        public override void OnRoomEnter()
        {
            base.OnRoomEnter();

            if (r.Roll(_oddsOfCombat) == _oddsOfCombat) // if combat is to begin
            {
                 Console.WriteLine("COMBAT TIME!");
                combat.CombatSetup();

            }
        }

        public CombatRoom(int x, int y, string name, string glance, string look)
        : base(x, y, name, glance, look) { }

    }
}
