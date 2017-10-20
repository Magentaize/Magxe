using System.Collections.Generic;
using Magxe.Controllers.Admin.Models;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers
{
    [Route("ghost/api/v0.1")]
    public class AdminApiController : Controller
    {
        private readonly DataContext _dataContext;

        public AdminApiController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("configuration")]
        [HttpGet]
        public JsonResult ConfigurationGet()
        {
            var o = new
            {
                configuration = new List<ConfigurationItem>()
                {
                    new ConfigurationItem()
                    {
                        UseGravatar = true,
                        PublicApi = false,
                        BlogUrl = Config.Url.AbsoluteUri,
                        BlogTitle = _dataContext.Settings.GetSettingAsync(Key.Title).Result,
                        RouteKeywords = new RouteKeywords()
                        {
                            Tag = "tag",
                            Author = "author",
                            Page = "page",
                            Preview = "p",
                            Private = "private",
                            Subscribe = "subscribe",
                            Amp = "amp",
                            PrimaryTagFallback = "all",
                        },
                        ClientId = "ghost-admin",
                        ClientSecret = "d9f3252ef6f8"
                    }
                }
            };

            return Json(o);
        }
    }
}