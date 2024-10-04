using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment1_Maddie_Li
{
    internal class GameManager
    {
        // instantiating references for variables
        DiceManager DiceManager = new DiceManager();
        AssignmentText Draw = new AssignmentText(); // used mostly to draw ASCII dividers, and once to restart game

        // instantiating references for function
        DiceRoller roll = new DiceRoller();
        Random random = new Random();

        // instantiating players
        Player p1 = new Player();
        Player p2 = new Player();

        // instantiating dice for each player
        DiceManager p1_dice = new DiceManager();
        DiceManager p2_dice = new DiceManager();

        public int maxRollValue = 0;

        public void GameStart()
        {
            /// <summary>
            /// Sets up dice, players, rounds, writes intro, handles rounds
            /// </summary>
            
            // setup dice for players
            p1_dice.DiceSetup();
            p2_dice.DiceSetup();

            // setup dice for managing
            DiceManager.DiceSetup();
            maxRollValue = DiceManager.GetTotal(); // get max rolls for stats use
            int numOfRounds = p1_dice.diceList.Count; // get number of dice for rounds

            // setup player
            PlayerSetup();

            Draw.Sword();

            // instructions intro
            Console.WriteLine($"Welcome to the game, {p1.name} and {p2.name}!");
            Console.WriteLine($"\nIn this game, you each have {numOfRounds} dice of different values, but you can only use each die once.");
            Console.WriteLine("Every round, you and your opponent will choose a die and roll against each other.");
            Console.WriteLine("Whoever rolls highest gains points equal to the combined number of sides.");
            Console.WriteLine($"This goes on for {numOfRounds} rounds, then the one with the highest points wins!");

            // randomise turn order
            TurnRandomise();
            Console.WriteLine($"\n{p1.name} has been chosen to play first.");

            // get started
            Console.WriteLine("\nENTER TO START");
            Console.Read();

            // play rounds
            for (int i = 0; i < numOfRounds; i++)
            {
                Draw.Sword();
                GameRound(i);
            };

            // run end sequence
            Draw.Sword();
            GameEnd();

        }

        public void GameRound(int r) 
        {
            /// <summary>
            /// Takes the round number, runs round, checks scores
            /// </summary>] 

            int bankedScore = 0; // the point pool for the round

            Console.WriteLine($"Round { r +  1}!"); // changes 'r' from index number to actual number

            // p1's turn
            Console.WriteLine($"\nIt's {p1.name}'s turn!");
            // get dice selection
            int p1_selection = p1.Turn(p1_dice.diceList); // has to give player dicelist to turn function
            // roll with it
            int p1_roll = roll.Roll(p1_selection);
            // add scores
            p1.totalRollValue += p1_roll;
            bankedScore += p1_selection;
            Draw.Arrow();

            // p2's turn
            Console.WriteLine($"\nIt's {p2.name}'s turn!");
            // get dice selection
            int p2_selection = p2.Turn(p2_dice.diceList);
            // roll with it
            int p2_roll = roll.Roll(p2_selection);
            // add scores
            p2.totalRollValue += p2_roll;
            bankedScore += p2_selection;
            Draw.Arrow();

            // start compare
            Console.WriteLine("\nBoth players have rolled!");
            Console.WriteLine($"{p1.name} rolled {p1_roll} with a d{p1_selection}\n{p2.name} rolled {p2_roll} with a d{p2_selection}");

            // compare score
            if (p1_roll > p2_roll)
            {
                // p1 win
                p1.score += bankedScore;
                Console.WriteLine($"\n{p1.name} won this round and gains {bankedScore} points!");
            }
            else if (p1_roll < p2_roll)
            {
                // p2 win
                p2.score += bankedScore;
                Console.WriteLine($"\n{p2.name} won this round and gains {bankedScore} points!");

            }
            else if (p1_roll == p2_roll)
            {
                // tie
                p1.score += bankedScore;
                p2.score += bankedScore;
                Console.WriteLine($"\nBoth players won this round and gain {bankedScore} points!");
            }

        }

        public void GameEnd()
        {
            /// <summary>
            /// Shows score and winner, asks to play again or end
            /// </summary>

            Console.WriteLine("\nGAME OVER");

            Console.WriteLine(@"  ,  /\  ...................................,  /\  .
 //`-||-'\\                                //`-||-'\\ 
(| -=||=- |)                              (| -=||=- |)
 \\,-||-.//                                \\,-||-.// 
  `  ||  '`````````````````````````````````````||  '
     ||                                        ||  
     ||                                        ||  
     ||                                        ||  
     ||                                        ||  
     ||                                        ||  
hjm  ()                                        ()");

            // quick summary
            Console.WriteLine($"{p1.name} has {p1.score} points and {p2.name} has {p2.score} points.");

            // stats
            Console.WriteLine("\nSTATS");

            float p1_successRate = (float)p1.totalRollValue / (float)maxRollValue; // divides dice value by max dice value, and use float to create a decimal
            float p2_successRate = (float)p2.totalRollValue / (float)maxRollValue; 

            string p1_successRateFormatted = String.Format("{0:P0}", p1_successRate); // use string format to write as percent
            string p2_successRateFormatted = String.Format("{0:P0}", p2_successRate);

            Console.WriteLine($"{p1.name} rolled a value of {p1.totalRollValue} out of {maxRollValue} maximum, which is a success rate of {p1_successRateFormatted}");
            Console.WriteLine($"{p2.name} rolled a value of {p2.totalRollValue} out of {maxRollValue} maximum, which is a success rate of {p2_successRateFormatted}");

            // compare score
            if (p1.score > p2.score)
            {
                // p1 win
                Console.WriteLine($"\n{p1.name} wins!! Congratulations!\n");
            }
            else if (p1.score < p2.score)
            {
                // p2 win
                Console.WriteLine($"\n{p2.name} wins!! Congratulations!\n");
            }
            else if (p1.score == p2.score)
            {
                // tie
                Console.WriteLine("You both win!! Congratulations!\n");
            }

            // end game or restart
            Console.WriteLine("\n[1] Play again\n[2] Exit game");
            string inpReplay = Console.ReadLine();

            // read input
            if (int.TryParse(inpReplay, out int numReplay)) { 

                
                if (numReplay == 1)
                {
                    // replay
                    Console.Clear();
                    Draw.Intro();
                }
                else if (numReplay == 2)
                {
                    // close 
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter 1 or 2!");
                    GameEnd();
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter 1 or 2!");
                GameEnd();
            }


        }

        
        public void PlayerSetup()
        {
            /// <summary>
            /// Get player amount and names, assigns CPU
            /// </summary>

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
                    
                    // give generic name if none given
                    if (p1.name == null || p1.name == "")
                    {
                        p1.name = "Player";
                    }

                    // set other player to CPU
                    p2.name = "CPU";
                    p2.isCPU = true;
                }
                else if (numOfPlayers == 2)
                {

                    // get player names
                    Console.WriteLine("Hi, players! \nWhat's the name of your first player?");

                    // give generic name if none given
                    p1.name = Console.ReadLine();
                    if (p1.name == null || p1.name == "")
                    {
                        p1.name = "Player 1";
                    }

                    Console.WriteLine("What's the name of your second player?");

                    // give generic name if none given
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

        public void TurnRandomise()
        {
            /// <summary>
            /// Randomly sets who starts rounds
            /// </summary>

            // randomly change order, or not
            bool isChanged = random.Next(2) == 0;

            // swap name and CPU status
            if (isChanged)
            {
                (p1.name, p2.name) = (p2.name, p1.name);
                (p1.isCPU, p2.isCPU) = (p2.isCPU, p1.isCPU);
            }

        }
    }
}
