using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Magxe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Controllers
{
    [Route("{postSlug}")]
    public class PostController : Controller
    {
        private readonly DataContext _dataContext;

        public PostController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var postData = await _dataContext.Posts.FirstOrDefaultAsync(row =>
                row.Slug == HttpContext.GetRouteValue("postSlug").Cast<string>());
            var viewData = new PostModel()
            {
                controllerType = ControllerType.Post,
                blog = await _dataContext.Settings.GetBlogModelAsync(),
                authorId = postData.AuthorId,
                feature_image = postData.FeatureImage,
                title = postData.Title,
                content = postData.Html,
                url = "/"
            };
            ViewData["key"] = "post";
            ViewData["post"] = viewData;
            return View();
        }
    }


}