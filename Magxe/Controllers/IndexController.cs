using System.Diagnostics;
using System.Linq;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Models;
using Microsoft.AspNetCore.Routing;

namespace Magxe.Controllers
{
    [Route("")]
    [Route("page/{pageNumber=1:int}")]
    public class IndexController : Controller
    {
        private readonly DataContext _dataContext;

        public IndexController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index(int pageNumber)
        {
            var postsDb = await _dataContext.GetPostsAsync(pageNumber == 0 ? 1 : pageNumber);
            var posts = postsDb.SelectSync(async p =>
                {
                    var ivm = new PostViewModel()
                    {
                        title = p.Title,
                        url = p.Slug,
                        date = p.UpdatedTime,
                        tags = await _dataContext.GetTagsAsync(p.Tags),
                        CustomExcerpt = p.CustomExcerpt,
                        Html = p.Html
                    };
                    //if (p.CustomExcerpt.IsNullOrEmpty())
                    //{
                    //    ivm.excerpt = p.Html;
                    //}
                    //else
                    //{
                    //    ivm.excerpt = p.CustomExcerpt;
                    //}
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

            ViewData["key"] = "blog";
            ViewData["blog"] = vm;
            return View("index");
        }
    }
}