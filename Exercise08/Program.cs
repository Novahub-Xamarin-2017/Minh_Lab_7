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
            var n = (Console.ReadLine().Any()) ? int.Parse(Console.ReadLine()) : 0;

            var listFirst = new[] { 1, 2, 3, 4, 5, 6 }.ToList();
            var listSecond = new[] { 4, 5, 6, 7, 8, 9 }.ToList();

            if (n!=0)
            {
                listFirst.Clear();
                listSecond.Clear();

                for (int i = 1; i <= n; i++)
                {
                    var temp = int.Parse(Console.ReadLine());
                    listFirst.Add(temp);
                }

                n = int.Parse(Console.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    var temp = int.Parse(Console.ReadLine());
                    listSecond.Add(temp);
                }
            }

            var listCommon = listFirst.Join(
                listSecond,
                x => x,
                y => y,
                (x, y) => new
                {
                    x = x
                });
            foreach (var i in listCommon)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            var listOfNumberOnlyExistListFirst = listFirst.Where(x => !listSecond.Any(y => y == x));
            foreach (var i in listOfNumberOnlyExistListFirst)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            var listOfNumberExistOnlyList = listFirst.Union(listSecond).Where(x => !listCommon.Any(y => y.x == x));
            foreach (var i in listOfNumberExistOnlyList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();


            var sum = listFirst.Select((x, i) => new { x = x, i = i }).TakeWhile(x => true)
                .Sum(x => listSecond.Select((y, j) => new { y = y, j = j }).TakeWhile(y => true)
                .Sum(y => (y.j != x.i) ? (y.y * x.x) : 0));
            Console.WriteLine(sum);

            Console.ReadKey();
        }
    }
}
