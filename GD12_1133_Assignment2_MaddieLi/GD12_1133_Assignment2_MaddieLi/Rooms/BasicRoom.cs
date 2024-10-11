using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using GD12_1133_Assignment2_MaddieLi.Items;
    using GD12_1133_Assignment2_MaddieLi.People;
    using Microsoft.VisualBasic;
    public class BasicRoom : Room
    {
        private Dictionary<string, Room> _exits { get; set; }
        
        // getters and setters from I_Container
        public override List<Thing>? Contents
        {
            get { return _contents; }

            set { _contents = value; }
        }

        // getters and setters from Room
        public override Dictionary<string, Room> Exits
        {
            get { return _exits; }

            set { _exits = value; }
        }
        public override bool HasBeenEntered
        { 
                get { return _hasBeenEntered; }
                set { _hasBeenEntered = value; }
        } 

        // FUNCTIONS
        public override void OnEnterRoom()
        {
            

        }

        // CONSTRUCTOR
        
        public BasicRoom(string Name, string Glance, string Look, List<Thing> Contents, Dictionary<string, Room> Exits)
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
           this.Contents  = Contents;
            _exits = Exits;
            
        }
    }

}
