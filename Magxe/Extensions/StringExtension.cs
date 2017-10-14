using System.Text.RegularExpressions;

namespace Magxe.Extensions
{
    internal static class StringExtension
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static Match Match(this string input, string pattern)
        {
            return Regex.Match(input, pattern);
        }

        public static string RegexReplace(this string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }

        public static string RegexReplace(this string input, string pattern, string replacement, RegexOptions options)
        {
            return Regex.Replace(input, pattern, replacement, options);
        }

        public static string RegexReplace(this string input, string pattern)
        {
            return Regex.Replace(input, pattern, string.Empty);
        }

        public static string RegexReplace(this string input, string pattern, RegexOptions options)
        {
            return Regex.Replace(input, pattern, string.Empty, options);
        }
    }
}