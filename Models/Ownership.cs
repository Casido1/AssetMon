using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public class Ownership
    {
        public string AppUserId { get; set; }

        public string VehicleId { get; set; }

        //nav prop
        public AppUser AppUser { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
