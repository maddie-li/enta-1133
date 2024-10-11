using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces
{
    public interface IInfo
    {
        public string Name { get; set; } // name
        public string Glance { get; set; } // short description (known room description, object in inventory or location)
        public string Look { get; set; } // long description (new room description, examining object)

    }
}
