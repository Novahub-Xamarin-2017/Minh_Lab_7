using Exercise02.Model;
using LINQPad;
using LINQPad.FSharpExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new CreateData();

            var listOfStudent = data.GetStudents();
            listOfStudent.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfClass = data.GetClasses();
            listOfClass.ForEach(Console.WriteLine);
            Console.WriteLine();

            var list = listOfStudent.OrderBy(x=>x.ClassId).ThenBy(x=>x.Name).ToList();
            list.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listHasStudentCount = listOfClass.GroupJoin(
                                listOfStudent,
                                x => x.Id,
                                y => y.ClassId,
                                (x, group) => new
                                {
                                    NumberOfStudents = group.Count(),
                                    Id = x.Id,
                                    Name = x.Name
                                }).ToList();
            listHasStudentCount.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listHasHighestScore = listOfClass.GroupJoin(
                                listOfStudent,
                                x => x.Id,
                                y => y.ClassId,
                                (x, group) => new
                                {
                                    HighestScore = group.Max(m=>m.Score),
                                    Id = x.Id,
                                    Name = x.Name
                                }).ToList();
            listHasHighestScore.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listHasAverageScore = listOfClass.GroupJoin(
                                listOfStudent,
                                x => x.Id,
                                y => y.ClassId,
                                (x, group) => new
                                {
                                    AverageScore = group.Average(m => m.Score),
                                    Id = x.Id,
                                    Name = x.Name
                                }).ToList();
            listHasAverageScore.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfTop5Student = listOfStudent.OrderByDescending(x=>x.Score).Take(5).ToList();
            listOfTop5Student.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfTop5StudentHasSroceGreater6 = listOfStudent.Where(x => x.Score >= 6).OrderByDescending(x => x.Score).Take(3).ToList();
            listOfTop5StudentHasSroceGreater6.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOf5StudentRandomSelect = listOfStudent.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            listOf5StudentRandomSelect.ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
