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
            var numbers1 = new[] { 1, 2, 3, 4, 5, 6 }.ToList();
            var numbers2 = new[] { 4, 5, 6, 7, 8, 9 }.ToList();

            var listCommon = numbers1.Join(
                numbers2,
                x => x,
                y => y,
                (x, y) => x)
                .ToList();

            listCommon.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfNumberOnlyExistListFirst = numbers1
                .Where(x => numbers2.All(y => y != x))
                .ToList();

            listOfNumberOnlyExistListFirst.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfNumberExistOnlyList = numbers1
                .Union(numbers2)
                .Where(x => listCommon.All(y => y != x))
                .ToList();

            listOfNumberExistOnlyList.ForEach(Console.WriteLine);
            Console.WriteLine();

            var sum = Enumerable.Range(0, numbers1.Count)
                .Sum(x => Enumerable.Range(0, numbers2.Count)
                    .Sum(y => (y != x) ? (numbers1[x] * numbers2[y]) : 0));

            Console.WriteLine(sum);

            Console.ReadKey();
        }
    }
}
