using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using System.IO;

namespace Magxe.Helpers
{
    public class PostClassHelper :HandlebarsBaseHelper
    {
        public PostClassHelper():base("post_class", HelperType.HandlebarsHelper) { }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            output.WriteSafeString("post");
        }
    }
}