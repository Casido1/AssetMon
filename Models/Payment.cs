using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public class Payment
    {
        public string Id { get; set; }
        [ForeignKey("Vehicle")]
        public string VehicleId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        //Nav prop
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }
    }
}
