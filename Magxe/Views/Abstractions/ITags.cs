using System.Collections.Generic;
using Magxe.Dao;

namespace Magxe.Views.Abstractions
{
    internal interface ITags
    {
        IEnumerable<Tag> tags { get; }
    }
}