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
using System.Threading.Tasks;

namespace Magxe.Helpers
{
    internal class NavigationHelper : HandlebarsBaseHelper
    {
        private const string DefaultTpl =
                "<ul class=\"nav\">    {{#each navigation}}    <li class=\"nav-{{slug}}{{#if current}} nav-current{{/if}}\" role=\"presentation\"><a href=\"{{url absolute=\"true\"}}\">{{label}}</a></li>    {{/each}}</ul>"
            ;
        private static string _template;

        private readonly ThemeService _themeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Lazy<IHandlebarsViewEngine> _viewEngine;
        private readonly DataContext _dataContext;

        public NavigationHelper(DataContext dataContext, ThemeService themeService, IHttpContextAccessor httpContextAccessor, IServiceProvider services) : base("navigation", HelperType.HandlebarsHelper)
        {
            _themeService = themeService;
            _themeService.ThemeChanged += async (_, __) => await SetTemplateAsync();
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
            _viewEngine = new Lazy<IHandlebarsViewEngine>(services.GetService<IHandlebarsViewEngine>);

            SetTemplateAsync();
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

                var viewHtml = _viewEngine.Value.RenderViewWithDataAsync(_template, viewData).Result;

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

        private async Task SetTemplateAsync()
        {
            var themePath = _themeService.CurrentThemePath;
            if (Directory.Exists(themePath))
            {
                var files = Directory.GetFiles(themePath, "navigation.hbs", SearchOption.AllDirectories);
                if (files.Any())
                {
                    _template = await File.ReadAllTextAsync(files[0]);
                    return;
                }
            }
            _template = DefaultTpl;
        }
    }
}