using System;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Magxe.Controllers.Api
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RestApiControllerAttribute : Attribute, IRouteTemplateProvider
    {
        public string Template => "ghost/api/v0.1/[controller]";
        public int? Order { get; set; }
        public string Name { get; set; }
    }
}