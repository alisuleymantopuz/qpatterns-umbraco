using System;
using System.Collections.Generic;

namespace qPatterns.Core.Domain.Events
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
                action(item);
        }
    }
}
