using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Dao;
using Magxe.Dao.Setting;
using Magxe.Extensions;
using System.IO;

namespace Magxe.Helpers
{
    public class GhostHeadHelper : HandlebarsBaseHelper
    {
        private readonly DataContext _dataContext;

        public GhostHeadHelper(DataContext dataContext) : base("ghost_head", HelperType.HandlebarsHelper)
        {
            _dataContext = dataContext;
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            output.WriteSafeString(_dataContext.Settings.GetSettingAsync(Key.CodeInjectionHead).Result);
        }
    }
}