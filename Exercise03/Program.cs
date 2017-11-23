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
            var data = new CreateData();

            var listAuthors = data.GetAuthors();
            listAuthors.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listCatalogs = data.GetCatalogs();
            listCatalogs.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listBooks = data.GetBooks();
            listBooks.ForEach(Console.WriteLine);
            Console.WriteLine();

            var listOfBook = listBooks.Join(
                listCatalogs,
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
                    listAuthors,
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

            var listOfCatalog = listCatalogs.GroupJoin(
                listBooks,
                x => x.Id,
                y => y.CatalogId,
                (x, group) => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    BookExample = group
                }).ToList();
            foreach (var i in listOfCatalog)
            {
                Console.Write($"{i.Id} | {i.Name} | ");
                if (i.BookExample.Any())
                {
                    Console.Write($"{i.BookExample.Average(m => m.Rate)} | ");
                    foreach (var j in i.BookExample)
                    {
                        Console.Write($"Book{j.Id} ");
                    }
                    Console.WriteLine($"| {i.BookExample.Count()}");
                }
                else
                {
                    Console.WriteLine($"0.0 | null | 0");
                }
            }
            Console.WriteLine();

            var listOfAuthor = listAuthors.GroupJoin(
                listBooks,
                x => x.Id,
                y => y.AuthorId,
                (x, group) => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    CatalogExample = group
                }).ToList();

            foreach(var i in listOfAuthor)
            {
                Console.Write($"{i.Id} | {i.Name} | ");
                if (i.CatalogExample.Any())
                {
                    Console.Write($"{i.CatalogExample.Average(m=>m.Rate)} | ");
                    foreach (var j in i.CatalogExample)
                    {
                        Console.Write($"{listCatalogs.Find(m => m.Id == j.CatalogId).Name} ");
                    }
                    Console.WriteLine($"| {i.CatalogExample.Count()}");
                } else
                {
                    Console.WriteLine($"0.0 | null | 0");
                }
            }
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
