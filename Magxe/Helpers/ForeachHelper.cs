using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Magxe.Controllers;
using Magxe.Models;
using Magxe.Views.Abstractions;

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
            if (context is ControllerBaseModel controllerContext)
            {
                var controllerType = controllerContext.ControllerType;
                switch (controllerType)
                {
                    case ControllerType.Index:
                        IndexForEach(output, options, context, arguments);
                        break;
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

            //var collection = arguments[0].Cast<IEnumerable>();
            //foreach (object o in collection)
            //{
            //    options.Template(output, o);
            //}
        }

        private void IndexForEach(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            var posts = (IEnumerable<IPost>) arguments[0];
            foreach (var post in posts)
            {
                options.Template(output, post);
            }
        }
    }
}