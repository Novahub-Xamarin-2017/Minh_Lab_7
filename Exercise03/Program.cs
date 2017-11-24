using Exercise03.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            var authors = DataGenerator.CreateAuthors().ToList();
            authors.ForEach(Console.WriteLine);
            Console.WriteLine();

            var catalogs = DataGenerator.CreateCatalogs().ToList();
            catalogs.ForEach(Console.WriteLine);
            Console.WriteLine();

            var books = DataGenerator.CreateBooks().ToList();
            books.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfBook = books.Join(
                catalogs,
                x => x.CatalogId,
                y => y.Id,
                (x, y) => new
                {
                    Id = x.Id,
                    Title = x.Title,
                    CatalogName = y.Name,
                    AuthorId = x.AuthorId,
                    Rate = x.Rate
                }).Join(
                    authors,
                    x=>x.AuthorId,
                    y=>y.Id,
                    (x,y) => new
                    {
                        Id = x.Id,
                        Title = x.Title,
                        CatalogName = x.CatalogName,
                        AuthorName = y.Name,
                        Rate = x.Rate
                    }).ToList();
            listOfBook.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfCatalog = catalogs.GroupJoin(
                books,
                x => x.Id,
                y => y.CatalogId,
                (x, group) => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    BookExample = group
                }).ToList();

            listOfCatalog.ForEach(x => 
            {
                Console.Write($"{x.Id} | {x.Name} | ");
                if (x.BookExample.Any())
                {
                    Console.Write($"{x.BookExample.Average(m => m.Rate)} | ");
                    x.BookExample.ToList().ForEach(y =>
                    {
                        Console.Write($"Book{y.Id} ");
                    });
                    Console.WriteLine($"| {x.BookExample.Count()}");
                } else
                {
                    Console.WriteLine($"0.0 | null | 0");
                }
            });
            Console.WriteLine();

            var listOfAuthor = authors.GroupJoin(
                books,
                x => x.Id,
                y => y.AuthorId,
                (x, group) => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    CatalogExample = group
                }).ToList();

            listOfAuthor.ForEach(x =>
            {
                Console.Write($"{x.Id} | {x.Name} | ");
                if (x.CatalogExample.Any())
                {
                    Console.Write($"{x.CatalogExample.Average(m => m.Rate)} | ");
                    x.CatalogExample.ToList().ForEach(y =>
                    {
                        Console.Write($"{catalogs.Find(m => m.Id == y.CatalogId).Name} ");
                    });
                    Console.WriteLine($"| {x.CatalogExample.Count()}");
                }
                else
                {
                    Console.WriteLine($"0.0 | null | 0");
                }
            });
            Console.WriteLine();

            var searchString = Console.ReadLine();
            var ListSearch = listOfBook.Where(x => x.Title.Contains(searchString) || x.AuthorName.Contains(searchString) || x.CatalogName.Contains(searchString)).ToList();
            if (ListSearch.Any())
            {
                ListSearch.ForEach(Console.WriteLine);
            } else
            {
                Console.WriteLine("Result is empty");
            }

            Console.ReadKey();
        }
    }
}
