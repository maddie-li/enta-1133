using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.People
{
    internal class CharacterSetup
    {
        public CreateCharacter player = new CreateCharacter
        (
            "Player",
            "Yourself",
            "It's you, the player.",
            new List<Thing>()
        );

    }
}
