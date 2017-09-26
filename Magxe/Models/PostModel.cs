﻿using Magxe.Controllers;
using Magxe.Data.Setting;

namespace Magxe.Models
{
    public class PostModel
    {
        public ControllerType controllerType { get; set; }
        public BlogModel blog { get; set; }
        public int authorId { get; set; }
        public string feature_image { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string url { get; set; }
    }
}