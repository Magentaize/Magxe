using AutoMapper;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Magxe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Magxe.Controllers
{
    [Route("")]
    [Route("page/{pageNumber=1:int}")]
    public class IndexController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public IndexController(DataContext dataContext, IMapper mapper)
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
                    .SelectSync(async p =>
                        {
                            var ivm = new PostViewModel()
                            {
                                title = p.Title,
                                url = p.Slug,
                                date = p.UpdatedTime,
                                author = _mapper.Map<User, AuthorViewModel>(await _dataContext.Users.GetUserByIdAsync(p.AuthorId)),
                                tags = _dataContext.GetTagsByIds(p.Tags),
                                CustomExcerpt = p.CustomExcerpt,
                                Html = p.Html
                            };
                            return ivm;
                        }
                    );
       
            var title = await _dataContext.GetSettingAsync(Key.Title);

            var vm = new IndexViewModel()
            {
                ControllerType = ControllerType.Index,
                meta_title = await _dataContext.GetSettingAsync(Key.Title),
                blog = new BlogViewModel()
                {
                    title = title,
                    logo = await _dataContext.GetSettingAsync(Key.Logo),
                    cover_image = await _dataContext.GetSettingAsync(Key.CoverImage),
                    description = await _dataContext.GetSettingAsync(Key.Description),
                    navigation = await _dataContext.Settings.GetNavigationsAsync()
                },
                posts = posts
            };

            return View("index", vm);
        }
    }
}