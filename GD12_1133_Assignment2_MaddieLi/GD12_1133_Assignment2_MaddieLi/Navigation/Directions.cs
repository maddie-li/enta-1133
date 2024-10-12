using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Navigation
{
    public class Directions
    {
        public string[] GameDir =
        {
            "north",
            "south",
            "east",
            "west"
        };

        public Dictionary<string, string> GameDirDict = new Dictionary<string, string>()
        {
            { "n", "north" },
            { "s", "south" },
            { "e", "east" },
            { "w", "west" },

        };

    }
}
