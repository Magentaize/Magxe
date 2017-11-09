using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;
using System.IO;
using System.Text;
using static Magxe.Helpers.BlockAndContentForHelper;

namespace Magxe.Helpers
{
    internal class ContentForHelper : HandlebarsBaseHelper
    {
        public ContentForHelper() : base("contentFor", HelperType.HandlebarsBlockHelper)
        {
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context,
            params object[] arguments)
        {
            var key = arguments[0].CastTo<string>();
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                options.Template(sw, null);
            }
            Blocks[key] = sb.ToString();
        }
    }
}