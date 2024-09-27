using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab3_Maddie_Li
{
    internal class DiceManager
    {
        public List<int> diceList = new List<int>();

        // setup dice
        public void DiceSetup()
        {
            diceList.Add(6);
            diceList.Add(8);
            diceList.Add(12);
            diceList.Add(20);

        }
       
    }
}
