using System;
using System.Diagnostics;
using Dynamitey;

namespace Magxe.Extensions
{
    internal static class ObjectExtension
    {
        [DebuggerHidden]
        public static T Cast<T>(this object o)
        {
            return (T) o;
        }

        public static int CastToInt(this object o)
        {
            return Convert.ToInt32(o);
        }
    }
}