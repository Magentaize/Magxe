using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers.Admin
{
    [Route("assets/{file}")]
    public class AdminAssetsController : Controller
    {
        private static readonly string AdminViewAssetsRoot = Path.Combine("Admin", "Views", "assets");

        [HttpGet]
        public IActionResult Index(string file)
        {
            string contentType = null;
            switch (Path.GetExtension(file))
            {
                case ".css":
                    contentType = "text/css";
                    break;
                case ".js":
                    contentType = "application/javascript";
                    break;
                default: throw new ArgumentNullException();
            }

            if (System.IO.File.Exists(file = Path.Combine(AdminViewAssetsRoot, file)))
            {
                return new FileStreamResult(System.IO.File.OpenRead(file), contentType);
            }

            return new NotFoundResult();
        }
    }
}