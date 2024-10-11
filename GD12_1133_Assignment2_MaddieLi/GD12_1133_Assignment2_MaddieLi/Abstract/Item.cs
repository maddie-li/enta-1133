using System;
using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Item : IInfo // item is a thing that can be picked up or used
    {
        public abstract void Use(Item? target = null);

    }
}
