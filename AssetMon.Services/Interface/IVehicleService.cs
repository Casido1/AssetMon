using AssetMon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Services.Interface
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetAllVehicles(bool trackChanges);
    }
}
