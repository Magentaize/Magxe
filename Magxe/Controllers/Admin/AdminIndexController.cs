using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers.Admin
{
    public class AdminIndexController
    {
        [Route("ghost")]
        [HttpGet]
        public IActionResult Index()
        {
            var html = File.OpenRead(Path.Combine("Admin", "Views", "default.html"));

            return new FileStreamResult(html, "text/html");
        }
    }
}