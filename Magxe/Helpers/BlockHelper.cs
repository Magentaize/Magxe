using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;
using System.IO;
using static Magxe.Helpers.BlockAndContentForHelperCommonData;

namespace Magxe.Helpers
{
    internal class BlockHelper : HandlebarsBaseHelper
    {
        public BlockHelper() : base("block", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var key = arguments[0].Cast<string>();
            if (Blocks.ContainsKey(key))
            {
                output.WriteSafeString($"{Blocks[key]}\n");
                Blocks[key] = string.Empty;
            }
            else
            {
                Blocks[key] = string.Empty;
            }
        }
    }
}