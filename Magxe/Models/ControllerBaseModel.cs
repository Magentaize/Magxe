using System;
using Magxe.Controllers;
using Magxe.Views.Abstractions;

namespace Magxe.Models
{
    public class ControllerBaseModel : IControllerType
    {
        public ControllerType ControllerType { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
    }
}