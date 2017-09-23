using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers
{
    [Route("tag/{tagSlug}")]
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}