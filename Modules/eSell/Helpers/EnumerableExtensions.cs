using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSell.Helpers
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Each<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var i = 0;
            if (source != null)
            {
                foreach (var item in source)
                {
                    action(item, i);
                    i++;
                }
            }
            return source;
        }
    }
}