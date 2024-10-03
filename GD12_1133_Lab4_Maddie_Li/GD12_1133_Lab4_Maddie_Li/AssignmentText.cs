using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab4_Maddie_Li
{
    internal class AssignmentText
    {
        internal void Intro()
        {
            // instantiating
            GameManager manager = new GameManager();

            Console.WriteLine("Welcome to Maddie Li's Lab 4 (2024-09-27)\n");

            /*Console.WriteLine(@"
             _   _ _____ _   __   __ ______ _____ _      _      ___________ 
            | | | |  _  | |  \ \ / / | ___ \  _  | |    | |    |  ___| ___ \
            | |_| | | | | |   \ V /  | |_/ / | | | |    | |    | |__ | |_/ /
            |  _  | | | | |    \ /   |    /| | | | |    | |    |  __||    / 
            | | | \ \_/ / |____| |   | |\ \\ \_/ / |____| |____| |___| |\ \ 
            \_| |_/\___/\_____/\_/   \_| \_|\___/\_____/\_____/\____/\_| \_|

            ");
            */

            Console.WriteLine(@"

                  :::    :::  ::::::::  :::     :::   :::                                 
                 :+:    :+: :+:    :+: :+:     :+:   :+:                                  
                +:+    +:+ +:+    +:+ +:+      +:+ +:+                                    
               +#++:++#++ +#+    +:+ +#+       +#++:                                      
              +#+    +#+ +#+    +#+ +#+        +#+                                        
             #+#    #+# #+#    #+# #+#        #+#                                         
            ###    ###  ########  ########## ###                                          
                          :::::::::   ::::::::  :::        :::        :::::::::: :::::::::
                         :+:    :+: :+:    :+: :+:        :+:        :+:        :+:    :+:
                        +:+    +:+ +:+    +:+ +:+        +:+        +:+        +:+    +:+ 
                       +#++:++#:  +#+    +:+ +#+        +#+        +#++:++#   +#++:++#:   
                      +#+    +#+ +#+    +#+ +#+        +#+        +#+        +#+    +#+   
                     #+#    #+# #+#    #+# #+#        #+#        #+#        #+#    #+#    
                    ###    ###  ########  ########## ########## ########## ###    ###     
            ");

            Console.WriteLine("\nEnter the Celestial Casino, where gods gamble with fate.\nYou have been drawn by forces beyond your control to play a game of chance.\nEach roll can reshape the cosmos.. something something... relevant to how the game works.. .\n");

            manager.GameStart();
        }
    }
}
