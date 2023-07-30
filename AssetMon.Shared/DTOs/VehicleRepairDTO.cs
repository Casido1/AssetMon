using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Shared.DTOs
{
    public class VehicleRepairDTO
    {
        public string Id { get; set; }
        public string VehicleId { get; set; }
        public string RepairName { get; set; }
        public decimal Amount { get; set; }
    }
}
