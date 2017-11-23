using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Model
{
    class DataGenerator
    {
        public static IEnumerable<Catalog> CreateCatalogs()
        {
            var Catalogs = new List<Catalog>();
            for (int i = 1; i <= 4; i++)
            {
                yield return new Catalog {
                    Id = i,
                    Name = $"Catalog{i}" };
            }
        }

        public static IEnumerable<Book> CreateBooks()
        {
            for (int i = 1; i <= 10; i++)
            {
                yield return new Book {
                    Id = i,
                    Title = $"Title{i}",
                    CatalogId = i % 3 + 1,
                    AuthorId = i % 3 + 1,
                    Rate = i % 5 + 1 };
            }
        }

        public static IEnumerable<Author> CreateAuthors()
        {
            for (int i = 1; i <= 4; i++)
            {
                yield return new Author {
                    Id = i,
                    Name = $"Author{i}" };
            }
        }
    }
}
