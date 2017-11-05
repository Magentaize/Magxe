using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Magxe.Controllers.Admin
{
    public class AdminAssetsController : Controller
    {
        private static readonly string AdminViewAssetsRoot = Path.Combine("Admin", "Views", "assets");

        [Route("assets/{file}")]
        [Route("ghost/assets/{file}")]
        [HttpGet]
        public IActionResult IndexAssets(string file)
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

        [Route("assets/img/{file}")]
        [Route("ghost/assets/img/{file}")]
        [HttpGet]
        public IActionResult ImgAssets(string file)
        {
            if (System.IO.File.Exists(file = Path.Combine(AdminViewAssetsRoot, "img", file)))
            {
                return new FileStreamResult(System.IO.File.OpenRead(file), "image/png");
            }

            return new NotFoundResult();
        }
    }
}