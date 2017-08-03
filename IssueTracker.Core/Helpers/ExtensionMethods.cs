using System.Collections.Generic;
using System.Linq;

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

        //public static void MergeShallow<T, S>(this T target, S source, params string[] ignoreProperties)
        //{
        //    if (target.IsNull() || source.IsNull())
        //    {
        //        return;
        //    }

        //    var type = typeof(S);
        //    var props = type.GetProperties();

        //    foreach (var prop in props)
        //    {

        //        if (!prop.CanWrite
        //            || prop.PropertyType.IsArray
        //            || prop.PropertyType.IsInterface
        //            || (ignoreProperties != null && ignoreProperties.Contains(prop.Name))
        //            || (prop.PropertyType.IsClass && prop.PropertyType.Name != "String")) // TODO: this is meant to exlude only the custom classes 
        //        {
        //            continue;
        //        }

        //        var value = prop.GetValue(source);
        //        prop.SetValue(target, value);
        //    }
        //}
        
    }
}
