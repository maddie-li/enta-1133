using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Directions;
using GD12_1133_Assignment2_MaddieLi.People;
using GD12_1133_Assignment2_MaddieLi.Rooms;
using GD12_1133_Assignment2_MaddieLi.Actions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GD12_1133_Assignment2_MaddieLi
{
    public class GameManager
    {
        // variables
        bool isGamePlaying = true;
        public Room? PlayerLocation;

        public string? rawString; // raw input

        public List<Character> CharactersInGame = new List<Character>();

        // parser dictionary

        public Dictionary<string, string> Abbrv = new Dictionary<string, string>()
        {
            { "look", "l" },
            { "help", "h" },

        };


        // utility classes
        ProjectText write = new ProjectText();
        Look Look = new Look();


        public void StartGame() // start game and loop
        {

            // setup
            BasicRoom hallway = new BasicRoom("Hallway", "A hallway", "A long, dark hallway", new List<Item> { });
            Combatant player = new Combatant("The player", "Yourself", "It's you, the player", hallway, new List<Item> { });


            Console.WriteLine(write.IntroText+"\n");

            PlayerLocation = hallway;
            Look.Describe(PlayerLocation);

            while (isGamePlaying)
            {
                TurnUpdate(player);
                GetInput();
                
            }
            
        }

        public void TurnUpdate(Character player)
        {
            // UPDATE PLAYER LOCATION
            PlayerLocation = player.CurrentRoom;

            // UPDATE CHARACTERS IN ROOM
            List<Character> _charactersInRoom = new List<Character>();

            foreach (Character character in CharactersInGame)
            {
                if (character.CurrentRoom == PlayerLocation)
                {
                    PlayerLocation.Inhabitants!.Add(character);
                }
            }
            
        }

        public void GetInput() // read input
        {
            // GET INPUT
            rawString = null;

            while (string.IsNullOrWhiteSpace(rawString)) // reprompt if null empty or whitespace
            {
                Console.Write("\n> "); // prompter
                rawString = Console.ReadLine();

            }

            // CLEAN UP INPUT
            string trimmed = rawString.Trim(); // trim whitespace
            string input = trimmed.ToLower(); // make lowercase

            // SHORTEN INPUT
            if (Abbrv.ContainsKey(input))
            {
                input = Abbrv[input];

            }

            switch (input)
            {
                case "h":
                    Console.WriteLine(write.HelpText());
                    break;
                case "l":
                    Look.Describe(PlayerLocation);
                    break;
                default:
                    Console.WriteLine("Can't understand this command!");
                    break;
            }

            return;

        }

        
    }
}
