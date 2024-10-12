using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.People;
using GD12_1133_Assignment2_MaddieLi.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi
{
    public class GameManager
    {
        public void StartGame()
        {
            Combatant player = new Combatant("The player", "Yourself", "It's you, the player", new List<Item> { });
            BasicRoom hallway = new BasicRoom("Hallway", "A hallway", "A long, dark hallway", new List<Item> { } , new List<Character> { player });
            
            hallway.OnRoomIntro();
            
        }
    }
}
