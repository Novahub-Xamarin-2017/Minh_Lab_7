using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Model
{
    class CreateData
    {
        private List<Catalog> ListCatalogs;

        private List<Book> ListBooks;

        private List<Author> ListAuthors;

        public CreateData()
        {
            ListCatalogs = new List<Catalog>();
            for (int i = 1; i <= 4; i++)
            {
                ListCatalogs.Add(new Catalog { Id = i, Name = $"Catalog{i}" });
            }

            ListBooks = new List<Book>();
            for (int i = 1; i <= 10; i++)
            {
                ListBooks.Add(new Book { Id = i, Title = $"Title{i}", CatalogId = i % 3 + 1, AuthorId = i % 3 + 1, Rate = i % 5 + 1 });
            }

            ListAuthors = new List<Author>();
            for (int i = 1; i <= 4; i++)
            {
                ListAuthors.Add(new Author { Id = i, Name = $"Author{i}" });
            }
        }

        public List<Catalog> GetCatalogs()
        {
            return ListCatalogs;
        }

        public List<Author> GetAuthors()
        {
            return ListAuthors;
        }

        public List<Book> GetBooks()
        {
            return ListBooks;
        }
    }
}
