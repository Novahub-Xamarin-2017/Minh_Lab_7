using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01.Model
{
    class Student
    {
        public string Name { set; get; }
        public double Score { set; get; }
        public DateTime Birthday { set; get; }

        public override string ToString()
        {
            return $"Name: {Name} Score: {Score} Birthday: {Birthday}";
        }
    }
}
