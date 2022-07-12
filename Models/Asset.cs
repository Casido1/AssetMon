using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public class Asset
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Type { get; set; }
        public string? PaymentFrequency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PaymentAmount { get; set; }
        public bool IsActive { get; set; } = false;
        public string AppUserId { get; set; }

        //nav prop
        public AppUser AppUser { get; set; }
    }
}
