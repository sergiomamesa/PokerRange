using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Extensions
{
    public static class ExtensionMethods
    {
        public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> selector)
        {
            return !source.Any(selector);
        }
     
        public static bool IsOne<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> selector)
        {
            return source.Count(selector) == 1;
        }

        public static bool IsOne<TSource>(this IEnumerable<TSource> source)
        {
            return source.Count() == 1;
        }
    }
}
