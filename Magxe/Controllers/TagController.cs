using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Magxe.Data;
using Magxe.Extensions;
using Magxe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Controllers
{
    [Route("tag/{slug}")]
    [Route("tag/{slug}/page/{pageIndex=1:int}")]
    public class TagController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public TagController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string slug, int pageIndex)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            var tag = await _dataContext.Tags.FirstOrDefaultAsync(row => row.Slug.Equals(slug));
            if (tag == null)
            {
                return new NotFoundResult();
            }

            var (totalPages, totalPosts) = await _dataContext.Tags.GetTagTotalPagesAsync(tag.Id);
            if (pageIndex > totalPages)
            {
                return new NotFoundResult();
            }

            var posts =
                _dataContext.PostTags
                    .GetPagedPostsByTagId(tag.Id, pageIndex)
                    .Select(p => p.MapAsync<Post, PostViewModel>().Result);

            var vm = await tag.MapAsync<Tag, TagControllerViewModel>();
            vm.ControllerType = ControllerType.Tag;
            vm.blog = await _dataContext.Settings.GetBlogViewModelAsync();
            vm.posts = posts;
            vm.PluralNumber = totalPosts;
            vm.IsPaged = pageIndex != 1;
            vm.PageInfo = (totalPages, pageIndex);

            return View("tag", vm);
        }
    }
}