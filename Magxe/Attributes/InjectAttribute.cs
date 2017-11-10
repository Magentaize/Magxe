using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Magxe.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class InjectAttribute : Attribute, IBindingSourceMetadata
    {
        /// <inheritdoc />
        public BindingSource BindingSource => BindingSource.Services;
    }
}