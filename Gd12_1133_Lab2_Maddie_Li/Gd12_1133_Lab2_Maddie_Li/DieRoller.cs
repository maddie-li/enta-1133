using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gd12_1133_Lab2_Maddie_Li
{
    internal class DieRoller
    {
        Random random = new Random();
        internal int currentOutput;

        internal void Roll(int sides)
        {

            // because range should include highest number
            sides += 1;

            // random number in range
            int output = random.Next(1,sides);

            Console.WriteLine(output);
            currentOutput = output;
            
        }
    }
}
