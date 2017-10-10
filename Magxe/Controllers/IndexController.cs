using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Magxe.Models;

namespace Magxe.Controllers
{
    [Route("")]
    [Route("page/{pageNumber:int}")]
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
            var vm = new IndexViewModel()
            {
                ControllerType = ControllerType.Index,
                meta_title = await _dataContext.GetValueAsync(Key.Title),
                blog = new BlogViewModel()
                {
                    title = title,
                    logo = await _dataContext.GetValueAsync(Key.Logo),
                    cover_image = await _dataContext.GetValueAsync(Key.CoverImage),
                    description = await _dataContext.GetValueAsync(Key.Description),
                    navigation = await _dataContext.Settings.GetNavigationsAsync()
                }
            };

            ViewData["key"] = "blog";
            ViewData["blog"] = vm;
            return View("index");
        }
    }
}