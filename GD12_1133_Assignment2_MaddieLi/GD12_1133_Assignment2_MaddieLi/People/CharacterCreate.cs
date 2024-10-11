using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Items;
using GD12_1133_Assignment2_MaddieLi.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.People
{
    internal class CharacterCreate
    {
        // REFERENCE
        private ItemCreate item;
        private RoomCreate room;

        // CHARACTERS
        public CharacterSetup player;

        public CharacterCreate()
        {
            // reference
            item = new ItemCreate();
            room = new RoomCreate();

            // characters
            player = new CharacterSetup
            (
                  "Player",
                  "Yourself",
                  "It's you, the player.",
                  room.hallway,
                  new List<Thing>()
            );

        }

    }
}
