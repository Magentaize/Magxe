using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Data;
using Magxe.Extensions;
using Magxe.Models;
using Magxe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Magxe.Helpers
{
    public class PaginationHelper : HandlebarsBaseHelper
    {
        private const string DefaultTpl =
                "<nav class=\"pagination\" role=\"navigation\">    {{#if prev}}        <a class=\"newer-posts\" href=\"{{page_url prev}}\"><span aria-hidden=\"true\">&larr;</span> Newer Posts</a>    {{/if}}    <span class=\"page-number\">Page {{page}} of {{pages}}</span>    {{#if next}}        <a class=\"older-posts\" href=\"{{page_url next}}\">Older Posts <span aria-hidden=\"true\">&rarr;</span></a>    {{/if}}</nav>"
            ;

        private static string _template;

        private readonly ThemeService _themeService;
        private readonly Lazy<IHandlebarsViewEngine> _viewEngine;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;

        public PaginationHelper(DataContext dataContext, ThemeService themeService, IServiceProvider services,
            IHttpContextAccessor httpContextAccessor) : base("pagination", HelperType.HandlebarsHelper)
        {
            _themeService = themeService;
            _viewEngine = new Lazy<IHandlebarsViewEngine>(services.GetService<IHandlebarsViewEngine>);
            _themeService.ThemeChanged += async (_, __) => await SetTemplateAsync();
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;

            SetTemplateAsync();
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var urlPath = _httpContextAccessor.HttpContext.Request.Path.Value;
            var page = 1;
            var pageMatch = urlPath.Match(@"(/page/)(\d+)(/*)");
            if (pageMatch.Success)
            {
                page = pageMatch.Groups[2].Value.CastToInt();
            }
            var pages = _dataContext.Posts.GetTotalPagesAsync().Result;

            var vm = new PaginationViewModel()
            {
                page = page,
                pages = pages
            };
            if (page != pages)
            {
                vm.next = page + 1;
            }
            if (page != 1)
            {
                vm.prev = page - 1;
            }

            var viewHtml = _viewEngine.Value.RenderViewWithDataAsync(_template, vm).Result;
            output.WriteSafeString(viewHtml);
        }

        private async Task SetTemplateAsync()
        {
            var themePath = _themeService.CurrentThemePath;
            if (Directory.Exists(themePath))
            {
                var files = Directory.GetFiles(themePath, "pagination.hbs", SearchOption.AllDirectories);
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