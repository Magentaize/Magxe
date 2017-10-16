using AutoMapper;
using Magxe.Data;
using Magxe.Extensions;
using Magxe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Magxe.Controllers
{
    [Route("author/{slug}")]
    [Route("author/{slug}/page/{pageNumber=1:int}")]
    public class AuthorContolller : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AuthorContolller(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string slug, int pageNumber)
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            var author = await _dataContext.Users.FirstOrDefaultAsync(row => row.Slug == slug);
            if (author == null)
            {
                return new NotFoundResult();
            }
            var (totalPages, totalPosts) = await _dataContext.Posts.GetAuthorTotalPagesAsync(author.Id);
            if (pageNumber > totalPages)
            {
                return new NotFoundResult();
            }

            var posts =
                _dataContext.Posts
                    .GetAuthorPagePosts(pageNumber, author.Id)
                    .Select(p => _mapper.Map<Post, PostViewModel>(p));

            var vm = await author.MapAsync<User, AuthorControllerViewModel>();
            vm.ControllerType = ControllerType.Author;
            vm.blog = await _dataContext.Settings.GetBlogViewModelAsync();
            vm.posts = posts;
            vm.PluralNumber = totalPosts;

            return View("author", vm);
        }
    }
}