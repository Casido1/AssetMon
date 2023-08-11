using System.Text.Json.Serialization;

namespace AssetMon.Shared.RequestFeatures
{
    public class PaymentParameters : RequestParameters
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        [JsonIgnore]
        public bool ValidDateRange => EndDate > StartDate;
        public string SearchTerm { get; set; }
    }
}
