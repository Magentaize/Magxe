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
        private ThemeService _themeService;

        public AssetsController(ThemeService themeService)
        {
            _themeService = themeService;
        }

        [Route("css/{file}")]
        public async Task<IActionResult> GetCss()
        {
            var filePath = Path.Combine("themes", Path.Combine(_themeService.CurrentTheme, "assets", "css",
                HttpContext.GetRouteValue("file").Cast<string>()));

            if (!System.IO.File.Exists(filePath))
            {
                return new NotFoundResult();
            }
            else
            {
                var stream = new FileStream(filePath, FileMode.Open);
                var res = File(stream, "text/css");
                return res;
            }
        }
    }
}