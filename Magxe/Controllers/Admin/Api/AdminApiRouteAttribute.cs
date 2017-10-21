using System;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Magxe.Controllers.Admin.Api
{
    public class AdminApiRouteAttribute : Attribute, IRouteTemplateProvider
    {
        public string Template => "ghost/api/v0.1/[controller]";
        public int? Order { get; set; }
        public string Name { get; set; }
    }
}