using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Items
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    internal class BasicItem : Item
    {
        public bool IsPortable { get; set; }

        public override void Use()
        {
            Console.WriteLine($"{Name} has been used.");
        }

        public override void Use(Thing target)
        {
            Console.WriteLine($"{Name} has been used om {target}.");
        }
    }
}
