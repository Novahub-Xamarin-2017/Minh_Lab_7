using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise08
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers1 = inputNumbers(new[] { 1, 2, 3, 4, 5, 6 }).ToList();
            var numbers2 = inputNumbers(new[] { 4, 5, 6, 7, 8, 9 }).ToList();

            var listCommon = numbers1.Join(
                numbers2,
                x => x,
                y => y,
                (x, y) => new
                    {
                        x = x
                    })
                .ToList();

            listCommon.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfNumberOnlyExistListFirst = numbers1
                .Where(x => !numbers2
                    .Any(y => y == x))
                .ToList();

            listOfNumberOnlyExistListFirst.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfNumberExistOnlyList = numbers1
                .Union(numbers2)
                .Where(x => !listCommon
                    .Any(y => y.x == x))
                .ToList();

            listOfNumberExistOnlyList.ForEach(Console.WriteLine);
            Console.WriteLine();


            var sum = numbers1.Select((x, i) => new
                {
                    x = x,
                    i = i
                })
                .TakeWhile(x => true)
                .Sum(x => numbers2
                .Select((y, j) => new
                    {
                        y = y,
                        j = j
                    })
                .TakeWhile(y => true)
                .Sum(y => (y.j != x.i) ? (y.y * x.x) : 0));

            Console.WriteLine(sum);

            Console.ReadKey();
        }

        static IEnumerable<int> inputNumbers(IList<int> defaultNumbers)
        {
            var n = InputNumber(Console.ReadLine(), 0);

            if (n != 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    var temp = InputNumber(Console.ReadLine(), 0);
                    yield return temp;
                }
            }
            else
            {
                foreach (var defaultNumber in defaultNumbers)
                {
                    yield return defaultNumber;
                }
            }
            
        }

        static int InputNumber(string str, int defaultNumber)
        {
            var number = 0;
            int.TryParse(str, out number);
            return (number == 0) ? defaultNumber : number;
        }
    }
}
