using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IssueTracker.Core.Helpers
{
    public static class ExtensionMethods
    {
        public static bool IsNull<T>(this T source)
        {
            return source == null;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return (source == null || !source.Any());
        }
    }
}
