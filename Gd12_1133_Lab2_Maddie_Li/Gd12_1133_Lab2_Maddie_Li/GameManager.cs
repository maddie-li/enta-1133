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
    
        internal void Play()
        {

            // instantiating for dieRoller
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
              // add each result
              foreach (int result in results)
              {
                 scoreTotal += result;
              }

              Console.WriteLine(scoreTotal.ToString());

            // instantiating for outro
            AssignmentText assignment = new AssignmentText();
            assignment.Outro();

        }
        

    }
}
