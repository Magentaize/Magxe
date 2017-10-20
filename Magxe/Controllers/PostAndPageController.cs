using AutoMapper;
using Magxe.Data;
using Magxe.Models.ControllerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Magxe.Extensions;

namespace Magxe.Controllers
{
    [Route("{slug}")]
    public class PostAndPageController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PostAndPageController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string slug)
        {
            var post = await _dataContext.Posts.FirstOrDefaultAsync(p => p.Slug == slug);
            if (post == null)
            {
                return new NotFoundResult();
            }
            PageControllerViewModel vm;
            if (post.IsPage)
            {
                vm = await post.MapAsync<Page, PageControllerViewModel>();
                vm.ControllerType = ControllerType.Page;

                return View("page", vm);
            }
            else
            {
                vm = await post.MapAsync<Post, PostControllerViewModel>();
                vm.ControllerType = ControllerType.Post;

                return View("post", vm);
            }
        }
    }
}