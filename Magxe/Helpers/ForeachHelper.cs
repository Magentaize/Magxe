using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;
using System.Collections;
using System.IO;

namespace Magxe.Helpers
{
    internal class ForeachHelper : BaseHelper
    {
        public ForeachHelper() : base("foreach", HelperType.HandlebarsBlockHelper)
        {
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            //var collection = arguments[0].Cast<IEnumerable>();
            //foreach (object o in collection)
            //{
            //    options.Template(output, o);
            //}
        }
    }
}