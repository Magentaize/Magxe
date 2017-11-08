using Magxe.Controllers.Admin.Models;
using Magxe.Dao;
using Magxe.Dao.Setting;
using Magxe.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Magxe.Controllers.Admin.Api
{
    [AdminApiController]
    public class ConfigurationController : Controller
    {
        private readonly DataContext _dataContext;

        public ConfigurationController(DataContext dataContext)
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
                        BlogUrl = GlobalVariables.Config.Url.AbsoluteUri,
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

        [Route("private")]
        [HttpGet]
        [Authorize]
        public IActionResult Private()
        {
            return Json(new
            {
                Configuration = new object { }
            });
        }
    }
}