using HandlebarsDotNet;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;
using Magxe.Views.Abstractions;
using System.IO;
using Magxe.Controllers;

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
            if (vm.ControllerType == ControllerType.Tag)
            {
                output.WriteSafeString(vm.PluralNumber);
                return;
            }

            var num = vm.PluralNumber;
            var dict = arguments[1].CastTo<HashParameterDictionary>();
            if (num >= 2)
            {
                output.WriteSafeString(dict["plural"].CastTo<string>().Replace("%", num.ToString()));
            }
            else if (num == 1)
            {
                output.WriteSafeString(dict["singular"].CastTo<string>().Replace("%", num.ToString()));
            }
            else
            {
                output.WriteSafeString(dict["empty"].CastTo<string>().Replace("%", num.ToString()));
            }
        }
    }
}