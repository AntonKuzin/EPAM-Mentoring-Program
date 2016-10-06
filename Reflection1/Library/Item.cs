using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Item
    {
        public Item(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public void Do()
        {
            Console.WriteLine("Done!");
        }
    }
}
