using System;

namespace Magxe.Views.Abstractions
{
    internal interface IPostAuthor : ISlug
    {
        string profile_image { get; set; }
        string name { get; set; }
        string location { get; set; }
        string bio { get; set; }

        [Obsolete("Only be compatible with Ghost", true)]
        string website { get; }
    }
}