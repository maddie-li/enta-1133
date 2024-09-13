using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Gd12_1133_Lab2_Maddie_Li
{
    internal class GameManager
    {
        // init variables and list
        int diceAmount = 4;
        int sidesInput = 6;
        int scoreTotal = 0;

        List<int> results = new List<int>();

        internal void Intro()
        {
            // intro text
            Console.WriteLine("Welcome to Maddie Li's Lab 2 (2024-09-13)");
            Play();
        }
    
        private void Play()
        {

            // instantiating DieRoller
            DieRoller dieRoller = new DieRoller();

            Console.WriteLine("This is the Dice Roller!");

            // roll diceAmount times
            foreach (int x in Enumerable.Range(1, diceAmount))
            {
                dieRoller.Roll(sidesInput);

                // add results to the list
                results.Add(dieRoller.currentOutput);

            }

            EndGame();

        }

        private void EndGame() 
        { 
             
              foreach (int result in results)
              {
                 scoreTotal += result;
              }

              Console.WriteLine(scoreTotal.ToString());
             
        }
        

    }
}
