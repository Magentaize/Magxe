using System.IO;
using System.Net;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;

namespace Magxe.Helpers
{
    public class EncodeHelper : BaseHelper
    {
        public EncodeHelper() : base("encode", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            output.WriteSafeString(WebUtility.UrlEncode(arguments[0].Cast<string>()));
        }
    }
}