using System.Collections.Generic;
using System.Linq;
using Magxe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using Magxe.Extensions;
using Microsoft.EntityFrameworkCore;
using Magxe.Data.Setting;

namespace Magxe.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var title = await _dataContext.GetValueAsync(Key.Title);
            var blog = new
            {
                meta_title = title,
                blog = new
                {
                    cover_image = await _dataContext.GetValueAsync(Key.CoverImage),
                    logo = await _dataContext.GetValueAsync(Key.Logo),
                    title = title,
                    description = await _dataContext.GetValueAsync(Key.Description),
                    navigation = await _dataContext.Settings.GetNavigationsAsync()
                },
                controllerType = ControllerType.Home
            };
            ViewData["key"] = "blog";
            ViewData["blog"] = blog;
            return View("index");
        }
    }
}