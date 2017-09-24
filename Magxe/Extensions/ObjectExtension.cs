using System;
using System.Diagnostics;

namespace Magxe.Extensions
{
    internal static class ObjectExtension
    {
        [DebuggerHidden]
        public static T Cast<T>(this object o)
        {
            return (T) o;
        }
    }
}