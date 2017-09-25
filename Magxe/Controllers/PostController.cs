using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Magxe.Data;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers
{
    [Route("{postSlug}")]
    public class PostController : Controller
    {
        private readonly DataContext _dataContext;

        public PostController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}