using Magxe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;

namespace Magxe.Controllers
{
    [Route("assets")]
    public class AssetsController : Controller
    {
        private readonly ThemeService _themeService;

        public AssetsController(ThemeService themeService)
        {
            _themeService = themeService;
        }

        [Route("css/{file}")]
        public IActionResult GetCss(string file)
        {
            return GetAsset("css", file, "text/css");
        }

        [Route("js/{file}")]
        public IActionResult GetJs(string file)
        {
            return GetAsset("js", file, "application/javascript");
        }

        [Route("fonts/{file}")]
        public IActionResult GetFont(string file)
        {
            var fontType = Path.GetExtension(file);
            switch (fontType)
            {
                case ".woff":
                    return GetAsset("fonts", file, "application/font-woff");
                default: throw new NotImplementedException($"fontType: {fontType}");
            }
        }

        private IActionResult GetAsset(string assetType, string fileName, string contentType)
        {
            var filePath = Path.Combine(_themeService.CurrentThemePath, "assets", assetType, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return new NotFoundResult();
            }

            return new FileStreamResult(System.IO.File.OpenRead(filePath), contentType);
        }
    }
}