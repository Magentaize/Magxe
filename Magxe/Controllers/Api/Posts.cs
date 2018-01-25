using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Magxe.Attributes;
using Magxe.Controllers.ActionResults;
using Magxe.Dao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Controllers.Api
{
    [RestApiController]
    public class PostsController : Controller
    {
        [Inject]
        public DataContext DbContext { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int limit = 10, [FromQuery] int page = 1,
            [FromQuery] Status status = Status.All, [FromQuery] StaticPages staticPages = StaticPages.All,
            [FromQuery(Name = "filter")] string filter = null, [FromQuery(Name = "formats")] string format = null)
        {
            #region CheckParams

            if ((limit < 1) || (page < 1))
            {
                return new ArgumentOutOfRangeErrorResult();
            }

            filter = filter ?? string.Empty;
            format = format ?? string.Empty;

            #endregion

            var filters = filter.Split('+');
            var formats = format.Split(',');

            IEnumerable<Post> posts = await DbContext.Posts.Include(r => r.PostsTags).ThenInclude(r => r.Tag).Include(r => r.Author).ToListAsync();
            foreach (var f in filters)
            {
                var tf = f.Split(':');
                if (tf[0] == "tag")
                {
                    posts = posts.Where(r => r.Tags.Any(t => t.Slug == tf[1]));
                }
                else if (tf[0] == "author")
                {
                    posts = posts.Where(r => r.Author.Slug == tf[1]);
                }
            }
            return Json(posts);
        }

        public enum Status
        {
            All = 0,
            Draft = 1,
            Scheduled = 2,
            Published = 3,
        }

        public enum StaticPages
        {
            All = 0,
            False = 1,
            True = 2,
        }
    }
}