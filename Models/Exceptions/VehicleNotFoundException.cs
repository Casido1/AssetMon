using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models.Exceptions
{
    public sealed class VehicleNotFoundException : NotFoundException
    {
        public VehicleNotFoundException(string vehicleId) : base($"The vehicle with id: {vehicleId} doesn't exist in the database.")
        {        
        }
    }
}
