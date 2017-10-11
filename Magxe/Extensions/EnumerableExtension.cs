using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magxe.Extensions
{
    internal static class EnumerableExtension
    {
        public static IEnumerable<TResult> Cast<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> converter)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (converter == null)
                throw new ArgumentNullException(nameof(converter));

            foreach (var obj in source) yield return converter(obj);
        }

        public static IEnumerable<TResult> SelectSync<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, Task<TResult>> selector)
        {
            return source.Select(selector).Select(t => t.Result);
        }
     }
}