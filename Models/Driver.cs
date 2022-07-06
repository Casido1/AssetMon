using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public class Driver
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhotoUrl { get; set; }
        public string ContractType { get; set; }
        public bool IsActive { get; set; } = false;
        public string assetId { get; set; }
        public string? AddressId { get; set; }

        //nav prop
        public Address? Address { get; set; }

    }
}
