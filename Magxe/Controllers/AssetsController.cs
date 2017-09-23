using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Magxe.Extensions;
using Magxe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

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
        public async Task<IActionResult> GetCss()
        {
            return await GetAsset("css", "text/css");
        }

        [Route("js/{file}")]
        public async Task<IActionResult> GetJs()
        {
            return await GetAsset("js", "application/javascript");
        }

        private async Task<IActionResult> GetAsset(string assetType, string contentType)
        {
            var filePath = Path.Combine("themes", Path.Combine(_themeService.CurrentTheme, "assets", assetType,
                HttpContext.GetRouteValue("file").Cast<string>()));

            if (!System.IO.File.Exists(filePath))
            {
                return new NotFoundResult();
            }
            else
            {
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
}