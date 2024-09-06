using System.Runtime.InteropServices;

namespace GD12_1133_Lab1_Maddie_Li
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] info = { { "Binary", "2", "0,1", "1" }, { "Decimal", "10", "0,1,2,3,4,5,6,7,8,9", "9" }, { "Hexadecimal", "16", "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f", "9" }};

            Console.WriteLine("Hello! This is Maddie Li's Lab 1 assignment on computing basics! It is September 6, 2024!\n");
            Console.WriteLine("What are the differences between binary, decimal and hexidecimal numbers?");

            foreach (int x in Enumerable.Range(0,3)) //I feel like it should be range 0,2 but it didn't print the last one when I did that. So I changed the range, but I don't know why
            {
                Console.WriteLine("\n\n" + info[x, 0] + " counts in base " + info[x, 1] + " using the symbols of " + info[x, 2] + ".\nThis means if you reach the value of " + info[x, 0] + " in a space (represented by the symbol " + info[x, 3] + ") the counting moves over to the next position.\n");


                List<int> numberslist = new List<int>()
                {
                    0, 1, 2, 4, 8, 16, 32, 64, 100, 255
                };

                if (x == 0)
                {
                    Console.WriteLine("In Binary, the numbers 0, 1, 2, 4, 8, 16, 32, 64, 100, 255 are:\n");

                    foreach (int y in numberslist)
                    {
                        string outputnumber = Convert.ToString(y, 2);
                        int stringlength = outputnumber.Length;

                        Console.WriteLine(outputnumber.PadLeft(8, '0'));
                    }
                }
                else if (x == 1)
                {
                    Console.WriteLine("In Decimal, the numbers 0, 1, 2, 4, 8, 16, 32, 64, 100, 255 are:\n");

                    foreach (int y in numberslist)
                    {
                        string outputnumber = Convert.ToString(y, 10);
                        int stringlength = outputnumber.Length;

                        Console.WriteLine(outputnumber);
                    }
                }
                else if (x == 2)
                {
                    Console.WriteLine("In Hexadecimal, the numbers 0, 1, 2, 4, 8, 16, 32, 64, 100, 255 are:\n");

                    foreach (int y in numberslist)
                    {
                        string outputnumber = Convert.ToString(y, 16);
                        int stringlength = outputnumber.Length;

                        Console.WriteLine(outputnumber);
                    }

                }

                }

            Console.WriteLine("\nThank you and goodbye :D");

        }
    }
}
