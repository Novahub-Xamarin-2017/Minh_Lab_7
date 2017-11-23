using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise07
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = (Console.ReadLine().Any()) ? int.Parse(Console.ReadLine()) : 5;
            var m = (Console.ReadLine().Any()) ? int.Parse(Console.ReadLine()) : 20;

            var ints = Enumerable.Range(1, m-1);
            var list = ints.OrderBy(x => Guid.NewGuid()).Take(n);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
