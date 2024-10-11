using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Actions;
using GD12_1133_Assignment2_MaddieLi.Items;
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
    internal class RoomCreate
    {
        // REFERENCE
        private CharacterCreate character;
        private ItemCreate item;

        // ROOMS
        public RoomSetup hallway;

        public RoomCreate()
        {
            // reference
            character = new CharacterCreate();
            item = new ItemCreate();

            // rooms
            hallway = new RoomSetup
            (
                "Hallway",
                "A narrow corridor",
                "A narrow corridor, but you can't see much as it is very dark.",
                new List<Thing> { character.player },
                new Dictionary<string, Room>()

            );
        }
    }
}
