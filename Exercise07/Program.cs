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
            var nString = Console.ReadLine();
            var n = 0;
            int.TryParse(nString, out n);

            var mString = Console.ReadLine();
            var m = 0;
            int.TryParse(nString, out m);

            if (n==0)
            {
                n= 5;
            }

            if (m == 0)
            {
                m= 20;
            }

            var ints = Enumerable.Range(1, m-1);
            var numbers = ints.OrderBy(x => Guid.NewGuid()).Take(n).ToList();

            numbers.ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}
