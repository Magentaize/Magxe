using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers
{
    [Route("{postSlug}")]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}