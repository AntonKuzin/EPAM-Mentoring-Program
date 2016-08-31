using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsHandling1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Console.WriteLine("Type \"close\" to close this application");

            while (!string.Equals(input, "close", StringComparison.InvariantCultureIgnoreCase))
            {
                input = Console.ReadLine();

                try
                {
                    var firstChar = input[0];
                    Console.WriteLine($"First character is {firstChar}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Empty strings are not allowed here.");
                }
            }
        }
    }
}
