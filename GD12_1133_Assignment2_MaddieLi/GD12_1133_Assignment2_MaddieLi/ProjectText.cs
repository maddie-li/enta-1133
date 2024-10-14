using GD12_1133_Assignment2_MaddieLi.Abstract;
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

        public string AssignmentText = @"
            Assignment 2 Maddie Li GD12 ENTA 1133";

        public string IntroText = @"
            ADVENTURE GAME
            Welcome to Adventure Game!
            To play this game, enter commands to tell the computer what to do.
            Enter 'help' for a list of basic commands.";

        public string HelpText()
        {
            string _commandsText = @"
            COMMANDS
                i, inv, inventory / check inventory
                l, look / look at surroundings
                h, help, commands / show commands
                score / show score";

            string _actionCommandsText = @"
            ACTION COMMANDS
                x, examine / look at item
                grab, get, t, take / pick up item
                drop / drop item
                go / go in a direction
            ";

            string _directionsCommandsText = "DIRECTIONS" + "\n\t\t" + "north\n\t\tsouth\n\t\teast\n\t\twest";
            string _helpText = _commandsText + _actionCommandsText + _directionsCommandsText;

            return _helpText;
        }
    }
}
