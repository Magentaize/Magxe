using System.Collections.Generic;
using Magxe.Data;

namespace Magxe.Helpers.Abstractions
{
    internal interface ITags
    {
        IEnumerable<Tag> tags { get; }
    }
}