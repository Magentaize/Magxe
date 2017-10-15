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
        public async Task<IActionResult> GetCss(string file)
        {
            return await GetAsset("css", file, "text/css");
        }

        [Route("js/{file}")]
        public async Task<IActionResult> GetJs(string file)
        {
            return await GetAsset("js", file, "application/javascript");
        }

        [Route("fonts/{file}")]
        public async Task<IActionResult> GetFont(string file)
        {
            var fontType = Path.GetExtension(file);
            switch (fontType)
            {
                case ".woff":
                    return await GetAsset("fonts", file, "application/font-woff");
                default: throw new NotImplementedException($"fontType: {fontType}");
            }
        }

        private async Task<IActionResult> GetAsset(string assetType, string fileName, string contentType)
        {
            var filePath = Path.Combine(_themeService.CurrentThemePath, "assets", assetType, fileName);

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