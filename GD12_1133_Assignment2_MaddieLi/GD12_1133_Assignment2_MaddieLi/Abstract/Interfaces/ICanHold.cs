using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces
{
    internal interface ICanHold<Item> // Interface for holding stuff
    {
        public abstract List<Item>? Contents { get; set; } // list of items

    }
}
