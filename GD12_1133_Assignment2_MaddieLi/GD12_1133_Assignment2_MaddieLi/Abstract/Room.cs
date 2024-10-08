using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Abstract
{
    public abstract class Room : Object, I_Container<Thing> // room is an object that has contents and exits
    {
         public abstract List<Thing>? Contents { get; set; } // room contents
         public abstract Dictionary<string, Room> Exits { get; set; } // room exits
         public bool HasBeenEntered { get; set; } // room hasBeenEntered
         public abstract void OnEnterRoom();
    }
}
