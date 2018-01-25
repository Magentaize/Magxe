using System;
using Magxe.Dao;
using Magxe.Dao.Setting;
using Magxe.Extensions;
using Magxe.Models;
using Magxe.Models.ControllerViewModels;
using Magxe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Magxe.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Controllers
{
    [Route("")]
    [Route("page/{pageIndex=1:int}")]
    public class IndexController : Controller
    {
        private readonly DataContext _dataContext;

        public IndexController(ThemeService themeService, DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index(int pageIndex)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            var totalPages = await _dataContext.Posts.GetTotalPagesAsync();
            if (pageIndex > totalPages && totalPages != 0)
            {
                return new NotFoundResult();
            }

            var posts =
                _dataContext.Posts.Include(r => r.PostsTags).ThenInclude(r => r.Tag).Include(r=>r.Author)
                    .GetPagedPosts(pageIndex)
                    .Select(p => p.MapAsync<Post, PostViewModel>().Result);

            var vm = new IndexControllerViewModel()
            {
                ControllerType = ControllerType.Index,
                meta_title = await _dataContext.Settings.GetSettingAsync(Key.Title),
                blog = await _dataContext.Settings.GetBlogViewModelAsync(),
                posts = posts,
                IsPaged = pageIndex != 1,
                PageInfo = (totalPages, pageIndex),
            };

            return View("index", vm);
        }
    }
}