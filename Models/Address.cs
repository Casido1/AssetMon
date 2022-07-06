using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public class Address
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string? Street { get; set; }
    }
}
