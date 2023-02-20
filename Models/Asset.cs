﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public class Asset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
       
        //Nav prop
        public virtual IEnumerable<Repair> Repairs { get; set; }
        public Asset()
        {
            Id = Guid.NewGuid().ToString();
            Repairs = new List<Repair>();
        }
    }
}
