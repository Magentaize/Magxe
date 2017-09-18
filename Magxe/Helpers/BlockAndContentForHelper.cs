using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet;

namespace Magxe.Helpers
{
    internal static class BlockAndContentForHelper
    {
        internal static void RegisterHelper()
        {
            RegisterBlockHelper();
            RegisterContentForHelper();
        }

        #region Private
        private static readonly Dictionary<string,string> Blocks = new Dictionary<string, string>();

        private static void RegisterBlockHelper()
        {
            Handlebars.RegisterHelper("block", (writer, context, parameters) =>
            {
            });
        }

        private static void RegisterContentForHelper()
        {
            Handlebars.RegisterHelper("contentFor", (writer, context, parameters) =>
            {
                var key = (string)parameters[0];
                var val = Blocks[key] + '\n';
                Blocks.Remove(key);

                writer.WriteSafeString(val);
            });
        }

        #endregion
    }
}