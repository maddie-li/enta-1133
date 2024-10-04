using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment1_Maddie_Li
{
    internal class AssignmentText
    {
        internal void Intro()
        {
            // instantiating
            GameManager manager = new GameManager();

            Console.WriteLine("Welcome to Maddie Li's Lab 4 (2024-09-27)\n");

            // title
            Console.WriteLine(@"                +═════════════════════════════════════+
         .      ║                                     ║      . 
   __a`;/(   <. ║ | | /\ |  \ /    |\ /\ |  |  |\ |\  ║ .>   )\;`a__
~~"".-\ \(_ _  ) ║ |\| \/ |   |     |/ \/ |  |  |- |/  ║(  _ _)/ /-.""~~
      \( _( )   ║ | | /\ |/  |     |\ /\ |/ |/ |/ |\  ║ `( )_ )/
       _>  _>   ║                                     ║  <_  <_ 
                +═════════════════════════════════════+
                         Press enter to begin");

            
           

            // main art
            Console.WriteLine(@"
    .--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--
   / .. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \..\
    \/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /
   / /\ \/`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--\ \/\ \
   \ \/\ \                                             +     /\ \/ /
    \/ /\ \                   ~.                       A_   / /\/ /
    / /\/ /            Ya...___|__..aab     .   .     /\-\  \ \/ /\
   / /\ \/             Y88a  Y88o  Y88a   (     )    _||""|_  \ \/\ \
   \ \/\ \~^~^~^~^~^~^~ Y88b  Y88b  Y88b   `.oo'~^~^~^~^^~^~^/\ \/ /
    \/ /\ \    ~^~^~    :888  :888  :888  ( (`- ~^~^~^      / /\/ /
    / /\/ /     .---.    d88P  d88P  d88P   `.`.             \ \/ /\
   / /\ \/   / .-._)  d8P'""""""|""""""'-Y8P      `.`.     ~^~^~^   \ \/\ \
   \ \/\ \  ( (`._) .-.  .-. |.-.  .-.  .-.   ) )             /\ \/ /
    \/ /\/   \ `---( O )( O )( O )( O )( O )-' /    ~^~^~^   / /\/ /
    / /\/ /    `. ~^~^~/ /^-/ /~^/ /~^/ /^  .' CJ            \ \/\ \
    / /\/ /\.--..--..--..--..--..--..--..--..--..--..--..--./ /\/ /\
   / /\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \
   \ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `' /
    `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'");

            Console.ReadLine();

            Console.WriteLine("In the Year of Our Lord 793, dreadful forewarnings have come over the\nland of Northumbria.\nThese were amazing sheets of lightning and whirlwinds, and fiery\ndragons were seen flying in the sky.\nThis can mean only one thing, O God--! \nThe Holy Island faces dreadful attack by heathen Norsemen!\n\nBy the grace of the Lord, the the raiders have agreed to engage\nthe unarmed monks in a battle of dice and chance.");
            Console.WriteLine();
            Sword();
            Console.WriteLine();

            manager.GameStart();
        }

        public void Sword()
        {
            Console.WriteLine(@"
    /
O===[======================-
    \
");

        }

        public void Arrow()
        {
            Console.WriteLine(@"
>>>>>---------------------->");

        }

        
    }
}
