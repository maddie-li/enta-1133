using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    
    using Microsoft.VisualBasic;

    public class RoomSetup : Room

    {
        // PROPERTIES 

        // private fields from Object
        private string _name;
        private string _glance;
        private string _look;

        // private fields from I_Container
        private List<Thing>? _contents;

        // private fields from Room
        private Dictionary<string, Room> _exits { get; set; }
        private bool _hasBeenEntered;

        // getters and setters from Object
        public override string Name 
        {
            get { return _name; }

            set { _name = value; }
        }
        public override string Glance
        {
            get { return _glance; }

            set { _glance = value; }
        }
        public override string Look 
        {
            get { return _look; }

            set { _look = value; }
        }

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
            if (HasBeenEntered)
            {
                Console.WriteLine($"{_name}\n{_glance}");
            }
            else
            {
                Console.WriteLine($"{_name}\n{_look}");
                HasBeenEntered = true;
            }

            if (_contents.Count == 0)
            {
                Console.WriteLine("There is nothing in the room.");
            }
            else
            {
                Console.WriteLine("You can see:");
                foreach (Thing i in _contents)
                {
                    Console.WriteLine(i.Name);

                }
            }

        }

        // CONSTRUCTOR
        public RoomSetup(string Name, string Glance, string Look, List<Thing> Contents, Dictionary<string, Room> Exits)
        {
            _name = Name;
            _glance = Glance;
            _look = Look;
            _contents = Contents;
            _exits = Exits;
            
        }
    }

}
