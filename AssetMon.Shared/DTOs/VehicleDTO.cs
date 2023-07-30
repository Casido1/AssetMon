using AssetMon.Models;
using AssetMon.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Shared.DTOs
{
    public class VehicleDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string ContractType { get; set; }
        public int Tenure { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentFrequency { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime StartDate { get; set; }
        public virtual IEnumerable<VehicleRepair> Repairs { get; set; }
    }
}
