using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AssetMon.Models
{
    public class Payment
    {
        public string Id { get; set; }
        [ForeignKey("Vehicle")]
        [Required]
        public string VehicleId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        //Nav prop
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }
    }
}
