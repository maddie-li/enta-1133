using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab3_Maddie_Li
{
    internal class DiceRoller
    {
        Random random = new Random();

        internal int Roll(int sides)
        {

            // because range should include highest number
            sides += 1;

            // random number in range
            int output = random.Next(1, sides);

            return output;
        }

        
    }
}
