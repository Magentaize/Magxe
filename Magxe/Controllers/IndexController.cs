using AutoMapper;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Magxe.Models;
using Magxe.Models.ControllerViewModels;
using Magxe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Magxe.Controllers
{
    [Route("")]
    [Route("page/{pageIndex=1:int}")]
    public class IndexController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public IndexController(ThemeService themeService, DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int pageIndex)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            var totalPages = await _dataContext.Posts.GetTotalPagesAsync();
            if (pageIndex > totalPages)
            {
                return new NotFoundResult();
            }

            var posts =
                _dataContext.Posts
                    .GetPagedPosts(pageIndex).ToList()
                    .Select(p => _mapper.Map<Post, PostViewModel>(p)).ToList();

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