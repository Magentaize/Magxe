using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;

namespace Magxe.Helpers
{
    public class PageUrlHelper : HandlebarsBaseHelper
    {
        public PageUrlHelper():base("page_url", HelperType.HandlebarsHelper) { }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var page = (int) arguments[0];
            output.WriteSafeString(page == 1 ? "/" : $"/page/{page}");
        }
    }
}