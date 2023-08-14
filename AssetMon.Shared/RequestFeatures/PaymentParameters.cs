using System.Text.Json.Serialization;

namespace AssetMon.Shared.RequestFeatures
{
    public class PaymentParameters : RequestParameters
    {
        public PaymentParameters()
        {
            OrderBy = "date";
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        [JsonIgnore]
        public bool ValidDateRange => EndDate > StartDate;
    }
}
