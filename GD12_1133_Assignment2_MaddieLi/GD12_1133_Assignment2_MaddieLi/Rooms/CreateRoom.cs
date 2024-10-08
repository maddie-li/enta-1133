using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    
    using Microsoft.VisualBasic;

    public class CreateRoom : Room
    {
        // creating private fields
        private string _name;
        private string _glance;
        private string _look;
        private List<Thing>? _contents; 
        private Dictionary<string, Room> _exits { get; set; } 

        // contents
        public override List<Thing>? Contents 
        {
            get { return _contents;  }
            
            set { _contents = value; }
        }

        // exits
        public override Dictionary<string, Room> Exits
        {
            get { return _exits; }

            set { _exits = value; }
        }

        // been entered
        public bool HasBeenEntered { get; set; } // room hasBeenEntered

        // on enter room
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
                    Console.WriteLine(i);
                }
            }

        }

        public CreateRoom(string Name, string Glance, string Look, List<Thing> Contents, Dictionary<string, Room> Exits)
        {
            _name = Name;
            _glance = Glance;
            _look = Look;
            _contents = Contents;
            _exits = Exits;
            
        }
    }

}
