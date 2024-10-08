using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Item : Thing // item is a thing that can be picked up or used
    { 
        public bool IsPortable { get; set; }

        public abstract void Use();
        public abstract void Use(Thing target);
    } 
}
