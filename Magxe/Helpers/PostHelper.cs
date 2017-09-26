using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;

namespace Magxe.Helpers
{
    public class PostHelper : BaseHelper
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