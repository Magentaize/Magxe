﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HandlebarsDotNet.ViewEngine.Abstractions;
using HandlebarsDotNet.ViewEngine.Extensions;
using Magxe.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Magxe.Data;
using Magxe.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Magxe.Models.ControllerViewModels;
using Magxe.Models.DaoConverters;
using Magxe.Helpers;
using Magxe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;

namespace Magxe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting()
                .AddAutoMapper(DaoConverters.ConfigAutoMapper)
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScoped<ThemeService, ThemeService>()
                .AddDbContext<DataContext>()
                .AddMvc()
                .AddViewOptions(options =>
                {
                    options.ViewEngines.Clear();
                })
                .AddHandlebarsViewEngine(options =>
                {
                    options.RegisterHelpers = Helpers.Helpers.RegisterHelpers;

                    options.ViewLocationFormats.Clear();
                    options.ViewLocationFormats.Add(
                        () => @"D:\Development\GitHub\Magxe\Magxe\wwwroot\themes\casperv1\{0}.hbs"//services.BuildServiceProvider().GetService<ThemeService>().CurrentTheme
                    );
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IServiceProvider services, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IApplicationBuilder app, IHostingEnvironment env)
        {
            Config.ServiceProvider = services;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles()
                .Map("/favicon.ico", cfg => cfg.UseStaticFiles())
                .UseMvc();
        }
    }
}
