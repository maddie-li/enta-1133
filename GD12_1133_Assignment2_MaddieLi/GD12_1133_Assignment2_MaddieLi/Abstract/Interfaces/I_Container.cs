using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces
{
    interface I_Container<T> // for holding stuff
    {
        public abstract List<T>? contents { get; set; }

    }
}
