using Magxe.Dao;
using Magxe.Extensions;
using Magxe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Magxe.Models.ControllerViewModels;

namespace Magxe.Controllers
{
    [Route("author/{slug}")]
    [Route("author/{slug}/page/{pageIndex=1:int}")]
    public class AuthorContolller : Controller
    {
        private readonly DataContext _dataContext;

        public AuthorContolller(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index(string slug, int pageIndex)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            var author = await _dataContext.Users.FirstOrDefaultAsync(row => row.Slug.Equals(slug));
            if (author == null)
            {
                return new NotFoundResult();
            }

            var (totalPages, totalPosts) = await _dataContext.Posts.GetAuthorTotalPagesAsync(author.Id);
            if (pageIndex > totalPages)
            {
                return new NotFoundResult();
            }

            var posts =
                _dataContext.Posts
                    .GetAuthorPagedPosts(pageIndex, author.Id)
                    .Select(p => p.MapAsync<Post, PostViewModel>().Result);

            var vm = await author.MapAsync<User, AuthorControllerViewModel>();
            vm.ControllerType = ControllerType.Author;
            vm.blog = await _dataContext.Settings.GetBlogViewModelAsync();
            vm.posts = posts;
            vm.PluralNumber = totalPosts;
            vm.IsPaged = pageIndex != 1;
            vm.PageInfo = (totalPages, pageIndex);

            return View("author", vm);
        }
    }
}