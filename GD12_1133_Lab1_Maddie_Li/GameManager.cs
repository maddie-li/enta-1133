using GD12_1133_Lab1_Maddie_Li.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab1_Maddie_Li
{
    internal class GameManager
    {
        private bool againstComputer = true;

        internal void PlayGame()
        {
            Console.WriteLine("Welcome to Die vs. Die");

            DieRoller dieRollerInstance = new DieRoller();

            Console.WriteLine("This is a game about rolling dice with " + dieRollerInstance.numberOfSides + " sides!");

        }
    }
}
