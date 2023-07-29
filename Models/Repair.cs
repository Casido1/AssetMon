using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetMon.Models
{
    public class VehicleRepair
    {
        public string Id { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public string VehicleId { get; set; }
        public string RepairName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        //Nav prop
        public Vehicle Vehicle { get; set; }
        public VehicleRepair()
        {
            Id = Guid.NewGuid().ToString(); 
        }
    }
}
