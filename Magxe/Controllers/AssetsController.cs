using Magxe.Extensions;
using Magxe.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Magxe.Controllers
{
    [Route("assets")]
    public class AssetsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ThemeService _themeService;

        public AssetsController(IHostingEnvironment hostingEnvironment, ThemeService themeService)
        {
            _hostingEnvironment = hostingEnvironment;
            _themeService = themeService;
        }

        [Route("css/{file}")]
        public async Task<IActionResult> GetCss()
        {
            return await GetAsset("css", "text/css");
        }

        [Route("js/{file}")]
        public async Task<IActionResult> GetJs()
        {
            return await GetAsset("js", "application/javascript");
        }

        [Route("fonts/{file}")]
        public async Task<IActionResult> GetFont()
        {
            var fontType = Path.GetExtension(HttpContext.GetRouteValue("file").Cast<string>());
            switch (fontType)
            {
                case ".woff":
                    return await GetAsset("fonts", "application/font-woff");
                default: throw new NotImplementedException($"fontType: {fontType}");
            }
        }

        private async Task<IActionResult> GetAsset(string assetType, string contentType)
        {
            var filePath = Path.Combine(_themeService.CurrentThemePath, "assets", assetType,
                HttpContext.GetRouteValue("file").Cast<string>());

            if (!System.IO.File.Exists(filePath))
            {
                return new NotFoundResult();
            }

            FileStreamResult res = null;
            await Task.Run(() =>
            {
                var stream = new FileStream(filePath, FileMode.Open);
                res = File(stream, contentType);
            });
            return res;
        }
    }
}