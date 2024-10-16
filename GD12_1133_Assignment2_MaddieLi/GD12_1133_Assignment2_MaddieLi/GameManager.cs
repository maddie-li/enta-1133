using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Directions;
using GD12_1133_Assignment2_MaddieLi.People;
using GD12_1133_Assignment2_MaddieLi.Items;
using GD12_1133_Assignment2_MaddieLi.Rooms;
using GD12_1133_Assignment2_MaddieLi.Actions;
using GD12_1133_Assignment2_MaddieLi.Nav;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection.Emit;

namespace GD12_1133_Assignment2_MaddieLi
{
    public class GameManager
    {
        // variables
        bool isGamePlaying = true;
        public Room? PlayerLocation;

        public string? rawString; // raw input

        // characters
        public List<Character> CharactersInGame = new List<Character>();
        public Character player;
        public Character guard;

        // items
        public List<Item> ItemsInGame = new List<Item>();
        public Item gun;
        public Item key;

        // parser dictionary

        public Dictionary<string, string> Abbrv = new Dictionary<string, string>()
        {
            { "look", "l" },
            { "help", "h" },
            { "north", "n" },
            { "east", "e" },
            { "south", "s" },
            { "west", "w" },

        };


        // utility classes
        ProjectText write = new ProjectText();

        GameMap gameMap = new GameMap();
        Look Look = new Look();
        Move Move = new Move();

        

        public void SetUp()
        {
            // setup

            gameMap.CreateMap();
            
            Room boat = gameMap.RoomSetup(0, 0, "Boat", "The way out is east.", "The boat you arrived in.");
            boat.CanExit(Dir.Direction.e);

            Room dock = gameMap.RoomSetup(0, 1, "Dock", "There is a door in the east wall and the loading bay is south.", "A loading dock, exposed to the ocean.");
            dock.CanExit(Dir.Direction.e);
            dock.CanExit(Dir.Direction.s);

            Room armory = gameMap.RoomSetup(0, 2, "Armory", "The way back out is west", "A strangely constructed room filled with weapons.");
            armory.CanExit(Dir.Direction.w);

            Room observation = gameMap.RoomSetup(1, 0, "Observation deck", "The loading bay is east and security is south.", "Raised above the port, you can see everything.");
            observation.CanExit(Dir.Direction.e);
            observation.CanExit(Dir.Direction.s);

            Room bay = gameMap.RoomSetup(1, 1, "Loading bay", "The dock is north, the warehouse east, the gate south, and the observation deck north.", "A busy central hub where people shuttle product in all four directions..");
            bay.CanExit(Dir.Direction.e);
            bay.CanExit(Dir.Direction.e);

            Room warehouse = gameMap.RoomSetup(1, 2, "Warehouse", "The loading bay is west and the locked office is south.", "A cavernous warehouse.");
            bay.CanExit(Dir.Direction.w);
            bay.CanExit(Dir.Direction.s);

            Room security = gameMap.RoomSetup(2, 0, "Security", "The observation deck is north.", "A messsy and outdated security room full of camera feeds.");
            bay.CanExit(Dir.Direction.n);

            Room gate = gameMap.RoomSetup(2, 1, "Gate", "", "");
            bay.CanExit(Dir.Direction.n);

            Room office = gameMap.RoomSetup(2, 2, "Office", "The warehouse is north", "Lavishly decorated.");
            bay.CanExit(Dir.Direction.n);

            player = new Combatant("The player", "Yourself", "It's you, the player", 10, boat, new List<Item> { });
            guard = new Combatant("Securty guard", "A security guard", "A security guard employed by the port", 10, dock, new List<Item> { });
            CharactersInGame.Add(player);
            CharactersInGame.Add(guard);

            gun = new Weapon("Gun", "A gun", "A weapon you can use", 10, armory);
            key = new BasicItem("Key card", "A key card", "A key card for the offfice", boat);
            ItemsInGame.Add(gun);
            ItemsInGame.Add(key);


            StartGame(boat);
        }


        public void StartGame(Room _startingRoom) // start game and loop
        {
            Console.WriteLine(write.IntroText+"\n");

            PlayerLocation = _startingRoom;
            TurnUpdate(player);
            Look.Describe(PlayerLocation);

            while (isGamePlaying)
            {
                GetInput();
                TurnUpdate(player);
            }
            
        }

        public void TurnUpdate(Character player)
        {
            // UPDATE PLAYER LOCATION
            PlayerLocation = player.CurrentRoom;

            // UPDATE CHARACTERS IN ROOM
            player.CurrentRoom.Inhabitants.Clear();
            player.CurrentRoom.Contents.Clear();

            foreach (Character character in CharactersInGame)
            {
                if (character.CurrentRoom == PlayerLocation)
                {
                    player.CurrentRoom.Inhabitants.Add(character);
                }
            }
            foreach (Item item in ItemsInGame)
            {
                if (item.CurrentRoom == PlayerLocation)
                {
                    player.CurrentRoom.Contents.Add(item);
                }
            }

            // Console.WriteLine(player.CurrentRoom.Inhabitants.Count.ToString()); for testing

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
                    Look.Describe(PlayerLocation!);
                    break;
                case "n":
                    Move.Direction(Directions.Dir.Direction.n, player);
                    if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                    {
                        TurnUpdate(player);
                        PlayerLocation.OnRoomEnter();
                    }
                    break;
                case "e":
                    Move.Direction(Directions.Dir.Direction.e, player);
                    if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                    {
                        TurnUpdate(player);
                        PlayerLocation.OnRoomEnter();
                    }
                    break;
                case "s":
                    Move.Direction(Directions.Dir.Direction.s, player);
                    if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                    {
                        TurnUpdate(player);
                        PlayerLocation.OnRoomEnter();
                    }
                    break;
                case "w":
                    Move.Direction(Directions.Dir.Direction.w, player);
                    if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                    {
                        TurnUpdate(player);
                        PlayerLocation.OnRoomEnter();
                    }
                    break;
                default:
                    Console.WriteLine("Can't understand this command!");
                    break;
            }

            return;

        }

        
    }
}
