using System;
using System.Linq;
using AutoMapper;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Magxe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using Magxe.Services;

namespace Magxe.Controllers
{
    [Route("")]
    [Route("page/{pageNumber=1:int}")]
    public class IndexController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public IndexController(ThemeService themeService, DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int pageNumber)
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            if (pageNumber > await _dataContext.Posts.GetTotalPageAsync())
            {
                return new NotFoundResult();
            }

            var posts =
                _dataContext.Posts
                    .GetPagePosts(pageNumber)
                    .Select(p => _mapper.Map<Post, IndexPostViewModel>(p));

            var vm = new IndexViewModel()
            {
                ControllerType = ControllerType.Index,
                meta_title = await _dataContext.Settings.GetSettingAsync(Key.Title),
                blog = await _dataContext.Settings.GetBlogViewModelAsync(),
                posts = posts
            };

            return View("index", vm);
        }
    }
}