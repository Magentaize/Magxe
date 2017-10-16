using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dynamitey;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Controllers;
using Magxe.Data;
using Magxe.Utils;

namespace Magxe.Helpers
{
    public class BodyClassHelper : HandlebarsBaseHelper
    {
        public BodyClassHelper() : base("body_class", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var classes = new List<string>();

            switch ((ControllerType)context.controllerType)
            {
                case ControllerType.Index:
                    classes.Add("home-template");
                    break;
                case ControllerType.Post:
                    classes.Add("post-template");
                    break;
                case ControllerType.Page:
                    classes.Add("page-template");
                    classes.Add($"page-{context.slug}");
                    break;
                case ControllerType.Tag:
                    classes.Add("tag-template");
                    classes.Add($"tag-{context.slug}");
                    break;
                case ControllerType.Author:
                    classes.Add("author-template");
                    var slug = ((dynamic)((object[])Dynamic.InvokeGet(context, "Objects"))[1]).slug;
                    classes.Add($"author-{slug}");
                    break;
                case ControllerType.Private:
                    classes.Add("private-template");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (DynamicUtil.ContainsKey(context, "paged"))
            {
                classes.Add("paged");
            }

            output.WriteSafeString(string.Join(' ', classes).Trim());
        }
    }
}