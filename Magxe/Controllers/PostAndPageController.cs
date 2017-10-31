using Magxe.Dao;
using Magxe.Extensions;
using Magxe.Models.ControllerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Magxe.Controllers
{
    [Route("{slug}")]
    public class PostAndPageController : Controller
    {
        private readonly DataContext _dataContext;

        public PostAndPageController(DataContext dataContext)
        {
            _dataContext = dataContext;
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