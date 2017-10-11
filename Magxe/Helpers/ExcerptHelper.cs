using System.IO;
using System.Text.RegularExpressions;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Controllers;
using Magxe.Extensions;
using Magxe.Models;
using Microsoft.AspNetCore.Mvc;

namespace Magxe.Helpers
{
    internal class ExcerptHelper : BaseHelper
    {
        public ExcerptHelper() : base("excerpt", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic dContext, params object[] oArguments)
        {
            var arguments = oArguments[0].Cast<HashParameterDictionary>();
            var wordLimit = arguments.ContainsKey("words") ? arguments["words"].CastToInt() : 50;

            if (dContext is PostViewModel post)
            {

                if (post.CustomExcerpt.IsNullOrEmpty())
                {
                    post.excerpt = post.Html.RegexReplace("<a href=\"#fn.*?rel=\"footnote\">.*?<\\/a>",
                            RegexOptions.IgnoreCase)
                        .RegexReplace("<div class=\"footnotes\"><ol>.*?<\\/ol><\\/div>")
                        .RegexReplace("<\\/?[^>]+>", RegexOptions.IgnoreCase)
                        .RegexReplace("(\r\n|\n|\r)+", " ", RegexOptions.Multiline);
                }
                else
                {
                    post.excerpt = post.CustomExcerpt;
                }

                // TODO: substring excerpt like downsize in JS
                post.excerpt = post.excerpt.Substring(0, wordLimit);
            }
        }
    }
}