using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04
{
    class Program
    {
        public static IEnumerable<string> GetAllFiles(string path, Func<string, bool> filter)
        {
            var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (filter(file))
                {
                    yield return file;
                }
            }
        }

        static void Main(string[] args)
        {
            var pathFolder = @"C:\Users\huynh\OneDrive";

            GetAllFiles(pathFolder, x =>
                x.EndsWith(".txt"))
                .ToList()
                .ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}
