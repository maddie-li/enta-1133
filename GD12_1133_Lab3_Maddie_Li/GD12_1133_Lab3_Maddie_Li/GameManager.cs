using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab3_Maddie_Li
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

            // get player names
            Console.WriteLine("Hi, players! This is a 2-player game.\nWhat's the name of your first player?");
            p1.name = Console.ReadLine();
            if (p1.name == null){
                p1.name = "Player 1";
            }
            Console.WriteLine("What's the name of your second player?");
            p2.name = Console.ReadLine();
            if (p2.name == null)
            {
                p2.name = "Player 2";
            }
            Console.WriteLine($"Welcome to the game, {p1.name} and {p2.name}!");
            Console.WriteLine($"\nIn this game, you each have {numOfRounds} dice of different values, but you can only use each die once.");
            Console.WriteLine("Every round, you and your opponent will choose a die and roll against each other.");
            Console.WriteLine("Whoever rolls highest gains points equal to the combined number of sides.");
            Console.WriteLine($"This goes on for {numOfRounds} rounds, then the one with the highest points wins!.");

            GameRound("1");
            GameRound("2");
            GameRound("3");
            GameRound("4");

        }

        public void GameRound(string r)
        {
            int bankedScore = 0;
            Console.WriteLine($"\nRound {r}!");

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

            // comparescore(p1score, p2score)
            Console.WriteLine("\nBoth players have rolled!\n");
            Console.WriteLine($"\nThe banked score is {bankedScore}!\n");


        }

       


    // compare score function
    // get highest score
    // assign and print round winner
    // add dice sides
    // gainpoints(winner, points)

    // gain points function
    // set points to player

    // game end function
    // get highest score
    // assign and print game winner
    // assignmenttext outro

}
}
