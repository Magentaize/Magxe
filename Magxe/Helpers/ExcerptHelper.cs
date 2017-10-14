using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using DownsizeNet;
using HandlebarsDotNet;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Controllers;
using Magxe.Extensions;
using Magxe.Models;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Helpers
{
    internal class ExcerptHelper : HandlebarsBaseHelper
    {
        public ExcerptHelper() : base("excerpt", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic dContext, params object[] oArguments)
        {
            if (dContext is PostViewModel post)
            {
                string excerpt;
                if (post.CustomExcerpt.IsNullOrEmpty())
                {
                    excerpt = post.Html.RegexReplace("<a href=\"#fn.*?rel=\"footnote\">.*?</a>",
                            RegexOptions.IgnoreCase)
                        .RegexReplace("<div class=\"footnotes\"><ol>.*?</ol></div>")
                        .RegexReplace("</?[^>]+>", RegexOptions.IgnoreCase)
                        .RegexReplace("(\r\n|\n|\r)+", " ", RegexOptions.Multiline);
                }
                else
                {
                    excerpt = post.CustomExcerpt;
                }

                var arguments = oArguments[0].Cast<HashParameterDictionary>();
                var parameters = new Dictionary<string, object>()
                {
                    {"words", arguments.GetValueOrDefault("words", DownsizeOptions.DefaultTruncationLimit).CastToInt()},
                    {"characters", arguments.GetValueOrDefault("characters", DownsizeOptions.DefaultTruncationLimit).CastToInt()},
                    {"round", arguments.GetValueOrDefault("round", false)},
                };
                var ctor = typeof(DownsizeOptions).GetConstructors()[0];
                var options = ctor.InvokeWithNamedParameters<DownsizeOptions>(parameters);

                excerpt = Downsize.Substring(excerpt, options);
                output.WriteSafeString(excerpt);
            }
        }
    }
}