using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;

namespace Magxe.Helpers
{
    public class PostClassHelper :BaseHelper
    {
        public PostClassHelper():base("post_class", HelperType.HandlebarsHelper) { }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            output.WriteSafeString("post");
        }
    }
}