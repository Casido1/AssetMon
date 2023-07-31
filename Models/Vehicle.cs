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
        public IEnumerable<Ownership> Ownerships { get; set; }
        public virtual IEnumerable<VehicleRepair> Repairs { get; set; }
        public virtual IEnumerable<Payment> Payments { get; set; }

        public Vehicle()
        {
            Id = Guid.NewGuid().ToString();
            Repairs = new List<VehicleRepair>();
            Ownerships = new List<Ownership>();
            Payments = new List<Payment>();
        }
    }
}
