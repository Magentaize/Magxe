using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HandlebarsDotNet;
using Magxe.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers
{
    public class AboutController : Controller
    {
        [Route("")]
        public async Task<string> Index()
        {
            var l = new StreamReader(@"D:\Development\GitHub\CasperV1\partials\loop.hbs");

            Handlebars.RegisterTemplate("loop" , Handlebars.Compile(l));
            var f = await new StreamReader(@"D:\Development\GitHub\Magxe\Magxe\wwwroot\themes\casperv1\default.hbs")
                .ReadToEndAsync();
            Handlebars.RegisterTemplate("default",f);
            var i = await new StreamReader(@"D:\Development\GitHub\Magxe\Magxe\wwwroot\themes\casperv1\index.hbs")
                .ReadToEndAsync();
            var source = Handlebars.Compile(i);
            var data = new
            {
                blog = new
                {
                    title = "title"
                }
            };
            var result = source(data);

            return result;
        }
    }
}