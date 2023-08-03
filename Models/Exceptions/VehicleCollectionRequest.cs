using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models.Exceptions
{
    public sealed class VehicleCollectionRequest : BadRequestException
    {
        public VehicleCollectionRequest() : base("Vehicle collection sent from a client is null")
        {
                
        }
    }
}
