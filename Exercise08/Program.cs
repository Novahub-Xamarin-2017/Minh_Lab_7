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
            var nString = Console.ReadLine();
            var n = 0;
            int.TryParse(nString, out n);

            var numbers1 = new List<int>();

            if (n != 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    var tempString = Console.ReadLine();
                    var temp = 0;
                    int.TryParse(tempString, out temp);
                    numbers1.Add(temp);
                }
            } else
            {
                numbers1 = new[] { 1, 2, 3, 4, 5, 6 }.ToList();
            }

            var mString = Console.ReadLine();
            var m = 0;
            int.TryParse(nString, out m);

            var listSecond = new List<int>();

            if (m != 0)
            {
                for (int i = 1; i <= m; i++)
                {
                    var tempString = Console.ReadLine();
                    var temp = 0;
                    int.TryParse(tempString, out temp);
                    listSecond.Add(temp);
                }
            }
            else
            {
                listSecond = new[] { 4, 5, 6, 7, 8, 9 }.ToList();
            }

            var listCommon = numbers1.Join(
                listSecond,
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
                .Where(x => !listSecond
                    .Any(y => y == x))
                .ToList();

            listOfNumberOnlyExistListFirst.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfNumberExistOnlyList = numbers1
                .Union(listSecond)
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
                .Sum(x => listSecond
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
    }
}
