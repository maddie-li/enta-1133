using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi
{
    public class Input
    {
        ProjectText write = new ProjectText();  
        
        public string? rawString;

        public void Get() // read input
        {
            rawString = null;

            while (string.IsNullOrWhiteSpace(rawString)) // reprompt if null empty or whitespace
            {
                Console.Write("\n> "); // prompter
                rawString = Console.ReadLine();

            }

            string trimmed = rawString.Trim(); // trim whitespace
            string lowered = trimmed.ToLower(); // make lowercase

            Read(lowered);

            return;

        }

        public void Read(string input)
        {
            switch (input)
            {
                case "help":
                    Console.WriteLine(write.HelpText());
                    break;
                default:
                    Console.WriteLine("Can't understand this command!");
                    break;
            }

            return;
        }
    }
}
