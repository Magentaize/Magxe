using System.Text.RegularExpressions;

namespace Magxe.Dao
{
    internal static class Slug
    {
        public static string Slugify(string label)
        {
            var slug = label.ToLower();
            slug = Regex.Replace(slug, @"[^\w ]+/g", string.Empty);
            slug = Regex.Replace(slug, @" +/g", "-");
            return slug;
        }
    }
}