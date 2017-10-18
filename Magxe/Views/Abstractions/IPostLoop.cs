using System.Collections.Generic;

namespace Magxe.Views.Abstractions
{
    internal interface IPostLoop
    {
        IEnumerable<IPost> posts { get; }
        (int TotalPages, int CurrentPage) PageInfo { get; }
    }
}