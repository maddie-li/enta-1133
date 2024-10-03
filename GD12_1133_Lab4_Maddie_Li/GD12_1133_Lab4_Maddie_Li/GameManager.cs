using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab4_Maddie_Li
{
    internal class GameManager
    {
        // instantiating
        DiceManager p1_dice = new DiceManager();
        DiceManager p2_dice = new DiceManager();

        DiceRoller roll = new DiceRoller();

        Player p1 = new Player();
        Player p2 = new Player();

        public void GameStart()
        {

            p1_dice.DiceSetup();
            p2_dice.DiceSetup();

            int numOfRounds = p1_dice.diceList.Count;

            // get player number, names, turns
            PlayerSetup();

            Console.WriteLine($"Welcome to the game, {p1.name} and {p2.name}!");
            Console.WriteLine($"\nIn this game, you each have {numOfRounds} dice of different values, but you can only use each die once.");
            Console.WriteLine("Every round, you and your opponent will choose a die and roll against each other.");
            Console.WriteLine("Whoever rolls highest gains points equal to the combined number of sides.");
            Console.WriteLine($"This goes on for {numOfRounds} rounds, then the one with the highest points wins!");

            // get started
            Console.WriteLine("\nENTER TO START");
            Console.Read();

            for (int i = 0; i < numOfRounds; i++)
            {
                GameRound(i);
            };

            GameEnd();

        }

        public void GameRound(int r)
        {
            int bankedScore = 0;
            Console.WriteLine($"Round { r +  1}!");

            // p1's turn
            Console.WriteLine($"\nIt's {p1.name}'s turn!");
            int p1_selection = p1.Turn(p1_dice.diceList);
            int p1_roll = roll.Roll(p1_selection);
            bankedScore += p1_selection;

            // p2's turn
            Console.WriteLine($"\nIt's {p2.name}'s turn!");
            int p2_selection = p2.Turn(p2_dice.diceList);
            int p2_roll = roll.Roll(p2_selection);
            bankedScore += p2_selection;

            // start compare
            Console.WriteLine("\nBoth players have rolled!");
            Console.WriteLine($"{p1.name} rolled {p1_roll} with a d{p1_selection}\n{p2.name} rolled {p2_roll} with a d{p2_selection}");

            // compare score
            if (p1_roll > p2_roll)
            {
                p1.score += bankedScore;
                Console.WriteLine($"\n{p1.name} won this round and gains {bankedScore} points!");
            }
            else if (p1_roll < p2_roll)
            {
                p2.score += bankedScore;
                Console.WriteLine($"\n{p2.name} won this round and gains {bankedScore} points!");

            }
            else if (p1_roll == p2_roll)
            {
                p1.score += bankedScore;
                p2.score += bankedScore;
                Console.WriteLine($"\nBoth players won this round and gain {bankedScore} points!");
            }

        }

        public void GameEnd()
        {
            Console.WriteLine("\nGAME OVER");
            Console.WriteLine($"{p1.name} has {p1.score} points and {p2.name} has {p2.score} points.");

            // compare score
            if (p1.score > p2.score)
            {
                Console.WriteLine($"\n{p1.name} wins!! Congratulations!\n");
            }
            else if (p1.score < p2.score)
            {
                Console.WriteLine($"\n{p2.name} wins!! Congratulations!\n");

            }
            else if (p1.score == p2.score)
            {
                Console.WriteLine("You both win!! Congratulations!\n");
            }

        }

        
        public void PlayerSetup()
        {
            // ask how many players
            Console.WriteLine("[1] Player vs. CPU\n[2] Player 1 vs Player 2");
            string inpOfPlayers = Console.ReadLine();
            
            // read input
            if (int.TryParse(inpOfPlayers, out int numOfPlayers))
            {
                if (numOfPlayers == 1)
                {
                    Console.WriteLine("Hi, player! \nWhat's your name?");
                    p1.name = Console.ReadLine();
                    
                    if (p1.name == null || p1.name == "")
                    {
                        p1.name = "Player";
                    }

                    p2.name = "CPU";
                    p2.isCPU = true;
                }
                else if (numOfPlayers == 2)
                {

                    // get player names
                    Console.WriteLine("Hi, players! \nWhat's the name of your first player?");
                    p1.name = Console.ReadLine();
                    if (p1.name == null || p1.name == "")
                    {
                        p1.name = "Player 1";
                    }
                    Console.WriteLine("What's the name of your second player?");
                    p2.name = Console.ReadLine();
                    if (p2.name == null || p2.name == "")
                    {
                        p2.name = "Player 2";
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter 1 or 2!");
                    PlayerSetup();
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter 1 or 2!");
                PlayerSetup();
            }

            

        }
    }
}
