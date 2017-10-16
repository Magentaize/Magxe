using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Views.Abstractions;
using System.IO;

namespace Magxe.Helpers
{
    public class AuthorHelper : HandlebarsBaseHelper
    {
        public AuthorHelper() : base("author", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var vm = (IPostAuthor) context.author;
            output.WriteSafeString($"<a href=\"{vm.slug}/\">{vm.name}</a>");
        }
    }
}