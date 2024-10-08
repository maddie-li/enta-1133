using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Actions;
using GD12_1133_Assignment2_MaddieLi.People;

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    internal class RoomSetup
    {
        public CreateRoom hallway = new CreateRoom
        (
            "Hallway",
            "A narrow corridor",
            "A narrow corridor, but you can't see much as it is very dark.",
            new List<Thing>(),
            new Dictionary<string, Room>()

        );
    }
}
