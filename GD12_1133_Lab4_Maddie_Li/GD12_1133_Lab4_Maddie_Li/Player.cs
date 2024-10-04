using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab4_Maddie_Li
{
    public class Player
    {
        // player attributes
        public string name = " ";
        public int score = 0;
        public bool isCPU = false;
        public bool isEnemy = false;
        public int totalRollValue = 0;

        Random random = new Random();

        public int Turn(List<int> diceList) 
        {
            /// <summary>
            /// Takes player dice list, processes player input and returns chosen dice integer
            /// </summary>

            // player turn
            if (!isCPU)
            {
                // show how many dice you have available
                Console.WriteLine("DICE INVENTORY");
                Console.WriteLine("You have the d" + string.Join(", d", diceList) + " available to use.");
                Console.WriteLine("Which one would you like to roll?");
                string rawSelection = Console.ReadLine();
                string diceSelection = rawSelection.Trim('d'); // trim 'd' from 'd20' to get number

                // if player entered a number
                if (int.TryParse(diceSelection, out int diceSides)
                    && diceList.Contains(diceSides))
                {
                    // remove from dicelist
                    diceList.Remove(diceSides);
                    return diceSides;
                }
                else
                {
                    Console.WriteLine("\nInvalid input! Please enter one of your available dice!\n");
                    return Turn(diceList);
                }
            }
            // CPU turn
            else
            {
                int diceSides;
                
                // pick random die from list
                diceSides = diceList[random.Next(0, diceList.Count)];

                Console.WriteLine("CPU has rolled.");

                // remove from dicelist
                diceList.Remove(diceSides);
                return diceSides;
                
            }

        }

    }
}
