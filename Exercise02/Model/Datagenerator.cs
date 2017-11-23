using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.Model
{
    class DataGenerator
    {
        public static IEnumerable<Student> CreateStudents()
        {
            for (int i = 1; i <= 10; i++)
            {
                yield return new Student {
                    Id = i,
                    Name = $"{(char)(i + 'a' - 1)}",
                    Score = i, ClassId = i % 3 + 1,
                    Birthday = new DateTime(1109 + i, 11, 1) };
            }
        }

        public static IEnumerable<Class> CreateClasses()
        {
            for (int i = 1; i <= 3; i++)
            {
                yield return new Class {
                    Id = i,
                    Name = $"Class{i}" };
            }
        }
}
