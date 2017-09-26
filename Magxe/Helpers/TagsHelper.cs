﻿using System.IO;
using HandlebarsDotNet.ViewEngine.Abstractions;

namespace Magxe.Helpers
{
    internal class TagsHelper : BaseHelper
    {
        public TagsHelper() : base("tags", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
        }
    }
}