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
            var count = 0;
            var newList = new List<T>();

            foreach (var i in list)
            {
                newList.Add(i);
                count++;
                if (count == max || i.Equals(list.Last())) 
                {
                    yield return newList;
                    count = 0;
                    newList.Clear();
                }
            }
        }
    }
}
