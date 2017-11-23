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
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.SubList(4).ToList();

            numbers.ForEach(x =>
            {
                x.ForEach(Console.WriteLine);
                Console.WriteLine();
            });

            Console.ReadKey();
        }
    }
}
