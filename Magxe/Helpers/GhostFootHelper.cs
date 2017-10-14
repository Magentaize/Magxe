using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;

namespace Magxe.Helpers
{
    public class GhostFootHelper: HandlebarsBaseHelper
    {
        private readonly DataContext _dataContext;

        public GhostFootHelper(DataContext dataContext) : base("ghost_foot", HelperType.HandlebarsHelper)
        {
            _dataContext = dataContext;
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            output.WriteSafeString(_dataContext.GetSettingAsync(Key.CodeInjectionFoot).Result);
        }
    }
}