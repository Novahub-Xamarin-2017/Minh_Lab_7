using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.Model
{
    class Student
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public double Score { set; get; }

        public int ClassId { set; get; }

        public DateTime Birthday { set; get; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Score: {Score} ClassId: {ClassId} Birthday: {Birthday}";
        }
    }
}
