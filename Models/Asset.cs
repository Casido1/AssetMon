﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public abstract class Asset
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
