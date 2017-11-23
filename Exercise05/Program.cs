using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.SubList(4);

            foreach(var i in list)
            {
                foreach (var j in i)
                {
                    Console.WriteLine(j);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
