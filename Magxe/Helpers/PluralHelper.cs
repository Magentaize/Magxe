﻿using System.IO;
using HandlebarsDotNet.ViewEngine.Abstractions;

namespace Magxe.Helpers
{
    public class PluralHelper : BaseHelper
    {
        public PluralHelper() : base("plural", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            
        }
    }
}