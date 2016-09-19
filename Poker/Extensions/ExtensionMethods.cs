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
            return source.Where(selector).Count() == 0;
        }
     
        public static bool IsOne<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> selector)
        {
            return source.Where(selector).Count() == 1;
        }
    }
}
