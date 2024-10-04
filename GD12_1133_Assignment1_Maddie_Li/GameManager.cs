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
            Console.WriteLine(@$"
Welcome to the battle, {p1.name} and {p2.name}!
In this game, you have been each been bestowed {numOfRounds} dice of different values.

Every round, you and your opponent will choose one to expend, and roll against each other.

Whoever rolls highest gains a score equal the the combined number of sides.
This means if your potential roll is higher, the stakes are higher!

This goes on for {numOfRounds} rounds, then the one with the highest points is the winner!");

            Draw.Sword();
            
            // randomise turn order
            TurnRandomise();
            Console.WriteLine($"{p1.name} has been chosen to play first.");

            // get started
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();

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
                Console.WriteLine();
                Console.WriteLine(@"  ,  /\  ................................,  /\  .
 //`-||-'\\                             //`-||-'\\ 
(| -=||=- |)         GAME OVER         (| -=||=- |)
 \\,-||-.//                             \\,-||-.// 
  `  ||  '``````````````````````````````````||  '
     ||  The monks of Lindisfarne emerged   ||  
     || victorious against the Norse pagans.||  
     ||  The sacramental treasures of the   ||  
     || monastery were ably defended as was ||  
     ||      the good Lord's honour.        ||  
hjm  ()                                     ()");
                Console.WriteLine($"\n{p1.name} wins!! Congratulations!");
            }
            else if (p1.score < p2.score)
            {
                // p2 win
                Console.WriteLine();
                Console.WriteLine(@"  ,  /\  ................................,  /\  .
 //`-||-'\\                             //`-||-'\\ 
(| -=||=- |)         GAME OVER         (| -=||=- |)
 \\,-||-.//                             \\,-||-.// 
  `  ||  '``````````````````````````````````||  '
     ||    The monks of Lindisfarne were    ||  
     || helpless against the Viking raiders.||  
     ||    There was vicious robbery and    ||  
     || slaughter and the Norsemen returned ||  
     ||      home laden with treasure!      ||  
hjm  ()                                     ()");
                Console.WriteLine($"\n{p2.name} wins!! Congratulations!");
            }
            else if (p1.score == p2.score)
            {
                // tie
                Console.WriteLine();
                Console.WriteLine(@"  ,  /\  ................................,  /\  .
 //`-||-'\\                             //`-||-'\\ 
(| -=||=- |)         GAME OVER         (| -=||=- |)
 \\,-||-.//                             \\,-||-.// 
  `  ||  '``````````````````````````````````||  '
     ||    An unlikely outcome! The monks   ||  
     || and the Viking warriors were evenly ||  
     ||   matched! Landing at a draw, they  ||  
     ||     were locked into an eternal     ||  
     ||      struggle lasting milennia!     ||  
hjm  ()                                     ()");
                Console.WriteLine("You both win!! Congratulations!");
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
            Console.WriteLine("Choose the mode of combat based on how many players there will be.");
            Console.WriteLine("[1] Player vs. CPU\n[2] Player 1 vs Player 2");
            string inpOfPlayers = Console.ReadLine();


            p2.isEnemy = true; // for flavor text reasons

            // read input
            if (int.TryParse(inpOfPlayers, out int numOfPlayers))
            {
                if (numOfPlayers == 1)
                {
                    Console.WriteLine("You are a devout defender of Lindisfarne.\nWhat is your name, monk?");
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
                    Console.WriteLine("The first player will be a devout defender of Lindisfarne.\nWhat is your name, monk?");

                    // give generic name if none given
                    p1.name = Console.ReadLine();
                    if (p1.name == null || p1.name == "")
                    {
                        p1.name = "Player 1";
                    }

                    Console.WriteLine("The second player will be a barbarian attacker.\nWhat is your name, warrior?");

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
                (p1.isEnemy, p2.isEnemy) = (p2.isEnemy, p1.isEnemy);
            }

        }
    }
}
