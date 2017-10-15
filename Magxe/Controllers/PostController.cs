using AutoMapper;
using Magxe.Data;
using Magxe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Magxe.Controllers
{
    [Route("/{postSlug}")]
    public class PostController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PostController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string postSlug)
        {
            var post = await _dataContext.Posts.FirstOrDefaultAsync(p=>p.Slug==postSlug);
            if (post == null)
            {
                return new NotFoundResult();
            }
            else
            {
                var vm = _mapper.Map<Post, PostViewModel>(post);
                vm.ControllerType = ControllerType.Post;

                return View("post", vm);
            }

            //var postData = await _dataContext.Posts.FirstOrDefaultAsync(row =>
            //    row.Slug == HttpContext.GetRouteValue("postSlug").Cast<string>());
            //var vm = new PostViewModel()
            //{
            //    controllerType = ControllerType.Post,
            //    blog = await _dataContext.Settings.GetBlogModelAsync(),
            //    authorId = postData.AuthorId,
            //    feature_image = postData.FeatureImage,
            //    title = postData.Title,
            //    content = postData.Html,
            //    url = new Uri(Config.Url, HttpContext.Request.Path.Value).ToString(),
            //};          
        }
    }
}