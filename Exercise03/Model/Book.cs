using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Model
{
    class Book
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public int CatalogId { set; get; }

        public int AuthorId { set; get; }

        public double Rate { set; get; }

        public override string ToString()
        {
            return $"Id: {Id} Title: {Title} Catalog: {CatalogId} AuthorId: {AuthorId} Rate: {Rate}";
        }
    }
}
