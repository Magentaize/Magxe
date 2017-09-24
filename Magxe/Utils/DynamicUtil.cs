using System;
using System.Linq;

namespace Magxe.Utils
{
    internal static class DynamicUtil
    {
        public static bool ContainsKey(dynamic d, string key)
        {
            Type t = d.GetType();
            return t.GetProperties().Any(p => p.Name.Equals(key));
        }
    }
}