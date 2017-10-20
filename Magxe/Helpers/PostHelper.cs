using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using System.IO;

namespace Magxe.Helpers
{
    public class PostHelper : HandlebarsBaseHelper
    {
        public PostHelper() : base("post", HelperType.HandlebarsBlockHelper)
        {
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            options.Template(output, context);
        }
    }
}