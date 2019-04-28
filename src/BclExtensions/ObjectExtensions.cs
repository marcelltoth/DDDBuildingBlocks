using System.Collections.Generic;

namespace MarcellToth.BclExtensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        ///     Returns an Enumerable that yields a single item <paramref name="item"/>.
        /// </summary>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
    }
}