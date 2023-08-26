using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetMon.Shared.RequestFeatures
{
    public class VehicleParameters : RequestParameters
    {
        public VehicleParameters()
        {
            OrderBy = "startdate";
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        [JsonIgnore]
        public bool ValidDateRange => EndDate > StartDate;
        public string SearchTerm { get; set; }
    }
}
