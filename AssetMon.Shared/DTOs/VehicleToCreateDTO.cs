using AssetMon.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetMon.Shared.DTOs
{
    public class VehicleToCreateDTO
    {
        public string Name { get; set; }

        public string PlateNumber { get; set; }

        public string Color { get; set; }

        public int ContractType { get; set; }

        public int Tenure { get; set; }

        public decimal PaymentAmount { get; set; }

        public int PaymentFrequency { get; set; }

        public bool IsActive { get; set; } = false;

        public DateTime StartDate { get; set; }
    }
}
