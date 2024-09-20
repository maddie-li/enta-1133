using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab3_Maddie_Li
{
    public class Player
    {
        

        public string name = " ";
        public int score = 0;

        public int Turn(List<int> diceList)
        {
            // show how many dice you have available
            Console.WriteLine("DICE INVENTORY.");
            Console.WriteLine("You have the d" + string.Join(", d", diceList) + " available to use.");
            Console.WriteLine("Which one would you like to roll?");
            string rawSelection = Console.ReadLine();
            string diceSelection = rawSelection.Trim('d');

            if (int.TryParse(diceSelection, out int diceSides))
            {
                diceList.Remove(diceSides);
                return diceSides;
            }
            else
            {
                Console.WriteLine("\nInvalid input! Please enter one of your available dice!\n");
                return Turn(diceList);
            }


        }

    }
}
