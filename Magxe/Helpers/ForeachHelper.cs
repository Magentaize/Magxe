using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Magxe.Controllers;
using Magxe.Models;

namespace Magxe.Helpers
{
    internal class ForeachHelper : BaseHelper
    {
        public ForeachHelper() : base("foreach", HelperType.HandlebarsBlockHelper)
        {
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            var controlleerType = (ControllerType)context.ControllerType;
            switch (controlleerType)
            {
                case ControllerType.Index:IndexForEach(output,options,context,arguments);
                    break;
            }
            //var collection = arguments[0].Cast<IEnumerable>();
            //foreach (object o in collection)
            //{
            //    options.Template(output, o);
            //}
        }

        private void IndexForEach(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            var posts = (IEnumerable<PostViewModel>) arguments[0];
            foreach (var post in posts)
            {
                options.Template(output, post);
            }
        }
    }
}