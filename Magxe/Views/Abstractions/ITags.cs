using System.Collections.Generic;
using Magxe.Data;

namespace Magxe.Views.Abstractions
{
    internal interface ITags
    {
        IEnumerable<Tag> tags { get; }
    }
}