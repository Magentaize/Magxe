using System.Collections.Generic;
using System.Reflection;

namespace Magxe.Extensions
{
    internal static class ConstructorInfoExtension
    {
        public static T InvokeWithNamedParameters<T>(this ConstructorInfo ctor,
            IDictionary<string, object> namedParameters)
        {
            return ctor.Invoke(MethodBaseExtension.MapParameters(ctor, namedParameters)).CastTo<T>();
        }
    }
}