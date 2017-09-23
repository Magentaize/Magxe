using System;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
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

        }
    }
}