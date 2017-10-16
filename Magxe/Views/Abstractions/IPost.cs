using Magxe.Models;
using System;

namespace Magxe.Views.Abstractions
{
    internal interface IPost : ITags, ISlug
    {
        string title { get; }
        IPostAuthor author { get; }
        DateTime date { get; }
        string excerpt { get; }
    }
}