using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab3_Maddie_Li
{
    internal class AssignmentText
    {
        internal void Intro()
        {
            // instantiating
            GameManager manager = new GameManager();

            Console.WriteLine("Welcome to Maddie Li's Lab 3 (2024-09-20)\n");
            manager.GameStart();
        }
    }
}
