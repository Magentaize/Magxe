using HandlebarsDotNet;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Dao;
using Magxe.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Magxe.Helpers
{
    internal class TagsHelper : HandlebarsBaseHelper
    {
        public TagsHelper() : base("tags", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] oArguments)
        {
            var tags = (IEnumerable<Tag>) context.tags;
            var enumerable = tags as IList<Tag> ?? tags.ToList();

            if (enumerable.Any())
            {
                var arguments = oArguments[0].Cast<HashParameterDictionary>();
                var prefix = arguments.GetValueOrDefault("prefix", string.Empty).Cast<string>();

                var sb = new StringBuilder(prefix, 200);
                foreach (var tag in enumerable)
                {
                    sb.Append($"<a href=\"/tag/{tag.Slug}/\">{tag.Name}</a>, ");
                }
                sb.Remove(sb.Length - 2, 2);

                output.WriteSafeString(sb.ToString());
            }
        }
    }
}