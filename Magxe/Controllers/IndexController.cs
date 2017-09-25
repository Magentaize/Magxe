using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Magxe.Controllers
{
    [Route("")]
    public class IndexController : Controller
    {
        private readonly DataContext _dataContext;

        public IndexController(DataContext dataContext)
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
                    title,
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