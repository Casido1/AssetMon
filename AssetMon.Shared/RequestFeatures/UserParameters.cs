using System.Text.Json.Serialization;

namespace AssetMon.Shared.RequestFeatures
{
    public class UserParameters : RequestParameters
    {
        public UserParameters()
        {
            OrderBy = "create";
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        [JsonIgnore]
        public bool ValidDateRange => EndDate > StartDate;
        public string SearchTerm { get; set; }
    }
}
