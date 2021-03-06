﻿using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Models;
using Magxe.Services;
using Magxe.Views.Abstractions;
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

        private string _cachedHtml;
        private bool _firstCall = true;

        public PaginationHelper(ThemeService themeService, IServiceProvider services) : base("pagination", HelperType.HandlebarsHelper)
        {
            _themeService = themeService;
            _viewEngine = new Lazy<IHandlebarsViewEngine>(services.GetService<IHandlebarsViewEngine>);
            _themeService.ThemeChanged += async (_, __) => await SetTemplateAsync();

            SetTemplateAsync();
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            if (_firstCall)
            {
                var postLoopVm = (IPostLoop) context;
                var page = postLoopVm.PageInfo.CurrentPage;
                var pages = postLoopVm.PageInfo.TotalPages;

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

                _cachedHtml = _viewEngine.Value.RenderViewWithDataAsync(_template, vm).Result;

                _firstCall = false;
            }
            else
            {
                _firstCall = true;
            }

            output.WriteSafeString(_cachedHtml);
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