using AssetMon.Models.Enums;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public class Vehicle : Asset
    {
        [ForeignKey("Owner")]
        public string OwnerId { get; set; }
        [ForeignKey("Driver")]
        public string DriverId { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public Contracts ContractType { get; set; }
        public int Tenure { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaymentAmount { get; set; }
        public PaymentFrequency PaymentFrequency { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime StartDate { get; set; }

        //Nav prop
        public virtual AppUser Driver { get; set; }
        public virtual AppUser Owner { get; set; }
    }
}
