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
            var n = InputNumber(Console.ReadLine(),5);
            var m = InputNumber(Console.ReadLine(), 20);

            var ints = Enumerable.Range(1, m-1);
            var numbers = ints.OrderBy(x => Guid.NewGuid()).Take(n).ToList();

            numbers.ForEach(Console.WriteLine);

            Console.ReadKey();
        }

        static int InputNumber(string str, int defaultNumber)
        {
            var number = 0;
            int.TryParse(str, out number);
            return (number == 0) ? defaultNumber : number;
        }
    }
}
