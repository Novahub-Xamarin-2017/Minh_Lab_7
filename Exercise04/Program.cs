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
        public static IEnumerable<string> GetAllFiles(string path, Func<string, bool> endWith)
        {
            var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            var list = new List<string>();

            foreach (var i in files)
            {
                if (endWith(i))
                {
                    yield return i;
                }
            }
        }

        static void Main(string[] args)
        {
            var pathFolder = @"C:\Users\huynh\OneDrive";

            foreach(var i in GetAllFiles(pathFolder, x => x.EndsWith(".txt")))
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
