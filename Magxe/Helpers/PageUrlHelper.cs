using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.RegularExpressions;

namespace Magxe.Helpers
{
    public class PageUrlHelper : HandlebarsBaseHelper
    {
        private static Regex pattern = new Regex(@"(.+)?(/page/\d+)");

        private readonly IHttpContextAccessor _httpContextAccessor;

        public PageUrlHelper(IHttpContextAccessor httpContextAccessor) : base("page_url", HelperType.HandlebarsHelper)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var page = (int) arguments[0];
            var path = _httpContextAccessor.HttpContext.Request.Path.Value;
            var match = path.Match(pattern);
            string url;
            if (page == 1)
                url = match.Success ? match.Groups[1].Value : path;
            else
                url = match.Success ? $"{match.Groups[1].Value}/page/{page}" : $"{path}page/{page}";

            output.WriteSafeString(url);
        }
    }
}