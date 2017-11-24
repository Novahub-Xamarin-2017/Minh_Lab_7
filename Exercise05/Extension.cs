using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05
{
    public static class Extension
    {
        public static IEnumerable<List<T>> SubList<T>(this IList<T> list, int max)
        {
            for (int i = 0; i <= (list.Count - 1) / max; i++)
            {
                var newList = new List<T>();

                for (int j = 1; j <= max; j++)
                {
                    if (max * i + j - 1 > list.Count - 1)
                    {
                        break;
                    }
                    newList.Add(list[max * i + j - 1]);
                }

                yield return newList;
            }
        }
    }
}
