using AssetMon.Models;
using AssetMon.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Services.Interface
{
    public interface IVehicleService
    {
        IEnumerable<VehicleDTO> GetAllVehicles(bool trackChanges);
    }
}
