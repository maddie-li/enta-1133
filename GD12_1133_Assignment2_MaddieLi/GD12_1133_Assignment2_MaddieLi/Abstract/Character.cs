using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Character : IInfo
    {
        // INFO
        public abstract string Name { get; set; } // name
        public abstract string Glance { get; set; } // short description (known room description, object in inventory or location)
        public abstract string Look { get; set; } // long description (new room description, examining object)

        // FUNCTIONS
        public abstract void TalkTo(); // talk to character
    }
}
