using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParserLibrary
{
    public static class StringParser
    {
        public static int Parse(string strToParse)
        {
            if (string.IsNullOrWhiteSpace(strToParse))
                throw new FormatException("Cannot parse an empty string to integer.");

            return ParseUnsigned(strToParse);
        }

        public static int ParseInt(string strToParse)
        {
            if (string.IsNullOrWhiteSpace(strToParse))
                throw new FormatException("Cannot parse an empty string to integer.");

            return ParseUnsignedInt(strToParse);
        }

        private static int ParseUnsigned(string unsigned)
        {
            if (unsigned.StartsWith("-"))
                return -1 * ParsePositive(unsigned.Remove(0, 1));
            return ParsePositive(unsigned);
        }

        private static int ParseUnsignedInt(string unsigned)
        {
            if (unsigned.StartsWith("-"))
                return -1 * ParseInteregPart(unsigned.Remove(0, 1));
            return ParseInteregPart(unsigned);
        }

        private static int ParsePositive(string signed)
        {
            var parts = signed.Split('.', ',');

            if (parts.Length == 1)
            {
                try
                {
                    var temp = parts[0];

                    if (temp[0] == '.' && temp[0] == ',')
                        return ParseRealPart(temp);
                    else
                        return ParseInteregPart(temp);
                }
                catch (IndexOutOfRangeException)
                {

                    throw new FormatException("Cannot parse a string containing only a separator to integer.");
                }
            }

            if (parts.Length > 2)
                throw new FormatException($"Cannot parse \"{signed}\" to integer.");


            return ParseInteregPart(parts[0]) + ParseRealPart(parts[1]);
        }

        private static int ParseInteregPart(string integerPart)
        {
            int order = 1;
            int result = 0;
            for (int i = integerPart.Length - 1; i >= 0; i--)
            {
                try
                {
                    result += Digits[integerPart[i]] * order;
                }
                catch (KeyNotFoundException)
                {
                    throw new FormatException($"Cannot parse symbol {integerPart[i]}");
                }
                order *= 10;
            }

            return result;
        }

        private static int ParseRealPart(string realPart)
        {
            if (string.IsNullOrWhiteSpace(realPart))
                throw new FormatException("Real part cannot be empty.");

            foreach (var item in realPart)
            {
                if(!Digits.ContainsKey(item))
                    throw new FormatException($"Cannot parse symbol {item}");
            }
            
            if (Digits[realPart[0]] < 5)
                return 0;
            return 1;
        }

        private static Dictionary<char, int> Digits = new Dictionary<char, int>
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 }
        };
    }
}
