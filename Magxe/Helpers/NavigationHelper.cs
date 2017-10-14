using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Magxe.Models;
using Magxe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Magxe.Helpers
{
    internal class NavigationHelper : BaseHelper
    {
        private readonly ThemeService _themeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceProvider _services;
        private readonly DataContext _dataContext;

        public NavigationHelper(DataContext dataContext, ThemeService themeService, IHttpContextAccessor httpContextAccessor, IServiceProvider services) : base("navigation", HelperType.HandlebarsHelper)
        {
            _themeService = themeService;
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
            _services = services;
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var navigationData = _dataContext.Settings.GetNavigationsAsync().Result;
            if (navigationData.Count == 0)
            {
                output.WriteSafeString(string.Empty);
            }
            else
            {
                var viewData = new
                {
                    navigation = navigationData.Cast(o => new NavigationViewModelItem()
                    {
                        current = IsCurrentUrl(o.Url),
                        label = o.Label,
                        url = o.Url,
                        secure = false,
                        slug = Slugify(o.Label)
                    })
                };

                // get IHandlebarsViewEngine by DI will crash dotnet process
                var viewEngine = _services.GetService<IHandlebarsViewEngine>();
                var viewPath = Path.Combine(_themeService.CurrentThemePath(), "partials", "navigation");
                var viewHtml = viewEngine.RenderViewWithDataAsync(viewPath, viewData).Result;

                output.WriteSafeString(viewHtml);
            }
        }

        private string Slugify(string label)
        {
            var slug = label.ToLower();
            slug = Regex.Replace(slug, @"[^\w ]+/g", string.Empty);
            slug = Regex.Replace(slug, @" +/g", "-");
            return slug;
        }

        private bool IsCurrentUrl(string href)
        {
            var current = _httpContextAccessor.HttpContext.Request.Path.Value;
            return current.Equals(href);
        }
    }
}