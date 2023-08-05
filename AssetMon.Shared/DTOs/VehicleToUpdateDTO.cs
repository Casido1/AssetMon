using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Shared.DTOs
{
    public class VehicleToUpdateDTO
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
