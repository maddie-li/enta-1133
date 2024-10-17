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
        public BaseRoom PlayerLocation;

        public string? rawString; // raw input

        // objectvies variables
        int Points = 0;
        bool HasPickedUpRocket = false;
        bool HasPickedUpTape = false;
        bool HasPickedUpKey = false;

        // characters
        public Player player;

        // items
        public List<BaseItem> ItemsInGame = new List<BaseItem>();
        public Item key;
        public Item rocket;
        public Item tape;

        // utility classes
        ProjectText write = new ProjectText();

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

        public void SetUp()
        {
            // setup

            gameMap.CreateMap();

            BaseRoom boat = gameMap.RoomSetup(0, 0, "Boat", "The way out is east.", "The boat you arrived in.");
            boat.CanExit(Dir.Direction.e);

            BaseRoom dock = gameMap.RoomSetup(0, 1, "Dock", "There is a door in the east wall and the loading bay is south.", "A loading dock, exposed to the ocean.");
            dock.CanExit(Dir.Direction.e);
            dock.CanExit(Dir.Direction.s);

            BaseRoom armory = gameMap.RoomSetup(0, 2, "Armory", "The way back out is west", "A strangely constructed room filled with weapons.");
            armory.CanExit(Dir.Direction.w);

            BaseRoom observation = gameMap.RoomSetup(1, 0, "Observation deck", "The loading bay is east and security is south.", "Raised above the port, you can see everything.");
            observation.CanExit(Dir.Direction.e);
            observation.CanExit(Dir.Direction.s);

            BaseRoom bay = gameMap.RoomSetup(1, 1, "Loading bay", "The dock is north, the warehouse east, the gate south, and the observation deck north.", "A busy central hub where people shuttle product in all four directions..");
            bay.CanExit(Dir.Direction.n);
            bay.CanExit(Dir.Direction.e);
            bay.CanExit(Dir.Direction.w);
            

            BaseRoom warehouse = gameMap.RoomSetup(1, 2, "Warehouse", "The loading bay is west and the locked office is south.", "A cavernous warehouse.");
            warehouse.CanExit(Dir.Direction.w);
            warehouse.CanExit(Dir.Direction.s);

            BaseRoom security = gameMap.RoomSetup(2, 0, "Security", "The observation deck is north.", "A messsy and outdated security room full of camera feeds.");
            security.CanExit(Dir.Direction.n);

            BaseRoom gate = gameMap.RoomSetup(2, 1, "Gate", "", "");
            gate.CanExit(Dir.Direction.n);

            BaseRoom office = gameMap.RoomSetup(2, 2, "Office", "The warehouse is north", "Lavishly decorated.");
            office.CanExit(Dir.Direction.n);

            player = new Player(boat, new List<BaseItem> { });

           
            


            StartGame(boat);
        }
        

        public void StartGame(BaseRoom _startingRoom) // start game and loop
        {
            Console.WriteLine(write.IntroText + "\n");

            PlayerLocation = _startingRoom;
            TurnUpdate(player);
            Look.Describe(PlayerLocation);

            while (isGamePlaying)
            {
                GetInput();
                TurnUpdate(player);
            }

        }

        public void TurnUpdate(Player player)
        {
            // UPDATE PLAYER LOCATION
            PlayerLocation = player.CurrentRoom!;

            player.CurrentRoom.Contents.Clear();

            foreach (BaseItem item in ItemsInGame)
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

            // SPLIT STRING
            string[] _inputList = input.Split(" ");

            for (int i = 0; i < _inputList.Length; i++)
            {
                // SHORTEN INPUT
                if (Abbrv.ContainsKey(_inputList[i]))
                {
                    _inputList[i] = Abbrv[_inputList[i]];
                }
            }

            int _wordsInInput = _inputList.Length;

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
                        Console.WriteLine(write.HelpText());
                        return;
                    case "l":
                        Look.Describe(PlayerLocation!);
                        return;
                    case "i":
                        Look.Inventory(player);
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
                        default:
                            Console.WriteLine(write.BadInput);
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
                        default:
                            Console.WriteLine(write.BadInput);
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
                                rocket = new Weapon("Rocket launcher", "A rocket launcher", "A weapon you can use.", 20, gameMap.roomArray[0, 2]);
                                HasPickedUpRocket = true;
                                ItemsInGame.Add(rocket);
                            }
                            TurnUpdate(player);
                            Look.Describe(gameMap.roomArray[0, 2]);
                            return;
                        case "security":
                            if (!HasPickedUpKey)
                            {
                                key = new Item("Key card", "A key card", "A key card. What room could you get into with this?", gameMap.roomArray[2, 0]);
                                Console.WriteLine(key.Look);
                                HasPickedUpKey = true;
                                ItemsInGame.Add(key);
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
                            }
                            TurnUpdate(player);
                            Look.Describe(gameMap.roomArray[2, 2]);
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
                        default:
                            Console.WriteLine(write.BadInput);
                            break;
                    }
                    break;

                // DROP SUBJECT
                case "drop":
                    switch (_inputSubject)
                    {
                        case "key":
                        case "card":
                            Take.Drop(key, player);
                            return;
                        case "rocket":
                            Take.Drop(rocket, player);
                            return;
                        case "use":
                            return;
                        default:
                            Console.WriteLine(write.BadInput);
                            break;
                    }
                    break;

                // DEFAULT
                default:
                    Console.WriteLine(write.BadInput);
                    break;

            }


        }

        public void CombatSetup()
        {
            Combatant _player = new Combatant("Player", null!, null!, 100, null!, new List<BaseItem> { });
            Combatant _enemy = new Combatant("Guard", null!, null!, 75, null!, new List<BaseItem> { });

            CombatBegin(_player, _enemy);

        }

        public void CombatBegin(Combatant player, Combatant enemy)
        {
            Console.WriteLine($"{player.Name} vs. {enemy.Name}");
        }
    }
}
