using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person("test", "sample");
            var p2 = new Person("test", "sample");

            Console.WriteLine(p1.Equals(p2));
        }
    }
}
