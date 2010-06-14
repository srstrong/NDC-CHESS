using System;
using System.Collections.Generic;

namespace Utils
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> ForAll<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }

            return source;
        }
    }

}
