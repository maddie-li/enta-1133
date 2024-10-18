using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Items;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi
{
    public class ProjectText
    {
        

        public static string AssignmentText = @"
            Assignment 2 Maddie Li GD12 ENTA 1133";

        public static string IntroText = @"
            ADVENTURE GAME
            Welcome to Adventure Game!
            To play this game, enter commands to tell the computer what to do.
            Enter 'help' for a list of basic commands.";

        public static string HelpText()
        {
            string _commandsText = @"
            COMMANDS
                i, inventory / check inventory
                l, look / look at surroundings
                h, help / show commands
                z, wait / skip turn
                score / show score (also try health, points, turns)
";

            string _actionCommandsText = @"
            ACTION COMMANDS
                x, examine / look at item
                search / investigate room
                grab, get, t, take / pick up item
                go, walk, move / go in a direction
            ";

            string _directionsCommandsText = "DIRECTIONS" + "\n\t\t" + "n, north\n\t\ts, south\n\t\te, east\n\t\tw, west\n";
            string _helpText = _commandsText + _actionCommandsText + _directionsCommandsText;

            return _helpText;
        }

        public static string BadInput = "Invalid input! Try again.";

        public static string PagerHint()
        {
            string _pagerDisplay = "The pager displays your most recent message.\nINFILTRATE SITE AND ELIMINATE DIRECTOR\n";

            if (GameManager.HasPickedUpKey)
            {
                if (GameManager.HasPickedUpTape)
                {
                    _pagerDisplay += "YOUR MISSION IS COMPLETE! ESCAPE!";
                }
                else
                {
                    _pagerDisplay += "IF THE TAPES AREN'T IN SECURITY, MAY BE IN OFFICE";
                }
            }
            else
            {
                _pagerDisplay += "MAKE SURE TO SEARCH FOR SECURITY TAPES TO REMOVE EVIDENCE";
            }

            return _pagerDisplay;
        }
    }
}
