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
            var instance = new TestClass();
            Type type = typeof(TestClass);
            var attrs = type.GetCustomAttributes(false);

            foreach (var roleAttr in attrs)
            {
                Console.WriteLine(roleAttr);
            }

        }
    }
}
