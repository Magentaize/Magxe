using AutoMapper;
using HandlebarsDotNet.ViewEngine.Extensions;
using Magxe.Dao;
using Magxe.IdentityServer.Extensions;
using Magxe.Models.DaoConverters;
using Magxe.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            services.AddOAuth2();

            services
                .AddMvcCore()
                .AddJsonFormatters();

            services
                .AddAutoMapper(DaoConverters.ConfigAutoMapper)
                .AddTransient<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScoped<ThemeService, ThemeService>()
                .AddDbContext<DataContext>()
                .AddRouting()
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
                        () =>
                        {
                            var theme = services.BuildServiceProvider().GetService<ThemeService>().CurrentTheme;
                            return $@"D:\Development\GitHub\Magxe\Magxe\wwwroot\themes\{theme}\{{0}}.hbs";
                        }

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

            app.UseIdentityServer();

            app.UseStaticFiles()
                .Map("/favicon.ico", cfg => cfg.UseStaticFiles())
                .UseMvc();
        }
    }
}
