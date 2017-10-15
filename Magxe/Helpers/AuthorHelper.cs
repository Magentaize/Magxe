using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Models;
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
            var vm = (PostAuthorViewModel)(context.author);
            output.WriteSafeString($"<a href=\"/author/{vm.slug}/\">{vm.name}</a>");
        }
    }
}