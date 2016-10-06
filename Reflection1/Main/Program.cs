using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom("..\\..\\..\\Library\\bin\\Debug\\Library.dll");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Please, build a Library project first.");
                return;
            }

            var types = assembly.DefinedTypes;
            var type = types.FirstOrDefault();

            if (type == null)
            {
                Console.WriteLine("No types found.");
                return;
            }

            ConstructorInfo[] constructors = type.GetConstructors();

            if (constructors.Length == 0)
            {
                Console.WriteLine($"Cannot create instance of {type.Name} class");
                return;
            }

            foreach (ConstructorInfo c in constructors)
            {
                Console.Write(c.Name + "(");

                ParameterInfo[] p = c.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                    Console.Write(p[i].ParameterType.Name + " " + p[i].Name);
                    if (i + 1 < p.Length) Console.Write(", ");
                }
                Console.Write(")\n\n");
            }

            Type listType = typeof(List<>).MakeGenericType(type);
            IList list = (IList)Activator.CreateInstance(listType);

            list.Add(Activator.CreateInstance(type, 1));
            list.Add(Activator.CreateInstance(type, 2));
            list.Add(Activator.CreateInstance(type, 3));
            list.Add(Activator.CreateInstance(type, 4));
            list.Add(Activator.CreateInstance(type, 5));
        }
    }
}
