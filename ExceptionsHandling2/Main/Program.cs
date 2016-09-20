using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringParserLibrary;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var strToParse = Console.ReadLine();
                try
                {
                    var result = StringParser.ParseInt(strToParse);

                    //var result = int.Parse(strToParse);

                    Console.WriteLine($"Parsed value is {result}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
