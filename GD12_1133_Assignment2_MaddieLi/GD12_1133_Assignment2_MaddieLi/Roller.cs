using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi
{
    internal class Roller
    {
        Random random = new Random();   
        public int Roll(int sides)
        {
            // because range should include highest number
            sides += 1;

            return random.Next(1, sides);

        }

    }
}
