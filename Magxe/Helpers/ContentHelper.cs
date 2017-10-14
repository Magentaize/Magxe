using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;

namespace Magxe.Helpers
{
    public class ContentHelper : HandlebarsBaseHelper
    {
        public ContentHelper() : base("content", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var html = (string) context.content;
            output.WriteSafeString(html);
        }
    }
}