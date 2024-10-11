using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces
{
    internal interface ICanBeHeld
    {
        public void PutIn(Item item, List<Item> place)
        {
           place.Add(item);

        }
    }
}
