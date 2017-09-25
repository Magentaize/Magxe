using Dynamitey;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Magxe.Helpers
{
    internal class NavigationHelper : BaseHelper
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceProvider _services;

        public NavigationHelper(DataContext dataContext, IHttpContextAccessor httpContextAccessor, IServiceProvider services) : base("navigation", HelperType.HandlebarsHelper)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
            _services = services;
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var navigationData = (ICollection<NavigationItem>)((dynamic)((object[])Dynamic.InvokeGet(context, "_objects"))[1]).blog.navigation;
            if (navigationData.Count == 0)
            {
                output.WriteSafeString(string.Empty);
            }
            else
            {
                var viewData = new
                {
                    navigation = navigationData.Cast(o => new ViewNavigationItem()
                    {
                        current = IsCurrentUrl(o.Url),
                        label = o.Label,
                        url = o.Url,
                        secure = false,
                        slug = Slugify(o.Label)
                    })
                };

                var viewEngine = _services.GetService<IHandlebarsViewEngine>();
                var viewHtml = viewEngine.RenderViewWithDataAsync(@"D:\Development\GitHub\Magxe\Magxe\wwwroot\themes\casperv1\partials\navigation", viewData)
                    .Result;
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

        internal class ViewNavigationItem
        {
            public bool current { get; set; }
            public string label { get; set; }
            public string slug { get; set; }
            public string url { get; set; }
            public bool secure { get; set; }
        }
    }
}