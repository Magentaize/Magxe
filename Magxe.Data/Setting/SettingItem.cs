﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Magxe.Data.Setting
{
    public class SettingItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Key Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
