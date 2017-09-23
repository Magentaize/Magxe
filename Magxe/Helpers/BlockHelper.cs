using System;
using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;

namespace Magxe.Helpers
{
    internal class BlockHelper : BaseHelper
    {
        public BlockHelper() : base("block", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {

        }
    }
}