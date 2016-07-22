using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Methods
    {
        public static int Calculate(int N)
        {
            double result = 0;
            double count = 1, temp = 2;

            while(count <= N)
            {
                if (IsSimple((int)temp))
                    result += temp / count++;
                ++temp;
            }

            return (int)Math.Floor(result);
        }

        private static bool IsSimple(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
