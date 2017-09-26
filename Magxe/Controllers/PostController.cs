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
            var postData1 = _dataContext.Posts
                .Where(row => row.Slug == HttpContext.GetRouteValue("postSlug").Cast<string>())
                .Select(row => row.Html);
            var viewData = new PostModel()
            {
                blog = await _dataContext.Settings.GetBlogModelAsync()
            };
            return View();
        }
    }


}