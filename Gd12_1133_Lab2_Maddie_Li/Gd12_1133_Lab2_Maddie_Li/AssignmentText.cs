using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gd12_1133_Lab2_Maddie_Li
{
    internal class AssignmentText
    {
        internal void Intro()
        {
            // instantiating
            GameManager manager = new GameManager();

            // intro text
            Console.WriteLine("Welcome to Maddie Li's Lab 2 (2024-09-13)");
            manager.Play();
        }

        internal void Outro()
        {
            // outro text
            Console.WriteLine("+ is add");
            Console.WriteLine("- is subtract");
            Console.WriteLine("/ is divide");
            Console.WriteLine("* is multiply");
            Console.WriteLine("++ is add 1");
            Console.WriteLine("-- is subtract 1");
            Console.WriteLine("% is divide but it returns the remainder");

            Console.WriteLine("Goodbye!");

        }
    }
}
