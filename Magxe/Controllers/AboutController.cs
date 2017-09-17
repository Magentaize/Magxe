using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HandlebarsDotNet;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers
{
    public class AboutController : Controller
    {
        [Route("")]
        public async Task<string> Index()
        {
            //Handlebars.RegisterHelper("foreach", (writer, context, arguments) =>
            //{
            //    writer.WriteSafeString();
            //});

            var l = await new StreamReader(@"D:\Development\GitHub\CasperV1\partials\loop.hbs")
                .ReadToEndAsync();
            Handlebars.RegisterTemplate("loop" , l);
            var f = await new StreamReader(@"D:\Development\GitHub\Magxe\Magxe\wwwroot\themes\casperv1\default.hbs")
                .ReadToEndAsync();
            var source = Handlebars.Compile(f);
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