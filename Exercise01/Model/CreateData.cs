using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01.Model
{
    class CreateData
    {
        private List<Student> list;

        public CreateData()
        {
            list = new List<Student>();

            for (int i = 1; i <= 10; i++)
            {
                list.Add(new Student { Name = $"{(char)(i + 'a' - 1)}", Score = i, Birthday = new DateTime(1109 + i, 11, 1) });
            }
        }

        public List<Student> GetList()
        {
            return list;
        }
    }
}
