using Magxe.Controllers.Admin.Models;
using Magxe.Dao;
using Magxe.Dao.Setting;
using Magxe.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Controllers.Admin.Api
{
    [AdminApiRoute]
    public class Configuration : Controller
    {
        private readonly DataContext _dataContext;

        public Configuration(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<JsonResult> ConfigurationGet()
        {
            var adminClient = await _dataContext.Clients.FirstAsync(r => r.Slug == "ghost-admin");
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
                        ClientSecret = adminClient.Secret
                    }
                }
            };

            return Json(o);
        }
    }
}