using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Controllers;
using Magxe.Models;
using Magxe.Views.Abstractions;
using System.Collections.Generic;
using System.IO;

namespace Magxe.Helpers
{
    internal class ForeachHelper : HandlebarsBaseHelper
    {
        public ForeachHelper() : base("foreach", HelperType.HandlebarsBlockHelper)
        {
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            // Determine context is a view model contains ControllerType or not
            if (arguments[0] is IEnumerable<IPost> posts)
            {
                foreach (var post in posts)
                {
                    options.Template(output, post);
                }
            }
            // If not, context is navigation view model
            else
            {
                var navigations = (IEnumerable<NavigationViewModelItem>)context.navigation;
                foreach (var navi in navigations)
                {
                    options.Template(output, navi);
                }
            }
        }
    }
}