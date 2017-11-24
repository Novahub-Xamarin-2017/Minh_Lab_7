using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Model
{
    class Catalog
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}";
        }
    }
}
