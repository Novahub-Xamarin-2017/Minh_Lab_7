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
            var list = (new StudentGenerator()).CreateStudents();
            list.ForEach(Console.WriteLine);
            Console.WriteLine();

            var goodStudents = list.Where(x => x.Score >= 8).OrderBy(x => x.Birthday).ToList();
            if (goodStudents.Any())
            {
                goodStudents.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("List is empty");
            }
            Console.WriteLine();

            var studentsHasScoreBetWeen5And7 = list.Where(x => x.Score >= 5 && x.Score <= 7.5).OrderBy(x => x.Name).ToList();
            if (studentsHasScoreBetWeen5And7.Any())
            {
                studentsHasScoreBetWeen5And7.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("List is empty");
            }
            Console.WriteLine();

            var studentsHasScoreBetWeen6And8 = list.Where(x => x.Score >= 6 && x.Score <= 8 && x.Birthday.Year >= 1110 && x.Birthday.Year <= 1112).ToList();
            if (studentsHasScoreBetWeen6And8.Any())
            {
                studentsHasScoreBetWeen6And8.ForEach(Console.WriteLine);
            } else
            {
                Console.WriteLine("List is empty");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
