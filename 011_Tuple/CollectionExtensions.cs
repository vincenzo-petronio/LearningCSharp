using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _011_Tuple
{
    public static class CollectionExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }
    }
}
