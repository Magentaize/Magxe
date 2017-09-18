using HandlebarsDotNet;
using Magxe.Data.Meta;

namespace Magxe.Helpers
{
    internal static class DateHelper
    {
        internal static void RegisterHelper()
        {
            Handlebars.RegisterHelper("date", (writer, context, parameters) =>
            {
                string timezone, format, timeago, timeNow;
            });
        }
    }
}