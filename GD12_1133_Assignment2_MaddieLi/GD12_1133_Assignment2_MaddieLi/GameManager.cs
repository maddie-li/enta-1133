using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Directions;
using GD12_1133_Assignment2_MaddieLi.Characters;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GD12_1133_Assignment2_MaddieLi
{
    public class GameManager
    {
        // variables
        bool isGamePlaying = true;

        public static string? rawString; // raw input

        // objectives variables
        int Points = 0;
        int Turns = 0;

        // characters
        public Character player;
        public Character guard;

        // player variables
        public BaseRoom PlayerLocation;

        public static bool HasPickedUpRocket = false;
        public static bool HasPickedUpKey = false;
        public static bool HasPickedUpTape = false;

        public static bool HasDefeatedChief = false;
        public static bool HasDefeatedDirector = false;

        public static List<BaseItem> PlayerContents = new List<BaseItem>();
        public static int PlayerHealth = 0;


        // items
        public List<BaseItem> ItemsInGame = new List<BaseItem>();
        public Item key;
        public Item rocket;
        public Item tape;
        public Item knife;
        public Item pager;

        // utility classes

        GameMap gameMap = new GameMap();
        Look Look = new Look();
        Move Move = new Move();
        Take Take = new Take();

        // parser dictionary

        public Dictionary<string, string> Abbrv = new Dictionary<string, string>()
        {
            // COMMANDS
            { "look", "l" },
            { "examine", "x" },
            { "help", "h" },
            { "inventory", "i" },

            // DIRECTION
            { "north", "n" },
            { "east", "e" },
            { "south", "s" },
            { "west", "w" },

            // ITEMS
            { "key card", "key" },
            { "card", "key" },

            { "rocket launcher", "rocket" },
            { "launcher", "rocket" },

            { "security tape", "tape" },

            // ROOMS
            { "observation deck", "observation" },
            { "loading bay", "bay" },

        };

        string[] _articles = { "the", "at", "an", "a", "in", "to", "about", "who", "is", "what", "through", "towards" };

        public void SetUp()
        {
            // setup

            gameMap.CreateMap();

            // CREATE ROOMS
            BaseRoom boat = gameMap.RoomSetup(0, 0, "Boat", "The way out is east.", "You are in the cavernous hold of the boat you arrived in.");
            boat.CanExit(Dir.Direction.e);

            BaseRoom dock = gameMap.RoomSetup(0, 1, "Dock", "There is a door in a wall to the east and the loading bay is south.", "A loading dock, exposed to the ocean.");
            dock.CanExit(Dir.Direction.e);
            dock.CanExit(Dir.Direction.s);

            BaseRoom armory = gameMap.RoomSetup(0, 2, "Armory", "The way back out is west.", "A strangely constructed room filled with weapons.");
            armory.CanExit(Dir.Direction.w);

            BaseRoom observation = gameMap.RoomSetup(1, 0, "Observation deck", "The loading bay is east and security is south.", "Raised above the port, you can see everything.");
            observation.CanExit(Dir.Direction.e);
            observation.CanExit(Dir.Direction.s);

            BaseRoom bay = gameMap.RoomSetup(1, 1, "Loading bay", "The dock is north, the warehouse east, the gate south, and the observation deck west.", "A busy central hub where people shuttle product in every direction.");
            bay.CanExit(Dir.Direction.n);
            bay.CanExit(Dir.Direction.e);
            bay.CanExit(Dir.Direction.w);
            

            BaseRoom warehouse = gameMap.RoomSetup(1, 2, "Warehouse", "The loading bay is west and the office is south.", "A vast warehouse.");
            warehouse.CanExit(Dir.Direction.w);
            warehouse.CannotExit(Dir.Direction.s);

            BaseRoom security = gameMap.RoomSetup(2, 0, "Security", "The observation deck is north.", "A messsy and outdated security room full of camera feeds.");
            security.CanExit(Dir.Direction.n);

            BaseRoom gate = gameMap.RoomSetup(2, 1, "Gate", "", "");
            gate.CanExit(Dir.Direction.n);

            BaseRoom office = gameMap.RoomSetup(2, 2, "Office", "The warehouse is north", "Lavishly decorated.");
            office.CanExit(Dir.Direction.n);

            // CREATE PLAYER
            player = new Character("Player", "yourself", "It's you, the player", 50, boat, new List<BaseItem> {  });
            PlayerHealth = player.Health;

            // CREATE INVENTORY ITEMS
            knife = new Item("knife", "a knife", "A weapon you can use. Looks like it could do some damage.", null!);
            player.Contents.Add(knife);
            pager = new Item("pager", "a one-way pager", "", null!);
            player.Contents.Add(pager);

            StartGame(boat);
        }


        public void StartGame(BaseRoom _startingRoom) // start game and loop
        {
            Console.WriteLine(ProjectText.IntroText + "\n");

            PlayerLocation = _startingRoom;
            TurnUpdate(player);
            Look.Describe(PlayerLocation);

            while (isGamePlaying)
            {
                UseInput(GetInput());
                TurnUpdate(player);
                Turns += 1;
            }

        }

        public void GainPoint(int _points) 
        {
            Console.WriteLine($"+{_points} score!");
            Points += _points;

        }

        public void TurnUpdate(Character player)
        {
            // UPDATE PLAYER LOCATION
            PlayerLocation = player.CurrentRoom!;

            // REFRES ITEMS IN ROOM
            player.CurrentRoom.Contents.Clear();

            foreach (BaseItem item in ItemsInGame)
            {
                if (item.CurrentRoom == PlayerLocation)
                {
                    player.CurrentRoom.Contents.Add(item);
                }
            }

            // UPDATE COMBATANT COPY
            foreach (Item item in player.Contents)
            {
                PlayerContents.Add(item);
            }
            player.Health = PlayerHealth;

        }

        public static string GetInput()
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

            return input;
        }

        public void UseInput(string input) // read input
        {

            // SPLIT STRING
            List<string> _inputList = input.Split(" ").ToList();

            // remove articles
            for (int i = 0; i < _articles.Length; i++)
            {
                while (_inputList.Contains(_articles[i]))
                {
                    _inputList.Remove(_articles[i]);
                }
            }

            // SHORTEN INPUT
            for (int i = 0; i < _inputList.Count; i++)
            {

                if (Abbrv.ContainsKey(_inputList[i]))
                {
                    _inputList[i] = Abbrv[_inputList[i]];
                }

            }

            int _wordsInInput = _inputList.Count;

            string _inputVerb = "";
            string _inputSubject = "";

            // ONE WORD INPUT
            if (_wordsInInput <= 1)
            {
                _inputSubject = _inputList[0];

                switch (_inputSubject)
                {
                    // COMMANDS
                    case "h":
                        Console.WriteLine(ProjectText.HelpText());
                        return;
                    case "l":
                        Look.Describe(PlayerLocation!);
                        return;
                    case "i":
                        Look.Inventory(player);
                        return;
                    case "points":
                        Console.WriteLine($"You have {Points} points.");
                        return;
                    case "turns":
                        Console.WriteLine($"You have taken {Turns} turns.");
                        return;
                    case "health":
                        Console.WriteLine($"You are at {PlayerHealth}hp.");
                        return;
                    case "score":
                        Console.WriteLine($"You have {Points} points.");
                        Console.WriteLine($"You have taken {Turns} turns.");
                        return;
                    case "hint":
                        Console.WriteLine(ProjectText.PagerHint());
                        return;
                    case "z":
                    case "wait":
                    case "sleep":
                        Console.WriteLine("You wait.");
                        return;

                    // MOVEMENT
                    case "n":
                    case "e":
                    case "s":
                    case "w":
                        _inputVerb = "go";
                        break;

                    // EXAMINE OBJECTS
                    case "key":
                    case "card":
                    case "rocket":
                    case "player":
                    case "self":
                    case "guard":
                        _inputVerb = "look";
                        break;

                    // EXAMINE ROOM
                    case "boat":
                    case "dock":
                    case "armory":
                    case "observation":
                    case "bay":
                    case "warehouse":
                    case "security":
                    case "gate":
                    case "office":
                        _inputVerb = "look";
                        break;

                    default:
                        _inputVerb = "unknown";
                        break;
                }
            }
            // TWO WRD INPUT
            else
            {
                _inputVerb = _inputList[0];
                _inputSubject = _inputList[1];
            }

            // TWO WORD INPUT
            switch (_inputVerb)
            {
                // GO IN DIRECTION
                case "go":
                case "walk":
                case "move":
                    switch (_inputSubject)
                    {
                        // MOVEMENT
                        case "n":
                            Move.Direction(Directions.Dir.Direction.n, player);
                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            return;
                        case "e":
                            Move.Direction(Directions.Dir.Direction.e, player);
                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            return;
                        case "s":
                            if (PlayerLocation == gameMap.roomArray[1, 2]) // getting into office
                            {
                                if (!HasPickedUpKey)
                                {
                                    Console.WriteLine("You can't get into the office. It's locked.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("You use the key card to unlock the office door.");
                                    Console.ReadKey();
                                }
                            }
                            if (PlayerLocation == gameMap.roomArray[1, 1]) // getting into gate
                            {
                                if (!HasPickedUpTape)
                                {
                                    Console.WriteLine("You shouldn't leave until you've retrieved the security tape.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("You make your escape through the gate...");
                                    Console.ReadKey();
                                    GameEnd("win");

                                }
                            }
                            Move.Direction(Directions.Dir.Direction.s, player);
                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            return;
                        case "w":
                            Move.Direction(Directions.Dir.Direction.w, player);
                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            return;
                        case "boat":
                            if (PlayerLocation.IsRoomAllowed(gameMap.roomArray[0, 0], PlayerLocation))
                            {
                                Move.Room(gameMap.roomArray[0, 0], player);
                            }
                            else
                            {
                                Console.WriteLine("You can't get to that room from here.");
                                return;
                            }

                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                            return;
                        case "dock":
                            if (PlayerLocation.IsRoomAllowed(gameMap.roomArray[0, 1], PlayerLocation))
                            {
                                Move.Room(gameMap.roomArray[0, 1], player);
                            }
                            else
                            {
                                Console.WriteLine("You can't get to that room from here.");
                                return;
                            }

                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                            return;
                        case "armory":
                            if (PlayerLocation.IsRoomAllowed(gameMap.roomArray[0, 2], PlayerLocation))
                            {
                                Move.Room(gameMap.roomArray[0, 2], player);
                            }
                            else
                            {
                                Console.WriteLine("You can't get to that room from here.");
                                return;
                            }

                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                            return;
                        case "observation":
                            if (PlayerLocation.IsRoomAllowed(gameMap.roomArray[1, 0], PlayerLocation))
                            {
                                Move.Room(gameMap.roomArray[1, 0], player);
                            }
                            else
                            {
                                Console.WriteLine("You can't get to that room from here.");
                                return;
                            }

                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                            return;
                        case "bay":
                            if (PlayerLocation.IsRoomAllowed(gameMap.roomArray[1, 1], PlayerLocation))
                            {
                                Move.Room(gameMap.roomArray[1, 1], player);
                            }
                            else
                            {
                                Console.WriteLine("You can't get to that room from here.");
                                return;
                            }

                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                            return;
                        case "warehouse":
                            if (PlayerLocation.IsRoomAllowed(gameMap.roomArray[1, 2], PlayerLocation))
                            {
                                Move.Room(gameMap.roomArray[1, 2], player);
                            }
                            else
                            {
                                Console.WriteLine("You can't get to that room from here.");
                                return;
                            }

                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                            return;
                        case "security":
                            if (PlayerLocation.IsRoomAllowed(gameMap.roomArray[2, 0], PlayerLocation))
                            {
                                Move.Room(gameMap.roomArray[2, 0], player);
                            }
                            else
                            {
                                Console.WriteLine("You can't get to that room from here.");
                                return;
                            }

                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                            return;
                        case "gate":
                            if (PlayerLocation.IsRoomAllowed(gameMap.roomArray[2, 1], PlayerLocation))
                            {
                                Move.Room(gameMap.roomArray[2, 1], player);
                            }
                            else
                            {
                                Console.WriteLine("You can't get to that room from here.");
                                return;
                            }

                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                            return;
                        case "office":
                            if (PlayerLocation.IsRoomAllowed(gameMap.roomArray[2, 2], PlayerLocation))
                            {
                                Move.Room(gameMap.roomArray[2, 2], player);
                            }
                            else
                            {
                                Console.WriteLine("You can't get to that room from here.");
                                return;
                            }

                            if (PlayerLocation != player.CurrentRoom) // if the player successfully changed rooms
                            {
                                TurnUpdate(player);
                                PlayerLocation.OnRoomEnter();
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                            return;
                        default:
                            Console.WriteLine((ProjectText.BadInput));
                            break;

                    }
                    break;

                // LOOK AT SUBJECT
                case "l":
                case "x":
                    switch (_inputSubject)
                    {
                        // EXAMINE OBJECTS
                        case "key":
                        case "card":
                            Look.Examine(key);
                            return;
                        case "rocket":
                            Look.Examine(rocket);
                            return;
                        case "player":
                        case "self":
                            Look.Examine(player);
                            return;
                        case "knife":
                            Look.Examine(knife);
                            return;
                        case "pager":
                            Console.WriteLine(ProjectText.PagerHint());
                            return;
                        default:
                            Console.WriteLine((ProjectText.BadInput));
                            break;

                        // EXAMINE ROOM
                        case "boat":
                            Look.Describe(gameMap.roomArray[0,0]);
                            return;
                        case "dock":
                            Look.Describe(gameMap.roomArray[0, 1]);
                            return;
                        case "armory":
                            Look.Describe(gameMap.roomArray[0, 2]);
                            return;
                        case "observation":
                            Look.Describe(gameMap.roomArray[1, 0]);
                            return;
                        case "bay":
                            Look.Describe(gameMap.roomArray[1, 1]);
                            return;
                        case "warehouse":
                            Look.Describe(gameMap.roomArray[1, 2]);
                            return;
                        case "security":
                            Look.Describe(gameMap.roomArray[2, 0]);
                            return;
                        case "gate":
                            Look.Describe(gameMap.roomArray[2, 1]);
                            return;
                        case "office":
                            Look.Describe(gameMap.roomArray[2, 2]);
                            return;

                    }
                    break;
                case "search":
                    switch (_inputSubject)
                    {
                        // EXAMINE ROOM
                        case "armory":
                            if (!HasPickedUpRocket) 
                            {
                                rocket = new Item("Rocket launcher", "A rocket launcher", "A weapon you can use. Looks like it could do a lot of damage.", gameMap.roomArray[0, 2]);
                                HasPickedUpRocket = true;
                                ItemsInGame.Add(rocket);
                                Console.WriteLine("Most of the weapons are concealed under tarps, but one catches your eye...");
                                Console.ReadKey();
                                GainPoint(1);
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            TurnUpdate(player);
                            Look.Describe(gameMap.roomArray[0, 2]);
                            return;
                        case "security":
                            if (!HasPickedUpKey)
                            {
                                key = new Item("Key card", "A key card", "A key card.", gameMap.roomArray[2, 0]);
                                Console.WriteLine(key.Look);
                                HasPickedUpKey = true;
                                gameMap.roomArray[1, 2].CanExit(Dir.Direction.s);
                                ItemsInGame.Add(key);
                                Console.WriteLine("In a drawer lies a key card... but what room could this get you into?");
                                Console.ReadKey();
                                GainPoint(2);
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            TurnUpdate(player);
                            Look.Describe(gameMap.roomArray[2, 0]);
                            return;
                        case "office":
                            if (!HasPickedUpTape)
                            {
                                tape = new Item("Security tape", "A security tape", "The security tape.", gameMap.roomArray[2, 2]);
                                HasPickedUpTape = true;
                                ItemsInGame.Add(tape);
                                Console.WriteLine("On the desk is the security tape that would have incriminated you, if it had been in use...\nTime to get out of here!");
                                Console.ReadKey();
                            }
                            TurnUpdate(player);
                            Look.Describe(gameMap.roomArray[2, 2]);
                            return;
                        default:
                            Console.WriteLine("There is nothing of note in this area.");
                            return;

                    }
                    break;

                // TAKE SUBJECT
                case "take":
                case "get":
                    switch (_inputSubject)
                    {
                        case "key":
                        case "card":
                            Take.Get(key, player);
                            return;
                        case "rocket":
                            Take.Get(rocket, player);
                            return;
                        case "tape":
                            Take.Get(tape, player);
                            return;
                        default:
                            Console.WriteLine(ProjectText.BadInput);
                            break;
                    }
                    break;

                // DEFAULT
                default:
                    Console.WriteLine(ProjectText.BadInput);
                    break;

            }


        }

        public void GameEnd(string outcome)
        {
            switch (outcome)
            {
                case "win":
                    Console.WriteLine("Congratulations! You won! Yay!");
                    break;
                case "lose":
                    Console.WriteLine("Womp womp. You lost.");
                    break;
            }

            Console.WriteLine($"You finished the game with {Points} points.");
        }
    }
}
