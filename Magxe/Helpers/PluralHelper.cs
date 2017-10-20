using HandlebarsDotNet;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;
using Magxe.Views.Abstractions;
using System.IO;

namespace Magxe.Helpers
{
    public class PluralHelper : HandlebarsBaseHelper
    {
        public PluralHelper() : base("plural", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            if (!(context is IPlural vm)) return;
            var num = vm.PluralNumber;
            var dict = arguments[1].Cast<HashParameterDictionary>();
            if (num >= 2)
            {
                output.WriteSafeString(dict["plural"].Cast<string>().Replace("%", num.ToString()));
            }
            else if (num == 1)
            {
                output.WriteSafeString(dict["singular"].Cast<string>().Replace("%", num.ToString()));
            }
            else
            {
                output.WriteSafeString(dict["empty"].Cast<string>().Replace("%", num.ToString()));
            }
        }
    }
}