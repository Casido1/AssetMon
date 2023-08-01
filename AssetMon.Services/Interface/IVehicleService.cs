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
        Task<ResultDTO<IEnumerable<VehicleDTO>>> GetAllVehiclesAsync(bool trackChanges);
        Task<ResultDTO<VehicleDTO>> GetVehicleByIdAsync(string Id, bool trackChanges);
        Task<ResultDTO<IEnumerable<PaymentDTO>>> GetVehiclePaymentsByVehicleIdAsync(string Id, bool trackChanges);
    }
}
