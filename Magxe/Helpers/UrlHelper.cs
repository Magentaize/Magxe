using System;
using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Data.Meta;
using Magxe.Extensions;
using Magxe.Views.Abstractions;

namespace Magxe.Helpers
{
    internal class UrlHelper : HandlebarsBaseHelper
    {
        public UrlHelper() : base("url", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var vm = (ISlug) context;
            bool absolute = false;
            if (arguments.Length != 0)
            {
                absolute = Convert.ToBoolean(arguments[0].Cast<HashParameterDictionary>()["absolute"].Cast<string>());
            }
            if (!absolute)
            {
                var uri = new Uri(Config.Url, vm.slug);
                output.WriteSafeString(uri.ToString());
            }
            else
            {
                output.WriteSafeString(vm.slug);
            }
        }
    }
}