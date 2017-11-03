using System.Text.RegularExpressions;

namespace Magxe.Utils
{
    internal static class Slug
    {
        public static string Slugify(string label)
        {
            var slug = label.ToLower();
            slug = Regex.Replace(slug, @"[^\w ]+", string.Empty);
            slug = Regex.Replace(slug, @" +", "-");
            return slug;
        }
    }
}