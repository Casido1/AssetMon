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
        Task<IEnumerable<VehicleDTO>> GetAllVehiclesAsync(bool trackChanges);
        Task<VehicleDTO> GetVehicleByIdAsync(string Id, bool trackChanges);
    }
}
