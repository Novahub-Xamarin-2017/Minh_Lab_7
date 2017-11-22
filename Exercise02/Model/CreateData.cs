using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.Model
{
    class CreateData
    {
        private List<Student> ListOfStudent;

        private List<Class> ListOfClass;

        public CreateData()
        {
            ListOfStudent = new List<Student>();

            for (int i = 1; i <= 10; i++)
            {
                ListOfStudent.Add(new Student { Id = i, Name = $"{(char)(i + 'a' - 1)}", Score = i, ClassId = i % 3 + 1, Birthday = new DateTime(1109 + i, 11, 1) });
            }

            ListOfClass = new List<Class>();

            for (int i = 1; i <= 3; i++)
            {
                ListOfClass.Add(new Class { Id = i, Name = $"Class{i}" });
            }
        }

        public List<Student> GetStudents()
        {
            return ListOfStudent;
        }

        public List<Class> GetClasses()
        {
            return ListOfClass;
        }
    }
}
