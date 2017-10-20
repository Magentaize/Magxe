using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Controllers;
using Magxe.Models;
using Magxe.Views.Abstractions;

namespace Magxe.Helpers
{
    internal class TagBlockHelper : HandlebarsBaseHelper
    {
        public TagBlockHelper() : base("tag", HelperType.HandlebarsBlockHelper)
        {
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            var ivm = (TagControllerViewModel) context;
            var vm = new InnerTagViewModel()
            {
                name = ivm.name,
                description = ivm.description,
                PluralNumber = ivm.PluralNumber
            };

            options.Template(output, vm);
        }

        private class InnerTagViewModel : IPlural
        {
            public string name { get; set; }
            public string description { get; set; }
            public int PluralNumber { get; set; }

            ControllerType IControllerType.ControllerType => ControllerType.Tag;
        }
    }
}