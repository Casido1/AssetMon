using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetMon.Models
{
    public class Repair
    {
        public string Id { get; set; }
        [Required]
        public string AssetId { get; set; }
        public string RepairName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        //Nav prop
        public virtual Asset Asset { get; set; }
        public Repair()
        {
            Id = Guid.NewGuid().ToString(); 
        }
    }
}
