using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using System.IO;
using static Magxe.Helpers.BlockAndContentForHelperCommonData;

namespace Magxe.Helpers
{
    internal class ContentForHelper : BaseHelper
    {
        public ContentForHelper() : base("contentFor", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var key = (string)arguments[0];
            var val = Blocks[key] + '\n';
            Blocks.Remove(key);

            output.WriteSafeString(val);
        }
    }
}