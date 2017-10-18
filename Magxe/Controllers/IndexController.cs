using AutoMapper;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Magxe.Models.ControllerViewModels;
using Magxe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;
using Magxe.Models;

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
            var totalPages = await _dataContext.Posts.GetTotalPagesAsync();
            if (pageNumber > totalPages)
            {
                return new NotFoundResult();
            }

            var posts =
                _dataContext.Posts
                    .GetPagePosts(pageNumber)
                    .Select(p => _mapper.Map<Post, PostViewModel>(p));

            var vm = new IndexControllerViewModel()
            {
                ControllerType = ControllerType.Index,
                meta_title = await _dataContext.Settings.GetSettingAsync(Key.Title),
                blog = await _dataContext.Settings.GetBlogViewModelAsync(),
                posts = posts,
                IsPaged = pageNumber != 1,
                PageInfo = (totalPages, pageNumber),
            };

            return View("index", vm);
        }
    }
}