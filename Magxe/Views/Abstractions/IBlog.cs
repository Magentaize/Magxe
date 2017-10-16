using System;
using Magxe.Models;

namespace Magxe.Views.Abstractions
{
    internal interface IBlog
    {
        BlogViewModel blog { get; }
        DateTime date { get; }
    }
}