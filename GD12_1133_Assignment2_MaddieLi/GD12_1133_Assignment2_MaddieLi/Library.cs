using GD12_1133_Assignment2_MaddieLi.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi
{
    public static class Library
    {
        public static List<Thing> AllThings = new List<Thing>();
        public static void AddThing(Thing thing)
        {
            AllThings.Add(thing);   
        }
    }
}
