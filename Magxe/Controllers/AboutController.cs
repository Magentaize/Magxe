using Magxe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Magxe.Controllers
{
    public class indexController : Controller
    {
        private ThemeService _themeService;
        public indexController(ThemeService themeService)
        {
            _themeService = themeService;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            ViewData["blog"] = new
            {
                title = "title"
            };
            return View();
        }
    }
}