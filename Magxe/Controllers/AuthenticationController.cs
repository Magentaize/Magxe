using System.Collections.Generic;
using Magxe.Controllers.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers
{
    [Route("ghost/api/v0.1/[controller]")]
    public class AuthenticationController : Controller
    {
        [Route("setup")]
        [HttpGet]
        public JsonResult SetupGet()
        {
            return Json(new
            {
                setup = new List<Setup>()
                {
                    new Setup() {Status = true}
                }
            });
        }

        [Route("token")]
        [HttpPost]
        public JsonResult Token()
        {
            
        }
    }
}