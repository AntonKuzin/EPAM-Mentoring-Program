using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(TestClass);
            var attrs = type.GetCustomAttributes(false);

            foreach (var attr in attrs)
            {
                Console.WriteLine(attr);
            }

        }
    }
}
