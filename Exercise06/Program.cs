using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise06
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 100;

            var ints = Enumerable.Range(2, n);
            var list = ints.TakeWhile(x => x < n)
                .Where(x => !ints.TakeWhile(y => y <= (int)Math.Sqrt(x))
                .Any(y => x % y == 0));

            foreach(var i in list)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
