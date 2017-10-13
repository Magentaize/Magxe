using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Magxe.Extensions
{
    internal static class MethodBaseExtension
    {
        public static T InvokeWithNamedParameters<T>(this MethodBase self, object obj, IDictionary<string, object> namedParameters)
        {
            return self.Invoke(obj, MapParameters(self, namedParameters)).Cast<T>();
        }

        public static object[] MapParameters(MethodBase method, IDictionary<string, object> namedParameters)
        {
            var paramNames = method.GetParameters().Select(p => p.Name).ToArray();
            var parameters = new object[paramNames.Length];
            for (var i = 0; i < parameters.Length; ++i)
            {
                parameters[i] = Type.Missing;
            }
            foreach (var item in namedParameters)
            {
                var paramName = item.Key;
                var paramIndex = Array.IndexOf(paramNames, paramName);
                parameters[paramIndex] = item.Value;
            }
            return parameters;
        }
    }
}