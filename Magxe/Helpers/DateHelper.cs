using HandlebarsDotNet;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Magxe.Helpers
{
    internal class DateHelper : HandlebarsBaseHelper
    {
        public DateHelper() : base("date", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var pattern = arguments[0].Cast<HashParameterDictionary>()["format"].Cast<string>();
            output.WriteSafeString(DateTime.Now.ToString(pattern));
        }
    }
}