using Exercise01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = (new CreateData()).GetList();
            list.ForEach(Console.WriteLine);
            Console.WriteLine();

            var newList = list.Where(x => x.Score >= 8).OrderBy(x => x.Birthday).ToList();
            if (newList.Any())
            {
                newList.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("List is empty");
            }
            Console.WriteLine();

            newList = list.Where(x => x.Score >= 5 && x.Score <= 7.5).OrderBy(x => x.Name).ToList();
            if (newList.Any())
            {
                newList.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("List is empty");
            }
            Console.WriteLine();

            newList = list.Where(x => x.Score >= 6 && x.Score <= 8 && x.Birthday.Year >= 1110 && x.Birthday.Year <= 1112).ToList();
            if (newList.Any())
            {
                newList.ForEach(Console.WriteLine);
            } else
            {
                Console.WriteLine("List is empty");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
