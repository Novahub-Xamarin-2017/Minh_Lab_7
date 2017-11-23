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

            var numbers = Enumerable.Range(2, n);
            var primeNumbers = numbers.TakeWhile(x => x < n)
                .Where(x => !numbers.TakeWhile(y => y <= (int)Math.Sqrt(x))
                .Any(y => x % y == 0)).ToList();

            primeNumbers.ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}
