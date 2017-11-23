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
            var students = DataGenerator.CreateStudents().ToList();
            students.ForEach(Console.WriteLine);
            Console.WriteLine();

            var classes = DataGenerator.CreateClasses().ToList();
            classes.ForEach(Console.WriteLine);
            Console.WriteLine();

            var studentsOrderBy = students.OrderBy(x=>x.ClassId)
                .ThenBy(x=>x.Name)
                .ToList();
            studentsOrderBy.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listHasStudentCount = classes.GroupJoin(
                                students,
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

            var listHasHighestScore = classes.GroupJoin(
                                students,
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

            var listHasAverageScore = classes.GroupJoin(
                                students,
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

            var listOfTop5Student = students.OrderByDescending(x=>x.Score).Take(5).ToList();
            listOfTop5Student.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfTop5StudentHasSroceGreater6 = students
                .Where(x => x.Score >= 6)
                .OrderByDescending(x => x.Score)
                .Take(3)
                .ToList();
            listOfTop5StudentHasSroceGreater6.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOf5StudentRandomSelect = students.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            listOf5StudentRandomSelect.ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
