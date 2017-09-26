using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Data;

namespace Magxe.Helpers
{
    public class AuthorHelper : BaseHelper
    {
        private readonly DataContext _dataContext;

        public AuthorHelper(DataContext dataContext) : base("author", HelperType.HandlebarsBlockHelper)
        {
            _dataContext = dataContext;
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {

        }
    }
}